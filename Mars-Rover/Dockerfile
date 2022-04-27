FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
COPY . /sln

RUN dotnet publish /sln/Mars-Rover.csproj -c Release -o /out

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY --from=build-env /out /app

ENTRYPOINT ["./Mars-Rover.exe"]


 