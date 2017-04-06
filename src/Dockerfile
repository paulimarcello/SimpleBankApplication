FROM microsoft/dotnet:latest

RUN mkdir /app
COPY . /app
WORKDIR /app

RUN dotnet restore
RUN dotnet publish --output /app/ --configuration Release

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet", "SimpleBankApplication.dll"]