var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["MyKey"] = "This is My Key";
    // context.Response.StatusCode = 400;

    context.Response.Headers["Content-type"] = "text/html";

    if (context.Request.Headers.ContainsKey("User-Agent"))
    {
        string userAgent = context.Request.Headers["User-Agent"];
        await context.Response.WriteAsync(userAgent);
    }

    await context.Response.WriteAsync("Hello This is 400 Error");
});

app.Run();