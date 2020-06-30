FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

# copy and restore all dependencies
WORKDIR /src
COPY *.sln .
COPY DiscountJira.Api/*.csproj DiscountJira.Api/
COPY DiscountJira.Core/*.csproj DiscountJira.Core/
COPY DiscountJira.Infrastructure/*.csproj DiscountJira.Infrastructure/
COPY DiscountJira.Persistence/*.csproj DiscountJira.Persistence/
COPY DiscountJira.Test/*.csproj DiscountJira.Test/
RUN dotnet restore

# build the application
COPY . .
WORKDIR /src
RUN dotnet build -c Release -o /app

# create production version
FROM build-env AS publish
RUN dotnet publish -c Release -o /app

# run the app, must map outer port to 80 when called
# 
# docker run -d -p <PORT>:80 --name <NAME> discountjira
# 
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DiscountJira.Api.dll"]