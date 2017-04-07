#!/bin/bash

# this script should be executed in src/Vagrant machine.
dotnet restore
dotner build -c Release
dotnet publish -c Release

docker build -t paulimarcello/simplebankapplication:latest .