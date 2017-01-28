using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using StructureMap;

namespace MediatrEF6PoC3.API.MyMiddleWare
{
    public class NestedContainerScopeMiddleWare
    {
        private readonly RequestDelegate _next;

        public NestedContainerScopeMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IContainer container)
        {
            var myNestedContainer = container.GetNestedContainer();

            

            await _next.Invoke(context);
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
