#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Catcher.Web/Catcher.Web.csproj", "src/Catcher.Web/"]
COPY ["src/Catcher.Service/Catcher.Service.csproj", "src/Catcher.Service/"]
COPY ["src/Catcher.Model/Catcher.Model.csproj", "src/Catcher.Model/"]
RUN dotnet restore "src/Catcher.Web/Catcher.Web.csproj"
COPY . .
WORKDIR "/src/src/Catcher.Web"
RUN dotnet build "Catcher.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catcher.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catcher.Web.dll"]