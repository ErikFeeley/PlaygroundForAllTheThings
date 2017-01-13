using MediatR;
using ToDoGaveUpProbablyCQRS.ViewModels;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    public class ToDoThingByIdQuery : IRequest<ToDoThingViewModel>
    {
        public ToDoThingByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
