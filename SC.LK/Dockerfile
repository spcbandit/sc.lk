FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED "true"
ARG ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT $ASPNETCORE_ENVIRONMENT
#ENV ASPNETCORE_URLS="https://0.0.0.0:7247;http://0.0.0.0:5247"
COPY . ./
RUN mkdir -p publish/
RUN dotnet restore --interactive
RUN dotnet build --configuration Release
RUN dotnet publish --configuration Release --output publish/ --verbosity normal

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED "true"
ARG ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT $ASPNETCORE_ENVIRONMENT
#ENV ASPNETCORE_URLS="https://0.0.0.0:7247;http://0.0.0.0:5247"
COPY --from=build /app/publish .
COPY --from=build /app/SC.LK/*.txt ./
ENTRYPOINT ["dotnet", "SC.LK.dll"]
