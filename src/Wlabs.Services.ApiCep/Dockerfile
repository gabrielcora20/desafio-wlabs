FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 8080

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Wlabs.Services.ApiCep/*.csproj ./Wlabs.Services.ApiCep/
COPY Wlabs.Services.ViaCep/*.csproj ./Wlabs.Services.ViaCep/
COPY Wlabs.Infra.Data/*.csproj ./Wlabs.Infra.Data/
COPY Wlabs.Infra.CrossCutting.IoC/*.csproj ./Wlabs.Infra.CrossCutting.IoC/
COPY Wlabs.Infra.CrossCutting.Bus/*.csproj ./Wlabs.Infra.CrossCutting.Bus/ 
COPY Wlabs.Infra.CrossCutting.Json/*.csproj ./Wlabs.Infra.CrossCutting.Json/ 
COPY Wlabs.Domain/*.csproj ./Wlabs.Domain/ 
COPY Wlabs.Application/*.csproj ./Wlabs.Application/ 
#

RUN dotnet restore	
#
# copy everything else and build app
COPY Wlabs.Services.ViaCep/. ./Wlabs.Services.ViaCep/
COPY Wlabs.Services.ApiCep/. ./Wlabs.Services.ApiCep/
COPY Wlabs.Infra.Data/. ./Wlabs.Infra.Data/
COPY Wlabs.Infra.CrossCutting.IoC/. ./Wlabs.Infra.CrossCutting.IoC/ 
COPY Wlabs.Infra.CrossCutting.Bus/. ./Wlabs.Infra.CrossCutting.Bus/ 
COPY Wlabs.Infra.CrossCutting.Json/. ./Wlabs.Infra.CrossCutting.Json/ 
COPY Wlabs.Domain/. ./Wlabs.Domain/ 
COPY Wlabs.Application/. ./Wlabs.Application/ 
#
WORKDIR /app/Wlabs.Services.ApiCep
RUN dotnet publish -c Release -o out 
#

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS final
WORKDIR /app
COPY --from=build /app/Wlabs.Services.ApiCep/out .
ENTRYPOINT ["dotnet", "Wlabs.Services.ApiCep.dll"]