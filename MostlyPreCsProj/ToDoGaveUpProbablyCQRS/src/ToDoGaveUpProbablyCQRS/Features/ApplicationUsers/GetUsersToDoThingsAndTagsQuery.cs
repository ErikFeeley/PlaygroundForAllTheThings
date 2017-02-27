using MediatR;
using ToDoGaveUpProbablyCQRS.Dtos;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Features.ApplicationUsers
{
    public class GetUsersToDoThingsAndTagsQuery : IRequest<UserDto>
    {
        public GetUsersToDoThingsAndTagsQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
