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
    public class GetUsersToDoThingsAndTagsHandler : IAsyncRequestHandler<GetUsersToDoThingsAndTagsQuery, UserDto>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetUsersToDoThingsAndTagsHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDto> Handle(GetUsersToDoThingsAndTagsQuery message)
        {
            // still not there yet.
            var result = await _dbContext.ToDoThingTags
                .Include(tdtt => tdtt.Tag)
                .Include(tdtt => tdtt.ToDoThing)
                .ThenInclude(tdt => tdt.ApplicationUser)
                .Where(tdt => tdt.ToDoThing.ApplicationUser.Id == message.Id)
                .Select(tdtt => new { tdtt.ToDoThing.ApplicationUser, tdtt.ToDoThing.ApplicationUser.ToDoThings })
                .FirstOrDefaultAsync();

            //var result = await _dbContext.Users
            //    .Include(user => user.ToDoThings)
            //    .ThenInclude(tdt => tdt.ToDoThingTags)
            //    .ThenInclude(tdtt => tdtt.Tag)
            //    .Where(user => user.Id == message.Id)
            //    .FirstOrDefaultAsync();

            var userDto = new UserDto();

            userDto.Email = result.ApplicationUser.Email;

            return userDto;
        }
    }
}

