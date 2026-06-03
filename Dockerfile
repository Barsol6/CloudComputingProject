# syntax=docker/dockerfile:1.4

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS base
LABEL org.opencontainers.image.authors="Bartosz Solyga"
LABEL org.opencontainers.image.title="Cloud Computing Project"
USER app
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
HEALTHCHECK --interval=30s --timeout=5s --start-period=10s --retries=3 \
  CMD wget --no-verbose --tries=1 --spider http://localhost:8080/ || exit 1

FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
RUN apk add --no-cache git openssh-client
RUN mkdir -p -m 0700 ~/.ssh && ssh-keyscan github.com >> ~/.ssh/known_hosts
WORKDIR /src

RUN git clone https://github.com/Barsol6/CloudComputingProject.git .

WORKDIR /src/CloudComputingProject

RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages dotnet restore "CloudComputingProject.csproj"
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages dotnet build "CloudComputingProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages dotnet publish "CloudComputingProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudComputingProject.dll"]
