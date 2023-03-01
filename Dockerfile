FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /src

COPY ./src .

RUN dotnet publish /src/PoKey.CMD/PoKey.CMD.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /src

COPY --from=build-env /src/out .

ENTRYPOINT ["dotnet", "PoKey.CMD.dll"]