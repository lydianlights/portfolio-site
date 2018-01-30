# Portfolio Site

#### _Code review project for Epicodus .NET week 3_

#### _**By Rane Fields**_

## Setup/Installation Requirements

* Clone/download the project
* Install `.NET Core 1.1.2`. You can get it  [here](https://github.com/dotnet/core/blob/master/release-notes/download-archives/1.1.2-download.md).
* A mySQL server is required for this project. If you have no mySQL server environment on your computer, you can get MAMP [here](https://www.mamp.info/en/downloads/).
* Configure your server to listen on port 8889 and start it.
* Open the main project directory `./PortfolioSite` using terminal or powershell.
* Run `$ dotnet restore` to fetch the project dependencies.
* Run `$ npm install` to fetch the project node packages.
* Run `$ npm install gulp -g` install gulp.
* Run `$ dotnet ef database update --context ApplicationDbContext` to build the project database.
* Run `$ dotnet run` to start the server.

## Technologies Used

* This project is powered by [ASP .NET Core v1.1.2](https://docs.microsoft.com/en-us/aspnet/core/).
* This project uses [Entity Framework Core v1.1.2](https://github.com/aspnet/EntityFrameworkCore) as an ORM database manager.
* This project depends on [NodeJs](https://nodejs.org/en/)
* This project uses [Gulp](https://gulpjs.com/) as a build manager

## Known Bugs

* Project is missing styling for some sections
* Admin page allows anyone to add themself as admin
* Password fields aren't passworded

Copyright (c) 2018 **_Rane Fields_**
