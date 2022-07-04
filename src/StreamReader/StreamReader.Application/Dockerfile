#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/StreamReader/StreamReader.Application/StreamReader.Application.csproj", "src/StreamReader/StreamReader.Application/"]
RUN dotnet restore "src/StreamReader/StreamReader.Application/StreamReader.Application.csproj"
COPY . .
WORKDIR "/src/src/StreamReader/StreamReader.Application"
RUN dotnet build "StreamReader.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StreamReader.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StreamReader.Application.dll"]