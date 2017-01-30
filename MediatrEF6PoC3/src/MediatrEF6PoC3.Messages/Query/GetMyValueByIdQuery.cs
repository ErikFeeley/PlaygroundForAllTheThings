using MediatrEF6PoC3.Models;
using MediatR;

namespace MediatrEF6PoC3.Messages.Query
{
    public class GetMyValueByIdQuery : IRequest<MyValue>
    {
        public GetMyValueByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; } 
    }
}
