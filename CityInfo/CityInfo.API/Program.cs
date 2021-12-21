using CityInfo.API;
using Microsoft.AspNetCore;

var builder = WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
var app = builder.Build();

app.Run();
