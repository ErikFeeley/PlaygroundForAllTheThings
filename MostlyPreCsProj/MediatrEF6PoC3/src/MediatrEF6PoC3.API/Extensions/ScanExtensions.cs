using System.Reflection;
using MediatR;
using StructureMap.Graph;

namespace MediatrEF6PoC3.API.Extensions
{
    public static class ScanExtensions
    {
        public static void ScanAllMyAssemblies(this IAssemblyScanner scanner)
        {
            scanner.Assembly(typeof(Startup).GetTypeInfo().Assembly);
            scanner.Assembly("MediatrEF6PoC3.Models");
            scanner.Assembly("MediatrEF6PoC3.Messages");
            scanner.Assembly("MediatrEF6PoC3.EF6Handlers");
            scanner.Assembly("MediatrEF6PoC3.EF6");
        }

        public static void GlueTogetherMediatrInterfaces(this IAssemblyScanner scanner)
        {
            scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
            scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
            scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
            scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));
        }
    }
}
