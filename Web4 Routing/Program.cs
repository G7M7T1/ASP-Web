using System;

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


    // default value
    endpoints.Map("person/{id=1}", async context =>
    {
        int num = Convert.ToInt32(context.Request.RouteValues["id"]);

        await context.Response.WriteAsync($"You Are In Person {num}");
    });


    // if value
    endpoints.Map("doc/{id?}", async context =>
    {
        if(context.Request.RouteValues.ContainsKey("id"))
        {
            int num = Convert.ToInt32(context.Request.RouteValues["id"]);

            await context.Response.WriteAsync($"You Are In Doc {num}");
        } 
        
        else
        {
            await context.Response.WriteAsync($"You Are In DOC");
        }
    });


    // int value
    endpoints.Map("num/{id:int?}", async context =>
    {
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            int num = Convert.ToInt32(context.Request.RouteValues["id"]);

            await context.Response.WriteAsync($"You Are In num {num}");
        }

        else
        {
            await context.Response.WriteAsync($"You Are In num /");
        }
    });


    // Guid like 960793F1-726F-4A1F-A992-28E1BE2FF88C
    endpoints.Map("citys/{cityid:guid}", async context =>
    {
        if (context.Request.RouteValues.ContainsKey("cityid"))
        {
            Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"]));

            await context.Response.WriteAsync($"You Are In city {cityId}");
        }

        else
        {
            await context.Response.WriteAsync($"You Are In City /");
        }
    });


    // minlength(3)  maxlength(8)  length(3,8)  range(1,20000)
    endpoints.Map("tool/{toolName:minlength(3):maxlength(8)=ssrt}", async context =>
    {
        string? toolName = Convert.ToString(context.Request.RouteValues["toolName"]);
        await context.Response.WriteAsync($"You Are In Tool {toolName}");
    });


    // alpha a-z A-Z
    endpoints.Map("name/{name:alpha=GMT}", async context =>
    {
        string? name = Convert.ToString(context.Request.RouteValues["name"]);
        await context.Response.WriteAsync($"You Are In name {name}");
    });



    // Regex    age:regex(^[0-9]{2}$)
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:regex(^(apr|jul|oct|jan)$)}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"You Are In sales report {year} - {month}");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"You are in {context.Request.Path}");
});

app.Run();
