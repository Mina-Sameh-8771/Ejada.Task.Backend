Steps to run project :

1) Add you connection string in app setting
2) run migrarion to init you database
3) if your angular project run in differnt port of (localhost:4200) please change this domain with yo domain in start.cs file in WebApi project to allow cors orign (Ignore this step of your angular project run in localhost:4200)
4) use defualt admin account to start your journey in application with this credential (username: Admin , password: 123456)
5) In PasswordGenerationConfig section in appsetting you can set UseDefualtPasswordAndDontSendMail to true if you want to genarate defualt password (set this defualt password in DefualtPassword key in this secion)
   If you want use mail set UseDefualtPasswordAndDontSendMail to false and fill MailConfig with you data (Mail , password) from gmail after add application in your account and use this credential
