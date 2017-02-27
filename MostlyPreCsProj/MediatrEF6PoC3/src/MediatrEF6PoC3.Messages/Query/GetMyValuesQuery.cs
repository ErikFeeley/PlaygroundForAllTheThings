using System.Collections.Generic;
using MediatrEF6PoC3.Models;
using MediatR;

namespace MediatrEF6PoC3.Messages.Query
{
    public class GetMyValuesQuery : IRequest<IEnumerable<MyValue>>
    {
    }
}
