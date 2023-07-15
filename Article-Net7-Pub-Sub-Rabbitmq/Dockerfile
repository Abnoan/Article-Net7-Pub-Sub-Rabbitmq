#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Article-Net7-Pub-Sub-Rabbitmq/Article-Net7-Pub-Sub-Rabbitmq.csproj", "Article-Net7-Pub-Sub-Rabbitmq/"]
RUN dotnet restore "Article-Net7-Pub-Sub-Rabbitmq/Article-Net7-Pub-Sub-Rabbitmq.csproj"
COPY . .
WORKDIR "/src/Article-Net7-Pub-Sub-Rabbitmq"
RUN dotnet build "Article-Net7-Pub-Sub-Rabbitmq.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Article-Net7-Pub-Sub-Rabbitmq.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Article-Net7-Pub-Sub-Rabbitmq.dll"]