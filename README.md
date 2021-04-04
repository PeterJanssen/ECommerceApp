# ECommerceApp

## Description

### Features

#### Backend
#### Frontend

## Visuals

### Usage

## First steps before running the app for the first time

1) "npm install" in the client folder
2) "dotnet restore" in root folder
3) create appsettings.json in API folder and copy content of appsettings.Development.json into it, add or change keys for Stripe and SendGrid
4) "docker-compose up --detach" in the root folder
5) add server.crt and server.key (self signed or by a CA) and place them in client/ssl

## Commands

### Creating the docker containers

In the root folder run the following command

`docker-compose up --detach`

Creates redis and redis database container for caching purposes

Creates adminer and redis commander container for viewing the databases

Login and passwords are defined in docker-compose.yml

### Creating and seeding the databases

In the API folder run the following command

`dotnet watch run`

Creates and/or seeds the databases if they are non-existent

### Adding migration

In any folder run the following command, replace the text between #

`dotnet ef migrations add "#Name of migration#" -p .\Infrastructure\ -s .\API\ -c StoreContext -o Data/Migrations`

### Running the backend

In the API folder run the following command

`dotnet watch run`

### Running the frontend

In the client folder run the following command

`ng serve`

### Building the frontend to the wwwroot folder

In the client folder run the following command

`ng build --prod`

### Publishing the app

In the root folder run the following command

`dotnet publish -c Release -o publish skinet.sln`

### Listening to the Stripe CLI webhook

In any terminal run the following command, Stripe CLI is needed

`stripe listen -f https://localhost:5001/api/payments/webhook -e payment_intent.succeeded,payment_intent.payment_failed`

## Roadmap

### Frontend
### Backend
### Front/Backend

## Roadmap_Done

### Frontend

### Backend

### Front/Backend

## Current_Bugs

## Fixed_Bugs

## Contributions
