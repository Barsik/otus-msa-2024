FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
WORKDIR /app
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /source
COPY ["Obavi.csproj", "Obavi/"]
RUN dotnet restore "Obavi/Obavi.csproj"
COPY . ./Obavi
WORKDIR "/source/Obavi"
RUN dotnet build "Obavi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Obavi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
#ENV ASPNETCORE_URLS="http://localhost:8000"
ENV ASPNETCORE_HTTP_PORTS=8000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Obavi.dll"]
