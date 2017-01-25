using System.Collections.Generic;
using MediatrEF6PoC2.Models;
using MediatR;

namespace MediatrEF6PoC2.Messages.Queries
{
    /// <summary>
    /// since this is a simple get all this object is empty, and the Irequest is what we get from mediatr for the message to handler pairing.
    /// say for example we were doing a get by Id we would specify a Id property in here for the message.
    /// </summary>
    public class GetMyValuesQuery : IRequest<IEnumerable<MyValue>>
    {
    }
}
