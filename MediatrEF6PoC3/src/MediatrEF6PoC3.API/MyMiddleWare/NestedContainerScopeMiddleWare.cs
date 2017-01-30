using System;
using System.Threading.Tasks;
using MediatrEF6PoC3.EF6;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StructureMap;

namespace MediatrEF6PoC3.API.MyMiddleWare
{
    public class NestedContainerScopeMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<NestedContainerScopeMiddleWare> _logger;

        public NestedContainerScopeMiddleWare(RequestDelegate next, ILogger<NestedContainerScopeMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var container = httpContext.RequestServices.GetService<IContainer>();

            if (container != null)
            {
                using (var requestContainer = container.GetNestedContainer())
                {
                    httpContext.RequestServices = requestContainer.GetInstance<IServiceProvider>();

                    var myContext = requestContainer.GetInstance<MyContext>();

                    await _next.Invoke(httpContext);
                }
            }
            else
            {
                await _next.Invoke(httpContext);
            }
        }
    }

    public static class NestedContainerScopeExtension
    {
        public static IApplicationBuilder UseNestedContainerScopeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NestedContainerScopeMiddleWare>();
        }
    }
}
