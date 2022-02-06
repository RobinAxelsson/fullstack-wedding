#!/usr/bin/env bash
echo "------->resetting dist
"
if [ -d "dist" ]; then
    rm -rf dist
fi

echo "------->building react app...
"
cd app && npm run build
cd ..

echo "------->Publishing api to dist...
"

cd api/src && dotnet publish -o ../../dist

list="$(dotnet user-secrets list)"
passLine=$(echo "$list" | grep "Email:Password")
emailLine=$(echo "$list" | grep "Email:Address")

cd ../..

if [ ! -d "./dist/wwwroot" ]; then
    echo Adding wwwroot
    mkdir dist/wwwroot
fi

echo "------->Moving build
"
cp -r app/build/*  dist/wwwroot

echo "------->Published about to run exe
"

password="${passLine/Email:Password/""}"
email=${emailLine/Email:Address/""}

export Email__Password="$password"
export Email__Address="$email"

cd dist && ./wedding-api.exe