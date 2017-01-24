using System.Collections.Generic;
using MediatrEF6PoC2.Models;
using MediatR;

namespace MediatrEF6PoC2.Messages.Queries
{
    public class GetMyValuesQuery : IRequest<IEnumerable<MyValue>>
    {
    }
}
