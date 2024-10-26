using ContactManager.UI1.Middleware;
using ContactManager.UI1;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Serilog
builder.Host.UseSerilog((HostBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfiguration) => {

    loggerConfiguration
    .ReadFrom.Configuration(context.Configuration) 
    .ReadFrom.Services(services); 
});

builder.Services.ConfigureServices(builder.Configuration);


var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseExceptionHandlingMiddleware();
}

app.UseHsts();
app.UseHttpsRedirection();

app.UseSerilogRequestLogging();


app.UseHttpLogging();

if (builder.Environment.IsEnvironment("Test") == false)
    Rotativa.AspNetCore.RotativaConfiguration.Setup("wwwroot", wkhtmltopdfRelativePath: "Rotativa");

app.UseStaticFiles();


app.UseRouting(); 
app.UseAuthentication(); 
app.UseAuthorization(); 
app.MapControllers(); 

app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Home}/{action=Index}");

    endpoints.MapControllerRoute(
     name: "default",
     pattern: "{controller}/{action}/{id?}"
     );
});

app.Run();

public partial class Program { } 
