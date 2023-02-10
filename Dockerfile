FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CodingLibraryDSR.csproj", "./"]
RUN dotnet restore "CodingLibraryDSR.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "CodingLibraryDSR.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CodingLibraryDSR.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CodingLibraryDSR.dll"]
