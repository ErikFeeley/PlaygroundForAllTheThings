using MediatR;
using System.Collections.Generic;

namespace PlayingWithVS2017RC.Messages.Queries
{
    public class GetMyStuffQuery : IRequest<IEnumerable<string>>
    {
        
    }
}
