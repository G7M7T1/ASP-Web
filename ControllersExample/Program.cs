using ControllersExample.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add single Controller
// builder.Services.AddTransient<HomeController>();

// Add All Controller
builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles();


/*// Old Way
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    // active all controller method
    endpoints.MapControllers();
});*/

// new way
app.MapControllers();

app.Run();
