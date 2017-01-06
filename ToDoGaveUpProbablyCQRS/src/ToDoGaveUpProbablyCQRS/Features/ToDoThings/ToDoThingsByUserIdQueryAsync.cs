using System.Collections.Generic;
using MediatR;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    /// <summary>
    /// will return empty list if db returns nothingz.
    /// </summary>
    public class ToDoThingsByUserIdQueryAsync : IRequest<IEnumerable<ToDoThing>>
    {
        public ToDoThingsByUserIdQueryAsync(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}
