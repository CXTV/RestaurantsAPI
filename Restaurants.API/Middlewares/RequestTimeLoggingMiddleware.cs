
using System.Diagnostics;

namespace Restaurants.API.Middlewares
{
    public class RequestTimeLoggingMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeLoggingMiddleware> logger;

        public RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger)
        {
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var stopWatch = Stopwatch.StartNew();
            await next.Invoke(context);
            stopWatch.Stop();

            if (stopWatch.ElapsedMilliseconds / 1000 > 4)
            {
                logger.LogInformation("Request [{Verv}] at {Path} took {Time} ms"
                    , context.Request.Method
                    , context.Request.Path
                    , stopWatch.ElapsedMilliseconds);
            }
        }
    }
}
