using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MindAndMarket.Filters
{
    public class AdminOnlyFilter : IAsyncActionFilter
    {
        private readonly IConfiguration _configuration;

        public AdminOnlyFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var configuredKey = _configuration["AdminApiKey"];
            if (string.IsNullOrWhiteSpace(configuredKey))
            {
                context.Result = new ObjectResult(new { message = "Admin API key is not configured" })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return;
            }

            var hasHeader = context.HttpContext.Request.Headers.TryGetValue("X-Admin-Key", out var providedKey);
            if (!hasHeader || !string.Equals(providedKey.ToString(), configuredKey, StringComparison.Ordinal))
            {
                context.Result = new UnauthorizedObjectResult(new { message = "Missing or invalid X-Admin-Key header" });
                return;
            }

            await next();
        }
    }
}

