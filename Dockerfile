#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Cti.LaboratorioGeneticaForense.BioSample.Api/Cti.LaboratorioGeneticaForense.BioSample.Api.csproj", "src/Cti.LaboratorioGeneticaForense.BioSample.Api/"]
RUN dotnet restore "src/Cti.LaboratorioGeneticaForense.BioSample.Api/Cti.LaboratorioGeneticaForense.BioSample.Api.csproj"
COPY . .
WORKDIR "/src/Cti.LaboratorioGeneticaForense.BioSample.Api"
RUN dotnet build "Cti.LaboratorioGeneticaForense.BioSample.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cti.LaboratorioGeneticaForense.BioSample.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cti.LaboratorioGeneticaForense.BioSample.Api.dll"]