namespace Web2_middleware
{
    public class CustomMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello Three");
            await next(context);
            await context.Response.WriteAsync("Hello Four");
        }
    }

    
    public static class CustomMiddleWareExtension
    {

    }
}
