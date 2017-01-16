using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoGaveUpProbablyCQRS.Data;
using ToDoGaveUpProbablyCQRS.Dtos;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Features.ApplicationUsers
{
    public class GetUsersToDoThingsAndTagsHandler : IAsyncRequestHandler<GetUsersToDoThingsAndTagsQuery, ApplicationUser>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetUsersToDoThingsAndTagsHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> Handle(GetUsersToDoThingsAndTagsQuery message)
        {
            var result = await _dbContext.Users
                .Include(u => u.ToDoThings)
                .Where(u => u.Id == message.Id)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
