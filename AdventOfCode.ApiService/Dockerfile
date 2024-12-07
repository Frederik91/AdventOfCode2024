# FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
# WORKDIR /App

# # Copy everything
# COPY . ./

# # Install clang
# RUN apt update
# RUN apt install -y clang zlib1g-dev

# # Restore as distinct layers
# RUN dotnet restore
# # Build and publish a release
# RUN dotnet publish -c Release -r linux-arm64 -o out

# # Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:9.0
# WORKDIR /App
# COPY --from=build-env /App/out .
# ENTRYPOINT ["dotnet", "AdventOfCode.ApiService.exe"]

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Install NativeAOT build prerequisites
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
       clang zlib1g-dev

WORKDIR /source

COPY . .
RUN dotnet publish -o /app AdventOfCode.ApiService.csproj

FROM mcr.microsoft.com/dotnet/runtime-deps:9.0
EXPOSE 8080
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["/app/AdventOfCode.ApiService"]