FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

COPY ./src /src/
WORKDIR /src/

RUN dotnet restore

FROM build AS publish
RUN dotnet publish -c release --property PublishDir=/app --no-restore /p:TreatWarningsAsErrors=true /warnaserror -warnaserror

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app ./
ENTRYPOINT ["dotnet", "Actions.Instance.dll"]