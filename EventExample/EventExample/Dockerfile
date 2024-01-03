FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EventExample/EventExample.csproj", "EventExample/"]
RUN dotnet restore "EventExample/EventExample.csproj"
COPY . .
WORKDIR "/src/EventExample"
RUN dotnet build "EventExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventExample.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventExample.dll"]
