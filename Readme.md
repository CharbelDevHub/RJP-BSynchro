IDE: Vs Code

Required dotnet version 8.0

Once the project is built you must run migrations by using the following command -- dotnet ef databae update --
Once migrated tables will be created and you just need to add customers to your table for testability
To run the project use the following command -- dotnet run --

in cmd 
run the following commands:
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
