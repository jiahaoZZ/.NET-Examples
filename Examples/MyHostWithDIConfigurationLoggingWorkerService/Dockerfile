FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MyHostWithDIConfigurationLoggingWorkerService/MyHostWithDIConfigurationLoggingWorkerService.csproj", "MyHostWithDIConfigurationLoggingWorkerService/"]
RUN dotnet restore "MyHostWithDIConfigurationLoggingWorkerService/MyHostWithDIConfigurationLoggingWorkerService.csproj"
COPY . .
WORKDIR "/src/MyHostWithDIConfigurationLoggingWorkerService"
RUN dotnet build "MyHostWithDIConfigurationLoggingWorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyHostWithDIConfigurationLoggingWorkerService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyHostWithDIConfigurationLoggingWorkerService.dll"]
