FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build

WORKDIR /app

COPY *.sln .
COPY ./Transactions.Api/Transactions.Api.csproj ./Transactions.Api/
COPY ./Transactions.Domain/*.csproj ./Transactions.Domain/
COPY ./Transactions.Tests/*.csproj ./Transactions.Tests/

RUN dotnet restore

COPY . .

RUN dotnet build

FROM build AS publish

WORKDIR /app/Transactions.Api

RUN dotnet publish -o out -c Release

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS runtime
WORKDIR /app

COPY --from=publish /app/Transactions.Api/out ./

EXPOSE 80

ENTRYPOINT ["dotnet", "Transactions.Api.dll"]