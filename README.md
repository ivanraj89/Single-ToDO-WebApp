# Single-ToDO-WebApp
First mini .net project

Mini project exploring simple CRUD application on the .NET framework. 
Project also uses the RDBMS MSSQL

Bugs and Known Issues Solved :
Issues with ssl certificate - Solved by adding in Trusted_Connection=True;TrustServerCertificate=True in appsettings,json. Im now aware that entity framework couldve done this automatically based on the Microsoft docs but when i used it in this case i had 
to adjust these manually instead
Issues with db creation by entity framework - Solved by manualy creating a database in MSSQL and then linking it based on the json string above
Issues with null values for table values - Solved by using breakpoints to figure out where null values was coming from which i later learned needed me to make it into an identity column in MSSQL 

Future consideration :
Moving into Microsofts docs to dive in depth into the frameworks available and also learning more on using Entity Framework for proper db set up 
 
