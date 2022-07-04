using MetaQuotes.IPSearch.Services;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
//builder.Services.AddResponseCaching(); // cache response answers
builder.Services.AddMvc();

/*
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
builder.Services.AddScoped<IMyDependency, MyDependency>();*/

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var readInfoService = new LoadService(app.Logger);
readInfoService.LoadFromFile(IMemoryCache cache);


app.Logger.LogInformation("Start application");
app.Run();
