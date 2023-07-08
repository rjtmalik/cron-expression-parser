FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore ./CronEval.Lib.Contracts/CronEval.Lib.Contracts.csproj
RUN dotnet restore ./CronEval.Lib/CronEval.Lib.csproj
RUN dotnet restore ./ConsoleApp/ConsoleApp.csproj
RUN dotnet restore ./CronEval.Lib.Tests/CronEval.Lib.Tests.csproj

# Build and publish a release
RUN dotnet publish ./ConsoleApp/ConsoleApp.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "ConsoleApp.dll"]