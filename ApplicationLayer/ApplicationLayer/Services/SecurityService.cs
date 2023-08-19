using ApplicationLayer.Config;
using ApplicationLayer.Enum;
using ApplicationLayer.Interface;
using ApplicationLayer.Models;
using DataAccessLayer.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly PasswordGenerationConfig _passwordGenerationConfig;
        private readonly IMailService _mailService;

        public SecurityService(IUserRepository userRepository, IConfiguration configuration , IOptions<PasswordGenerationConfig> passwordOptions, IMailService mailService)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _passwordGenerationConfig = passwordOptions.Value;
            _mailService = mailService;
        }

        public async Task<LoginModel> Login(string Username , string Password)
        {
            LoginModel loginModel = new();

            var userData = await _userRepository.GetUserByUserame(Username);
            if(userData!= null && userData.Password == Password)
            {
                loginModel.IsLogin = true;
                loginModel.jwtToken = GenerateToken(userData.RoleID, userData.Name, userData.ID);
            }
            else
            {
                loginModel.IsLogin = false;
            }
            return loginModel;
        }

        public string GeneratePassword(string email)
        {
            if (!_passwordGenerationConfig.UseDefualtPasswordAndDontSendMail)
            {
                var password = GenerateRandomString();
                _mailService.SendEmail(email, "Ejada Employee System Password", $"Hi \n This is your Password {password} \n Dont Share it");
                return password;
            }
            else
            {
                return string.IsNullOrEmpty(_passwordGenerationConfig.DefualtPassword) ? "123456" : _passwordGenerationConfig.DefualtPassword;
            }
        }

        private string GenerateToken(int roleId , string name , int userId)
        {
            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, name),
               new Claim(ClaimTypes.Role, UserRoles.GetRole(roleId)),
               new Claim(ClaimTypes.PrimarySid, userId.ToString()),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(authClaims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string GenerateRandomString()
        {
             Random rd = new Random();

                const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";
                char[] chars = new char[6];
                for (int i = 0; i < 6; i++)
                {
                    chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
                }
                return new string(chars);
        }
    }
}
