# InvillaGameLoans

- This is the back-end and front-end of app
- To configuring the database, i'm using a SQL Server DB
  - User: sa / pass: Loans@123;
  - Port 1433;
  - If you wanna use a Token without call the login action please use this:  - eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNTM4NzcwLCJleHAiOjE2MTI1NDIzNzB9.KlqVEHloiFbGMFxAM55imODYT33ExflJW8GI6t2-CV4
-  I'm using Swagger to make the requistion tests;
-  I'm using the DDD approach without DTO's and CrossCutting because of the deserialization of JObject and using EF directly;
  - Another reason is the SOLID concept to make a Code Clean approach and write a simple understanding code;
- I'm using ActionFilter to catch the requistion and validate de JwtToken; 
-  If you run de app. it calls a front-end integration;


# Running DockerImage

- docker-compose  -f docker-compose.yml up
- It's take afew minutes to load the project;
- Please use http://loalhost:5000;
- Only the Database and back-end are on image.

