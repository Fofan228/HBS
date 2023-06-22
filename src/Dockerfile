FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HBS.Server/HBS.Server.csproj", "HBS.Server/"]
COPY ["HBS.Data/HBS.Data.csproj", "HBS.Data/"]
COPY ["HBS.Core/HBS.Core.csproj", "HBS.Core/"]
RUN dotnet restore "HBS.Server/HBS.Server.csproj"
COPY . .
WORKDIR "/src/HBS.Server"
RUN dotnet build "HBS.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HBS.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HBS.Server.dll"]
