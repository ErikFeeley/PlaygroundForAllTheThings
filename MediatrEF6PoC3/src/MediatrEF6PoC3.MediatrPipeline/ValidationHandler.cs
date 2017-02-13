using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace MediatrEF6PoC3.MediatrPipeline
{
    public class ValidationHandler<TRequest, TResponse> : IAsyncRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IAsyncRequestHandler<TRequest, TResponse> _inner;
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationHandler(IAsyncRequestHandler<TRequest, TResponse> inner, IValidator<TRequest>[] validators)
        {
            _inner = inner;
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest message)
        {
            var context = new ValidationContext(message);

            var failures = _validators.Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return _inner.Handle(message);
        }
    }
}
