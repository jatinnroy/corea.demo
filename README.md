# rocea.demo
Its a demo for you
This will work with MS SQL SERVER
This project is based on .net core 8 with JWT token authentication and Swagger


I used a generic repository to maintain SOLID principles.
I used Fluent validation for validation on the server side.
I used the entity framework.
I used Mapster to bind/transfer data in between
I used the model-first approach, which is a faster way, and also maintained the process regarding database changes and updates.

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

# What if had more time to complete this exercies
I can implement ci/cd process whic i know for basic level
I can implement unit test with use of MSTEST 
I can Cancel an appointment (with constraints, e.g., not allowed within 24 hours of the appointment time).
I can make base entity which are common in 80% of model in whole project
I can create dtos as trasnfer model
I can create srvice of user which have all required info of logged in user so i can use it anywhere in the code
I can do much more in this
  
