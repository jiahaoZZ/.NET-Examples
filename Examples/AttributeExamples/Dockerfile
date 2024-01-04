FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AttributeExamples/AttributeExamples.csproj", "AttributeExamples/"]
RUN dotnet restore "AttributeExamples/AttributeExamples.csproj"
COPY . .
WORKDIR "/src/AttributeExamples"
RUN dotnet build "AttributeExamples.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AttributeExamples.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AttributeExamples.dll"]
