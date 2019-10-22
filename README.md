# Road Status

This is a dotnet core 3.0 console app which fetch data TFL open data REST API at https://api.tfl.gov.uk. The response contain a json output containing id,displayName,statusSeverity,statusSeverityDescription and other fields in case of inputing valid road id. In other case it returns 404 status code.

## Assumptions

1. Value of $lastexitcode will be 1 before enquiring about any road status irrespective it is valid or not.

2. Value of $lastexitcode is 0 after enquiring valid road details and for invalid road it is 1.

## Getting Started

Unzip the code and place in the any folder.

### Prerequisites

1. dotnet core 3.0 sdk is required to building and running the code.

2. Before running code add app_id  and app_key in appsettings.json file present in RoadStatus folder. api_url is also configurable. 

3. Before running unit test, add app_id  and app_key in some ValidAppId() and ValidAppKey() respectively.And it should be same as entered in appsettings.json file.


### Building and Running the code

This can be done by 3 ways.

1) powershell command prompt: Traverse to RoadStatus folder and open PS command prompt. Type "dotnet build" to build the code. Type "dotnet run" to run the code. Type "dotnet run a1" to pass command line argument a1.type "echo $lastexitcode" to get last exit status code.

2)VS code: Traverse to RoadStatus folder and type "code . in command prompt" to open vs code. VS code should be preinstall. click on terminal menu and select new terminal. Type "dotnet build" to build the code. Type "dotnet run" to run the code. Type "dotnet run a1" to pass command line argument a1.type "echo $lastexitcode" to get last exit status code.

3)Visual studio: open RoadStatus.sln folder in vs. Right click on RoadStatus solution and select build solution. Now move to ~RoadStatus\bin\Debug\netcoreapp3.0 folder and in ps command prompt type "dotnet run a1" to pass command line argument a1.type "echo $lastexitcode" to get last exit status code.

## Running the tests

This can be done by 3 ways.

1) powershell command prompt: Traverse to NUnitTestRoadStatus folder and open PS command prompt. Type "dotnet build" to build the code. Type "dotnet test" to run the code. 

2)VS code: Traverse to RoadStatus folder and type "code . in command prompt" to open vs code. VS code should be preinstall. click on terminal menu and select new terminal. Type "dotnet build" to build the code. Type "dotnet test" to run the code.

3)Visual studio: open RoadStatus.sln folder in vs.Go to test menu select "run all tests" options.Test result can be seen in test explorer.


## Authors

suman kumar (sumankumar26@hotmail.com)

## License

This project is doesn't required any license to run.


