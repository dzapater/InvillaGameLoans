# InvillaGameLoans
- This is the back-end and front-end of app;
- To configuring the database, i'm using a SQL Server DB:
  - User: sa / pass: Loans@123;
  - Port 1433;
  - If you wanna use a Token without call the login action please use this:  - eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTG9hbiI6IkFkbWluIiwiUGFzc3dvcmQiOiJJbnZpbGxhMTIzIiwiUm9sZSI6ImFkbWluIiwibmJmIjoxNjEyNTM4NzcwLCJleHAiOjE2MTI1NDIzNzB9.KlqVEHloiFbGMFxAM55imODYT33ExflJW8GI6t2-CV4
-  I'm using the DDD approach without DTO's and CrossCutting because of the deserialization of JObject and using EF directly;
  - Another reason is the SOLID with MVC concept to make a Code Clean approach and write a simple understanding code;
-  If you run de app. it calls a front-end integration;


# Architeture
  - NetCore 3.1:
    - Entity Framework on SQL Server;
    - NewtonSoft;
    - Migrations;
    - Swagger to test the Actios, EndPoints and back-end;
      - Using Token Bearer
    - ActionFilter to control pipeline requisitons of Controller;
      - JwtToken and roles approach;
    - The ILogger has been instantiate on Pipeline of Application, but I don't use this;
  - Angular front-end;
    - Basic requisitions with bootstrap faceless;
    - Make tests with Bearer and debug more easily;


# Running DockerImage
- To run the image please use code below:
  - docker-compose  -f docker-compose.yml up
- It's take afew minutes to load the project;
- Please use http://loalhost:5000;
- Only the Database and back-end are on image.

