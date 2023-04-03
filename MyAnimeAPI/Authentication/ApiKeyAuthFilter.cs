using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyAnimeAPI.Authentication
{
    public class ApiKeyAuthFilter : IAuthorizationFilter
    {
        private readonly IConfiguration _configuration;

        public ApiKeyAuthFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            // if there is no API Key from the header
            if (!context.HttpContext.Request.Headers.TryGetValue(AuthenticationConstants.ApiKeyHeader, out var userKey))
            {
                context.Result = new UnauthorizedObjectResult("API Key Missing");
                return;
            }

            var apiKey = _configuration.GetValue<string>(AuthenticationConstants.ApiKey);
            if (!apiKey.Equals(userKey))
            {
                context.Result = new UnauthorizedObjectResult("Invalid API Key");
                return;                
            }
        }

     
    }
}
