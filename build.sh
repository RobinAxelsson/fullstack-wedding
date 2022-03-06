#!/usr/bin/env bash
echo "-------> Adding dependencies:
"
cd app && yarn
echo "Start build..."

echo "------->building react app...
"
npm run build
cd ..

echo "------->Publishing api to $1...
"

cd api/src && dotnet publish -o "$1"

cd ../..

mkdir $1/wwwroot

echo "------->Moving build
"
cp -r app/build/*  $1/wwwroot