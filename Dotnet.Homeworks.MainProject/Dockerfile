FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS prepare-restore-files
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet tool install --global --no-cache dotnet-subset --version 0.3.1
WORKDIR ./
COPY . .
RUN dotnet subset restore "Dotnet.Homeworks.MainProject/Dotnet.Homeworks.MainProject.csproj" --root-directory ./ --output restore_subset/

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR ./
COPY --from=prepare-restore-files ./restore_subset .
RUN dotnet restore "Dotnet.Homeworks.MainProject/Dotnet.Homeworks.MainProject.csproj"

COPY . .
WORKDIR "./Dotnet.Homeworks.MainProject"
RUN dotnet build "Dotnet.Homeworks.MainProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dotnet.Homeworks.MainProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish ./
ENTRYPOINT ["dotnet", "Dotnet.Homeworks.MainProject.dll"]
