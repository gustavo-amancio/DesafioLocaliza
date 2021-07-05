FROM mcr.microsoft.com/dotnet/core/runtime:2.1-stretch-slim AS base
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore 

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/runtime:2.1
#FROM mcr.microsoft.com/dotnet/core/aspnet:2.1


WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "Console_Validador_Numeros.dll"]