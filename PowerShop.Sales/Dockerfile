#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PowerShop.Sales/PowerShop.Sales.csproj", "PowerShop.Sales/"]
RUN dotnet restore "PowerShop.Sales/PowerShop.Sales.csproj"
COPY . .
WORKDIR "/src/PowerShop.Sales"
RUN dotnet build "PowerShop.Sales.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PowerShop.Sales.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PowerShop.Sales.dll"]