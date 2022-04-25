[![Build status](https://dev.azure.com/EiskOps/Eisk/_apis/build/status/Eisk-WebApi-TemplatePack-CI)](https://dev.azure.com/EiskOps/Eisk/_build/latest?definitionId=3) [![BuitlWithDot.Net shield](https://builtwithdot.net/project/334/eisk/badge)](https://builtwithdot.net/project/334/eisk)

[![Build status](https://dev.azure.com/EiskOps/Eisk/_apis/build/status/Eisk-WebApi-TemplatePack-CI)](https://dev.azure.com/EiskOps/Eisk/_build/latest?definitionId=3) [![BuitlWithDot.Net shield](https://builtwithdot.net/project/334/eisk/badge)](https://builtwithdot.net/project/334/eisk)

# Getting Started with EISK Web Api

EISK makes it easy to write scalable and secured web api on top of Microsoft's new cutting edge .net core technologies. 

With an optional set of customizable utility classes, samples and tools, it lets you creating new web api straight away without wide technical experience or learning curve.

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a [star](https://github.com/EISK/eisk.webapi). Thanks!

![eisk web api](https://github.com/EISK/eisk/blob/master/eisk-webapi-small.png)

## Sample Use Case

Using a simple table entity 'Employee' it demonstrates all aspect of web development including layered architecture following DDD, micro service, unit and integration tests, building and deploying in cloud environment. 

Here is a simple CRUD use case illustrated in the default template:

* [C]reating a new employee record
* [R]ead existing employee records
* [U]pdate an existing employee record
* [D]elete existing employee records

### Architecture Overview

* Clean Architecture

## Core Technology Areas

* [.NET Framework 6.0](https://devblogs.microsoft.com/dotnet/announcing-net-6/) - The Fastest .NET Yet
* ASP.NET Core (Web Api)
* Entity Framework Core
* C# Programming Language
* Visual Studio

## System Requirements (Development)

* Visual Studio 2022 ([Free](https://visualstudio.microsoft.com/vs/community/) Community Edition or higher)

## QuickStart Guide

Getting started with EISK Web Api is pretty easy. 

You can either [clone](https://github.com/EISK/eisk.webapi.git) from github or simply run the following `dotnet new` command in command prompt to create a new project from EISK:

* Command to install EISK template in your machine: `dotnet new -i eisk.webapi`
* Command to create a new project: `dotnet new eiskwebapi -n Eisk`

Once the contents are available, just open the created solution, select "Eisk.WebApi" as startup project and press F5!

That's it!

## What's Next?

After running the created project successfully, you'll get an understanding about how the sample use case has been used to explore cutting edge technologies for building a web api.

Next - you can try some hands-on experience by creating your own api on top of your custom entity and see how quickly you can roll out an enterprise quality web api with similar quality and productivity. 

Utilities and code samples as provided in EISK have intentionally been designed to be self explaining. You may still want to get deeper understanding by exploring the documentations:

* [Live Demo](https://eisk-webapi.azurewebsites.net)
* [Hands-on Walk-through](https://eisk.github.io/docs/webapi/application-development/handson-walkthrough-create-service-api.html)
* [Logical Layer Architecture](https://eisk.github.io/docs/webapi/architecture/logical-layers.html)
* [Technology Stack](https://eisk.github.io/docs/webapi/technical-reference/technology-stack.html)
