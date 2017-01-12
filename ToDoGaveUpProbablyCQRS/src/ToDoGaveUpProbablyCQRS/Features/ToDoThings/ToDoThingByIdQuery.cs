using MediatR;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    public class ToDoThingByIdQuery : IRequest<ToDoThing>
    {
        public int Id { get; set; }
    }
}
