@echo off
cd AutoMapperError.Shared
dotnet ef database update --startup-project ../AutoMapperError/AutoMapperError.csproj
cd ..