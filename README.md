EISK makes it easy to write scalable and secured web api on top of Microsoft's new cutting edge .net core technologies. 

With an optional set of customizable utility classes, samples and tools, it lets you creating new web api straight away without wide technical experience or learning curve.

## Sample Use Case

Using a simple table entity 'Employee' it demonstrates all aspect of web development including layered architecture following DDD, micro service, unit and integration tests, building and deploying in cloud environment. 

Here is a simple CRUD use case illustrated in the default template:

* Creating a new employee record
* Read existing employee records
* Update an existing employee record
* Delete existing employee records

## Core Technology Areas

* ASP.NET Core (Web Api)
* Entity Framework Core 
* C# 
* Visual Studio 
* Azure App Services 

## System Requirements (Development)

* Visual Studio 2017 ([Free](https://visualstudio.microsoft.com/vs/community/) Community Edition or higher)

## QuickStart Guide

Getting started with EISK Web Api is pretty easy. 

You can either clone V8.0 from github:

`git clone -b V8.0 https://github.com/EISK/eisk.webapi.git`

Or simply run the following `dotnet new` command in command prompt to create a new project from EISK:

* Command to install EISK template in your machine: `dotnet new --install Eisk.WebApi::8.0.12`
* Command to create a new project: `dotnet new eiskwebapi -n Eisk`

Once the contents are available, just open the created solution, select "Eisk.WebApi" as startup project and press F5!

That's it!

## What's Next?

After running the created project successfully, you'll get an understanding about how the sample use case has been used to explore cutting edge technologies for building a web api.

Next - you can try some hands-on experience by creating your own api on top of your custom entity and see how quickly you can roll out an enterprise quality web api with similar quality and productivity. 

Utilities and code samples as provided in EISK have intentionally been designed to be self explaining. You may still want to get deeper understanding by exploring the documentations:

* [Live Demo](https://eiskwebapi.azurewebsites.net)
* [Hands-on Walk-through](https://eisk.github.io/eisk.webapi/docs/application-development/handson-walkthrough-create-service-api.html)
* [Logical Layer Architecture](https://eisk.github.io/eisk.webapi/docs/architecture/logical-layers.html)
* [Technology Stack](https://eisk.github.io/eisk.webapi/docs/technical-reference/technology-stack.html)
