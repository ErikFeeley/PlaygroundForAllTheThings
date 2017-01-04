using System.Collections;
using System.Collections.Generic;
using MediatR;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    public class ToDoThingsByUserIdQuery : IRequest<IEnumerable<ToDoThing>>, IAsyncRequest<IEnumerable<ToDoThing>>
    {
        public string UserId { get; set; }
    }
}
