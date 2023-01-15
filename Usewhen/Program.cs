var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// If ContainsKey has username will run
app.UseWhen(
    context => context.Request.Query.ContainsKey("username"),
    app =>
    {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Hello From Middleware UseWhen\n");
            await next();
        });
    });


app.Run(async context =>
{
    await context.Response.WriteAsync("Hello From App.Run");
});

app.Run();

// Link with Tag..
// Using Name Tag


// localhost:xxxx?username=xxxx