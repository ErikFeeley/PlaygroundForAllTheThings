using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoGaveUpProbablyCQRS.Data;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    public class ToDoThingByIdHandler : IAsyncRequestHandler<ToDoThingByIdQuery, ToDoThing>
    {
        private readonly ApplicationDbContext _context;

        public ToDoThingByIdHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ToDoThing> Handle(ToDoThingByIdQuery message)
        {
            return await _context.ToDoThings.Include(tdt => tdt.ApplicationUser).FirstOrDefaultAsync(tdt => tdt.Id == message.Id);
        }
    }
}
