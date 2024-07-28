# DatingApp

Docker is used in the project.

Run the project in Docker.
Download Docker Desktop application  https://docs.docker.com/desktop/install/windows-install/

Download Repo and run DatingApp.API.sln file .

---------------------------------------------------------------

# Method #1 You can also run the project

1) Set startup project DatingApp.API project

2) Run DatingApp.API

  Swagger starts at  https://localhost:5001/swagger/index.html
    
 The database is created in your local MSSQL


# Method #2 for run application using Docker

1) Set startup project docker-compose , and run it Docker Compose
2) After opening the Swagger starts at  http://localhost:8010/swagger/index.html
 
 
# Method #3 for run application using Docker
 
1) Open the Developer Powershell tab at the bottom of Visual Studio.. Enter the command
 
 for build
"docker-compose build"

for run in Docker Desktop application 
"docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d"


You will see instance , backend and MSSQL DB 
for example ..
![image](https://user-images.githubusercontent.com/46989769/229551315-5437592c-495d-41f1-97e9-59c57057d27b.png)

Swagger starts at  http://localhost:8010/swagger/index.html


