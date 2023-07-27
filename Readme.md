### Application Description
This is a simple WebAPI application that is written on .NETR 6 (C#10 language).
The app allows to retrieve county data from 3rd part API.
It allows to filter, sort and limit the outcoming data.
After the launch the request can be easily sended with help of installed and configured Swagger.

### How to run the solution locally
To run the solution locally, please follow the next steps:
1. Clone the repository;
2. Open the solution via Visual Studio or VS Code;
3. Set UseCase1 as a startup project;
4. Run this project in debug mode.

### Examples of how to use the endpoint
To retrieve the data the user should send the request to a defined url, for example:
* To get all the countries: https://localhost:7263/api/countries
* To filter countries by name: https://localhost:7263/api/countries?name=norway
* To filter countries by partial name: https://localhost:7263/api/countries?name=st
* To filter countries by population: https://localhost:7263/api/countries?population=10
* To sort countries by name by ascending #1: https://localhost:7263/api/countries?sortOrder=asc
* To sort countries by name by ascending #2: https://localhost:7263/api/countries?sortOrder=ascend
* To sort countries by name by descending #1: https://localhost:7263/api/countries?sortOrder=desc
* To sort countries by name by descending #2: https://localhost:7263/api/countries?sortOrder=descend
* To limit countries : https://localhost:7263/api/countries?limit=15
* To get all countries even of you limit them : https://localhost:7263/api/countries?limit=0
