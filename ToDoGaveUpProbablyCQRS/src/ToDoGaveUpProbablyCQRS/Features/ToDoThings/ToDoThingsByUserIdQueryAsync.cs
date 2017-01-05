using System.Collections.Generic;
using MediatR;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    public class ToDoThingsByUserIdQueryAsync : IAsyncRequest<IEnumerable<ToDoThing>>
    {
        public string UserId { get; set; }
    }
}
