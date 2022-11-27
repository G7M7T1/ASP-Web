using Web2_middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomMiddleWare>();
var app = builder.Build();


// middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello One");
    await next(context); // call next to give context to next middleware
});


// middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello Two");
    await next(context); // call next to give context to next middleware
});


// middleware 3
app.UseMiddleware<CustomMiddleWare>();


// middleware 4
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Other Hello Message");
});

app.Run();
