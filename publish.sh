#!/usr/bin/env bash

if [ -d "dist" ]; then
    echo "------->resetting dist
"
    rm -rf dist
fi

echo "------->building react app...
"
cd app && npm run build
cd ..

echo "------->Publishing api to dist...
"

cd api/src && dotnet publish -o ../../dist

echo "------->Published about to run exe
"
list="$(dotnet user-secrets list)"
passLine=$(echo "$list" | grep "Email:Password")
emailLine=$(echo "$list" | grep "Email:Address")

password="${passLine/Email:Password/""}"
email=${emailLine/Email:Address/""}

cd ../..

export Email__Password="$password"
export Email__Address="$email"

cd dist && ./wedding-api.exe
cd ..