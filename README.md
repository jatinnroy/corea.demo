# rocea.demo
Its a demo for you
This will work with MS SQL SERVER
This project is based on .net core 8 with JWT token authentication and Swagger

# To intial 
Make sure you fire below comman in the demo.Database project
run this command in package manager console
  -> add-migration Initial
  This will initialize databas structure with code first model

  and then 
  -> update-database
  This will update your datbase with required entity with ASP.Net Identity table and all seed data , which crete 1 user as 
  -> user: admin / Pass: Admin@123

# To run
Afrer this 
you will also see seeded data of 3 health care professionals.

Now if you want to check all required assign task as an api
Just do above process and run the demo project

And once login with postman, and authorizing user with token
You can perform the desired operation
and it also validate the duplication of appointment for health care proffesional

