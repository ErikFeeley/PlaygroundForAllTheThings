using MediatR;
using ToDoGaveUpProbablyCQRS.Models;
using ToDoGaveUpProbablyCQRS.ViewModels;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    public class AddToDoThingByUserIdCommandAsync : IRequest<ToDoThing>
    {
        public string UserId { get; set; }

        public ToDoThingViewModel ToDoThingViewModel { get; set; }
    }
}
