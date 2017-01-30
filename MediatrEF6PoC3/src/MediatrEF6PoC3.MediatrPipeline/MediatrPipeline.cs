using System.Threading.Tasks;
using MediatR;

namespace MediatrEF6PoC3.MediatrPipeline
{
    public class MediatrPipeline<TRequest, TResponse> : IAsyncRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IAsyncRequestHandler<TRequest, TResponse> _inner;

        public MediatrPipeline(IAsyncRequestHandler<TRequest, TResponse> inner)
        {
            _inner = inner;
        }

        public Task<TResponse> Handle(TRequest message)
        {
            return _inner.Handle(message);
        }
    }
}
