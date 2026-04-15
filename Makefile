# Root Makefile for ACE project

API_PATH=services/api-gateway-dotnet
API_PROJECT=$(API_PATH)/src/ACE.API/ACE.API.csproj
SOLUTION=$(API_PATH)/ACE.sln

.PHONY: clean restore build run dev

clean:
	cd $(API_PATH) && dotnet clean ACE.sln

restore:
	cd $(API_PATH) && dotnet restore ACE.sln

build:
	cd $(API_PATH) && dotnet build ACE.sln

run:
	cd $(API_PATH) && dotnet run --project src/ACE.API

dev: clean restore build run