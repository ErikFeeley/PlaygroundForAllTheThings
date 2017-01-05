using System.Collections.Generic;
using MediatR;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    public class ToDoThingsByUserIdQueryAsync : IRequest<IEnumerable<ToDoThing>>
    {
        public string UserId { get; set; }
    }
}
