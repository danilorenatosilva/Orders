# Orders API with Clean Architecture
An ASP.NET Core 5 application using Clean Architecture concepts

# Technologies used  
ASP.NET Core 5.0  
EntityFrameworkCore 5.0  
Identity  
SQL Server  
Docker  
Json Web Token (JWT)  

# Running the application
To run the application on a Docker container with the Docker installed in a Windows machine run the exec.bat script that is in the same directory of the solution, this bat file will call docker compose build and run.  
After executing the script the application will be running on the localhost in the 5000 port.

# Accessing the endpoints
To access the endpoints that need authorization, first you need to register a user on the signup endpoint and then call the signin endpoint passing a valid user and password, this call will return to you an JWT Token that you will use to call the endpoints that need authorization, like /products and so on.

# Curl Examples of how to call the endpoints
SignIN  
curl -X POST "http://localhost:5000/Authentication/signin" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"userName\":\"string\",\"password\":\"string\"}"  

SignUp  
curl -X POST "http://localhost:5000/Authentication/signup" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"userName\":\"string\",\"fullDisplayName\":\"string\",\"password\":\"string\",\"email\":\"string\"}"  

Users GET - (all the parameters are optional)
curl -X GET "http://localhost:5000/Users?userName=userName&fullDisplayName=fullDisplayName&email=email&initialDate=initialDate&finalDate=finalDate" -H "Authorization: Bearer token_value" -H  "accept: */*"  

Orders GET  
curl -X GET "http://localhost:5000/Orders" -H "Authorization: Bearer token_value" -H  "accept: */*"  

Orders POST  
curl -X POST "http://localhost:5000/Orders" -H "Authorization: Bearer token_value" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"userId\":0,\"products\":[{\"price\":0,\"quantity\":0}]}"  

Products GET (all the parameters are optional)  
curl -X GET "http://localhost:5000/Products?name=name&description=description&price=price&initialDate=initialDate&finalDate=finalDate" -H "Authorization: Bearer token_value" -H  "accept: */*"  

Products POST  
curl -X POST "http://localhost:5000/Products" -H "Authorization: Bearer token_value" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"id\":0,\"name\":\"string\",\"description\":\"string\",\"price\":0}"  

Products PUT  
curl -X PUT "http://localhost:5000/Products/1" -H "Authorization: Bearer token_value" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"id\":0,\"name\":\"string\",\"description\":\"string\",\"price\":0}"  

