[![NuGet Badge](https://buildstats.info/nuget/Eisk.WebApi)](https://www.nuget.org/packages/Eisk.WebApi/)  [![Build status](https://dev.azure.com/EiskOps/Eisk/_apis/build/status/Eisk-WebApi-TemplatePack-CI)](https://dev.azure.com/EiskOps/Eisk/_build/latest?definitionId=3) [![BuitlWithDot.Net shield](https://builtwithdot.net/project/334/eisk/badge)](https://builtwithdot.net/project/334/eisk)  
...

EISK makes it easy to write scalable and secured web api on top of Microsoft's new cutting edge .net based technologies. 

With an optional set of customizable utility classes, samples and tools, it lets you creating new web api straight away without wide technical experience or learning curve.

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a [star](https://github.com/EISK/eisk.webapi). Thanks!

![eisk web api](https://github.com/EISK/eisk/blob/master/eisk-webapi-small.png)

## Core Technologies

* Platform: [.NET Framework 6.0](https://devblogs.microsoft.com/dotnet/announcing-net-6/) - The Fastest .NET Yet!
* Web Framework: ASP.NET Web API 
* ORM Framework: Entity Framework
* Programming Language: C#

## Sample Use Case

Using a simple data entity 'Employee', EISK shows how we can build scalable web api's easily along with addressing real-world domain and business use cases, including: 

* [C]reating a new employee record
* [R]ead existing employee records
* [U]pdate an existing employee record
* [D]elete an existing employee record

## Dev Features

You can build your own RESTful web api using EISK's Visual Studio and ASP.NET Web API project template. 

The template includes (but not limited to), project structure and all utility classes mentioned below to enable building modern cloud-aware RESTful APIs.

* **Clean Architecture** based implementation
* **Swagger/OpenAPI** based RESTful Web API, including resuable base classes
* **Base classes** for common CRUD functionalities and testing for logical layers (i.e. controller, domain, data layers)
* **Utility classes** to generate real-world test data
* Support for database integration tests with both in-memory database and SQL server

## QuickStart Guide

Before installing EISK, all you need to have the following Visual Studio version installed.

* Visual Studio 2022 ([Free](https://visualstudio.microsoft.com/vs/community/) Community Edition or higher)

Getting started with EISK Web Api is pretty easy. 

You can either [clone](https://github.com/EISK/eisk.webapi.git) from github or simply run the following `dotnet new` command in command prompt to create a new project from EISK:

* Command to install EISK template in your machine: `dotnet new -i eisk.webapi`
* Command to create a new project: `dotnet new eiskwebapi -n Eisk`

Once the contents are available, just open the created solution, select "Eisk.WebApi" as startup project and press F5!

That's it!

### How about Old Versions?

If you want to continue using one of the older versions of EISK, check the [releases](https://github.com/EISK/eisk.webapi/releases) page for specific instructions to install and use older versions of EISK.

## What's Next?

After running the created project successfully, you'll get an understanding about how the sample use case has been used to explore cutting edge technologies for building a web api.

Next - you can try some hands-on experience by creating your own api on top of your custom entity and see how quickly you can roll out an enterprise quality web api with similar quality and productivity. 

Utilities and code samples as provided in EISK have intentionally been designed to be self explaining. You may still want to get deeper understanding by exploring the documentations:

* [Live Demo](https://eisk-webapi.azurewebsites.net)
* [Hands-on Walk-through](https://eisk.github.io/docs/webapi/application-development/handson-walkthrough-create-service-api.html)
* [Logical Layer Architecture](https://eisk.github.io/docs/webapi/architecture/logical-layers.html)
* [Technology Stack](https://eisk.github.io/docs/webapi/technical-reference/technology-stack.html)

## Questions?

Should you have any questions or need any help to implement new cool features, you can [ask](https://stackoverflow.com/questions/ask?tags=eisk,webapi,asp.net-core&title=In%20EISK,%20How%20Do%20We%20..) in StackOverflow community with tag [eisk](https://stackoverflow.com/questions/tagged/eisk) and get prompt response.
