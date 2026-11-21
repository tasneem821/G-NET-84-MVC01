using System.Diagnostics;

namespace G_NET_84_ADV03.CustomMiddleWare
{
    public class RequestTimmingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestTimmingMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var watch = Stopwatch.StartNew();
            await _next(httpContext);
            watch.Stop();
            Console.WriteLine($"{httpContext.Request.Path} + {watch.ElapsedMilliseconds} ms");
        }
    }
}
