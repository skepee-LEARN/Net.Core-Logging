# Net.Core Logging
Two examples of logging in ASP.Net Core.
At first, in program.cs file add the following code to set logging:

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


* Elmah

After installing the NuGet [package](https://www.nuget.org/packages/elmah/)

add in configure method in startup.cs the following instruction:

```
app.UseElmah();
```
