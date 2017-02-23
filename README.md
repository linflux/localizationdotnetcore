# LocalizationDotNetCore
Use the sample Microsoft Localization docs to show a bug on Docker Linux.

I have an ASP.NET Core Web API (version 1.1) with use of Resources files for Localization/Globalization
like Microsoft Docs ASP.NET Core - Globalization and localization explains.
On Windows it runs OK, but in Linux (via Docker local) the resources are not found.

Like the article used in the docs article, Localization.StarterWeb project.
I clone that repository, create a dockerfile, build and run.

Link for Microsft ASP.NET Core Localization Documentation:
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization

Link for orignal sample repository:
https://github.com/aspnet/entropy

Link for the issue on ASP.NET Localization:
https://github.com/aspnet/Localization/issues/314



Looks like the issue is on the Controller with IStringLocalizer because in Views (not my Web API case) the localizer works partially, like you see on images above.

**Running on Windows 10:**
![Running on Windows 10](https://cloud.githubusercontent.com/assets/2443704/22078908/e9c5397e-dda0-11e6-8614-78aaa3026d61.PNG)

**Running on Linux Docker:**
![Running on Docker container](https://cloud.githubusercontent.com/assets/2443704/22078973/43e0ef16-dda1-11e6-8204-f3cefdbe4c8b.PNG)
