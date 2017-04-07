FROM microsoft/aspnetcore

RUN mkdir /app
COPY /SimpleBankApplication/bin/Release/netcoreapp1.1/publish /app/
WORKDIR /app

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet", "SimpleBankApplication.dll"]