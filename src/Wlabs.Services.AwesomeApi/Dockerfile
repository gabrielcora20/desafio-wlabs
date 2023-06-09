FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 8080

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Wlabs.Services.Core/*.csproj ./Wlabs.Services.Core/
COPY Wlabs.Services.ApiCep/*.csproj ./Wlabs.Services.ApiCep/
COPY Wlabs.Services.ViaCep/*.csproj ./Wlabs.Services.ViaCep/
COPY Wlabs.Services.AwesomeApi/*.csproj ./Wlabs.Services.AwesomeApi/
COPY Wlabs.Services.Usuario/*.csproj ./Wlabs.Services.Usuario/
COPY Wlabs.Services.Auth/*.csproj ./Wlabs.Services.Auth/
COPY Wlabs.Infra.Data/*.csproj ./Wlabs.Infra.Data/
COPY Wlabs.Infra.CrossCutting.IoC/*.csproj ./Wlabs.Infra.CrossCutting.IoC/
COPY Wlabs.Infra.CrossCutting.Bus/*.csproj ./Wlabs.Infra.CrossCutting.Bus/ 
COPY Wlabs.Infra.CrossCutting.Json/*.csproj ./Wlabs.Infra.CrossCutting.Json/ 
COPY Wlabs.Infra.CrossCutting.Http/*.csproj ./Wlabs.Infra.CrossCutting.Http/ 
COPY Wlabs.Infra.CrossCutting.Redis/*.csproj ./Wlabs.Infra.CrossCutting.Redis/ 
COPY Wlabs.Infra.CrossCutting.Jwt/*.csproj ./Wlabs.Infra.CrossCutting.Jwt/ 
COPY Wlabs.Infra.CrossCutting.Encryption/*.csproj ./Wlabs.Infra.CrossCutting.Encryption/ 
COPY Wlabs.Domain/*.csproj ./Wlabs.Domain/ 
COPY Wlabs.Application/*.csproj ./Wlabs.Application/ 
#

RUN dotnet restore	
#
# copy everything else and build app
COPY Wlabs.Services.Core/. ./Wlabs.Services.Core/
COPY Wlabs.Services.ViaCep/. ./Wlabs.Services.ViaCep/
COPY Wlabs.Services.ApiCep/. ./Wlabs.Services.ApiCep/
COPY Wlabs.Services.AwesomeApi/. ./Wlabs.Services.AwesomeApi/
COPY Wlabs.Services.Usuario/. ./Wlabs.Services.Usuario/
COPY Wlabs.Services.Auth/. ./Wlabs.Services.Auth/
COPY Wlabs.Infra.Data/. ./Wlabs.Infra.Data/
COPY Wlabs.Infra.CrossCutting.IoC/. ./Wlabs.Infra.CrossCutting.IoC/ 
COPY Wlabs.Infra.CrossCutting.Bus/. ./Wlabs.Infra.CrossCutting.Bus/ 
COPY Wlabs.Infra.CrossCutting.Json/. ./Wlabs.Infra.CrossCutting.Json/ 
COPY Wlabs.Infra.CrossCutting.Http/. ./Wlabs.Infra.CrossCutting.Http/ 
COPY Wlabs.Infra.CrossCutting.Redis/. ./Wlabs.Infra.CrossCutting.Redis/ 
COPY Wlabs.Infra.CrossCutting.Jwt/. ./Wlabs.Infra.CrossCutting.Jwt/ 
COPY Wlabs.Infra.CrossCutting.Encryption/. ./Wlabs.Infra.CrossCutting.Encryption/ 
COPY Wlabs.Domain/. ./Wlabs.Domain/ 
COPY Wlabs.Application/. ./Wlabs.Application/ 
#
WORKDIR /app/Wlabs.Services.AwesomeApi
RUN dotnet publish -c Release -o out 
#

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS final
WORKDIR /app
COPY --from=build /app/Wlabs.Services.AwesomeApi/out .
ENTRYPOINT ["dotnet", "Wlabs.Services.AwesomeApi.dll"]