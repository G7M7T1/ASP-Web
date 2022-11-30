using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);


// If you need change to other root folder
/*var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "myroot"
});*/


var app = builder.Build();

// https://localhost:7046/logo.png
app.UseStaticFiles();


// If you need more root folder to give static file
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "otherroot"))
});


app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context => { await context.Response.WriteAsync("Hello Index"); });

});

app.MapGet("/", () => "Hello World!");

app.Run();
