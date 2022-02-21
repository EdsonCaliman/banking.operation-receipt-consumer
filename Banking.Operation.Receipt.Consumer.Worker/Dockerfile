#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
ENV TZ="America/Sao_Paulo"
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Banking.Operation.Receipt.Consumer.Worker/Banking.Operation.Receipt.Consumer.Worker.csproj", "Banking.Operation.Receipt.Consumer.Worker/"]
COPY ["Banking.Operation.Receipt.Consumer.CrossCutting.Ioc/Banking.Operation.Receipt.Consumer.CrossCutting.Ioc.csproj", "Banking.Operation.Receipt.Consumer.CrossCutting.Ioc/"]
COPY ["Banking.Operation.Receipt.Consumer.Infra.Data/Banking.Operation.Receipt.Consumer.Infra.Data.csproj", "Banking.Operation.Receipt.Consumer.Infra.Data/"]
COPY ["Banking.Operation.Receipt.Consumer.Domain/Banking.Operation.Receipt.Consumer.Domain.csproj", "Banking.Operation.Receipt.Consumer.Domain/"]
RUN dotnet restore "Banking.Operation.Receipt.Consumer.Worker/Banking.Operation.Receipt.Consumer.Worker.csproj"
COPY . .
WORKDIR "/src/Banking.Operation.Receipt.Consumer.Worker"
RUN dotnet build "Banking.Operation.Receipt.Consumer.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Banking.Operation.Receipt.Consumer.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Banking.Operation.Receipt.Consumer.Worker.dll"]