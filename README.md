# LocalizationDotNetCore
Use the sample Microsoft Localization docs to show a bug on Docker Linux.

I have an ASP.NET Core Web API (version 1.1) with use of Resources files for Localization/Globalization
like Microsoft Docs ASP.NET Core - Globalization and localization explains.
On Windows it runs OK, but in Linux (via Docker local) the resources are not found.

Like the article used in the docs article, Localization.StarterWeb project.
I clone the repo from that repository, create a dockerfile, build and run.

Link for sample repository:
https://github.com/aspnet/entropy

Link for the issue on ASP.NET Localization:
https://github.com/aspnet/Localization/issues/314
