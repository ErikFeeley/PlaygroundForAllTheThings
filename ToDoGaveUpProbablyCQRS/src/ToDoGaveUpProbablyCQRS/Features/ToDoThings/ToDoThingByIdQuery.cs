using MediatR;
using ToDoGaveUpProbablyCQRS.Dtos;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    public class ToDoThingByIdQuery : IRequest<ToDoDto>
    {
        public ToDoThingByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
