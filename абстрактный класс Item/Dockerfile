# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# В зависимости от операционной системы хост-компьютеров, которые будут выполнять сборку контейнеров или запускать их, может потребоваться изменить образ, указанный в инструкции FROM.
# Дополнительные сведения см. на странице https://aka.ms/containercompat

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/runtime:9.0-nanoserver-1809 AS base
WORKDIR /app


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:9.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["абстрактный класс Item/абстрактный класс Item.csproj", "абстрактный класс Item/"]
RUN dotnet restore "./абстрактный класс Item/абстрактный класс Item.csproj"
COPY . .
WORKDIR "/src/абстрактный класс Item"
RUN dotnet build "./абстрактный класс Item.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./абстрактный класс Item.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "абстрактный класс Item.dll"]