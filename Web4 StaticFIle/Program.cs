var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// https://localhost:7046/logo.png
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context => { await context.Response.WriteAsync("Hello Index"); });
});

app.MapGet("/", () => "Hello World!");

app.Run();
