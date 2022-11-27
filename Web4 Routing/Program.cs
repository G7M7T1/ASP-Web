var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("map1", async (context) => { await context.Response.WriteAsync("Hello In Map 1"); });
    endpoints.Map("map2", async (context) => { await context.Response.WriteAsync("Hello In Map 2"); });

    endpoints.MapGet("mg", async (context) => { await context.Response.WriteAsync("Hello In MapGet"); });
    endpoints.MapPost("mp", async (context) => { await context.Response.WriteAsync("Hello In MapPost"); });

    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

        await context.Response.WriteAsync($"{fileName} - {extension}");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"You are in {context.Request.Path}");
});

app.Run();
