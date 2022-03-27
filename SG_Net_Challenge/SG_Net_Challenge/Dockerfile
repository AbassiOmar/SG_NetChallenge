#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1809 AS build
WORKDIR /src
COPY ["SG_Net_Challenge/SG_Net_Challenge.csproj", "SG_Net_Challenge/"]
COPY ["SG_NET_Challenge.Validation/SG_NET_Challenge.Validation.csproj", "SG_NET_Challenge.Validation/"]
COPY ["SG_Net_Challenge.Domain/SG_Net_Challenge.Domain.csproj", "SG_Net_Challenge.Domain/"]
COPY ["SG_Net_Challenge.Command/SG_Net_Challenge.Command.csproj", "SG_Net_Challenge.Command/"]
COPY ["SG_Net_Challenge.Query/SG_Net_Challenge.Query.csproj", "SG_Net_Challenge.Query/"]
COPY ["SG_Net_Challenge.Service/SG_Net_Challenge.Service.csproj", "SG_Net_Challenge.Service/"]
RUN dotnet restore "SG_Net_Challenge/SG_Net_Challenge.csproj"
COPY . .
WORKDIR "/src/SG_Net_Challenge"
RUN dotnet build "SG_Net_Challenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SG_Net_Challenge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SG_Net_Challenge.dll"]