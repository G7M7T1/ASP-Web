using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Add Services Into IOC Container
builder.Services.AddSingleton<IcountriesService, CountriesService>();
builder.Services.AddSingleton<IPersonService, PersonsService>();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.Run();
