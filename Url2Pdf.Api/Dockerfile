FROM microsoft/aspnetcore:2.0.6 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build

WORKDIR /src
COPY Url2Pdf.sln ./
COPY Url2Pdf.Api/Url2Pdf.Api.csproj Url2Pdf.Api/
RUN dotnet restore -nowarn:msb3202,nu1503

COPY . .
WORKDIR /src/Url2Pdf.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Url2Pdf.Api.dll"]
