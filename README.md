# Net.Core Logging
Two examples of logging in ASP.Net Core.
At first, in program.cs file add the following code to set logging (this is my setting):

```
public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.SetMinimumLevel(LogLevel.Trace);
            logging.AddDebug();
            logging.AddEventSourceLogger();
        })
        .UseStartup<Startup>();
```

Now you can decide which provider to use:

* NLog

After installing the NuGet [package](https://www.nuget.org/packages/NLog/).
Edit nlog.config file to set the local file path ("D:\" in my case).
In the main procedure, instantiate the NLog, by indicating the Nlog config file:

```
  var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
  
```

The logging file will be saved in the path you set in the config file. 



* Elmah

After installing the NuGet [package](https://www.nuget.org/packages/elmah/)

add in configure method in startup.cs the following instruction:

```
app.UseElmah();
```

the link [https://yoururl/elmah](https://yoururl/elmah) is available to list logging.

