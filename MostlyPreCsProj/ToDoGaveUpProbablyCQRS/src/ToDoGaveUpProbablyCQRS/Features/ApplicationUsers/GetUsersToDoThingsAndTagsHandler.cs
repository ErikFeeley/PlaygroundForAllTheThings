using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Core;
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
            //var result = await _dbContext.ToDoThingTags
            //    .Include(tdtt => tdtt.Tag)
            //    .Include(tdtt => tdtt.ToDoThing)
            //    .ThenInclude(tdt => tdt.ApplicationUser)
            //    .Where(tdt => tdt.ToDoThing.ApplicationUser.Id == message.Id)
            //    .Select(tdtt => new { tdtt.ToDoThing.ApplicationUser, tdtt.ToDoThing.ApplicationUser.ToDoThings })
            //    .FirstOrDefaultAsync();

            //var result = await _dbContext.Users
            //    .Include(user => user.ToDoThings)
            //    .ThenInclude(tdt => tdt.ToDoThingTags)
            //    .ThenInclude(tdtt => tdtt.Tag)
            //    .Where(user => user.Id == message.Id)
            //    .FirstOrDefaultAsync();


            //this query actually generates one sql statement with just joins and no crazy shit but it only gets 1 todothing and 1 tag instead of all of em.
            //var result = await _dbContext.ToDoThingTags
            //    .Include(tdtt => tdtt.Tag)
            //    .Include(tdtt => tdtt.ToDoThing)
            //    .ThenInclude(tdt => tdt.ApplicationUser)
            //    .FirstOrDefaultAsync(tdtt => tdtt.ToDoThing.ApplicationUser.Id == message.Id);

            // this also unsuprisingly enough builds a stupid ass query.
            //var result = await _dbContext.ToDoThingTags
            //    .Include(tdtt => tdtt.ToDoThing.ApplicationUser)
            //    .ThenInclude(user => user.ToDoThings)
            //    .ThenInclude(tdt => tdt.ToDoThingTags)
            //    .ThenInclude(tdtt => tdtt.Tag)
            //    .FirstOrDefaultAsync(tdtt => tdtt.ToDoThing.ApplicationUser.Id == message.Id);

            // plz gawd THIS IS THE BEST ONE SO FAR
            //var result = await _dbContext.ToDoThingTags
            //    .Include(tdtt => tdtt.ToDoThing.ApplicationUser)
            //    .FirstOrDefaultAsync(tdtt => tdtt.ToDoThing.ApplicationUser.Id == message.Id);

            // it looks like this does a new seperate select statement per anon property in the anon select object thing... ya...
            //var result = _dbContext.ToDoThingTags
            //    .Include(tdtt => tdtt.ToDoThing.ApplicationUser)
            //    .Where(tdtt => tdtt.ToDoThing.ApplicationUser.Id == message.Id)
            //    .Select(tdtt => new { tdtt.ToDoThing.ApplicationUser, tdtt.ToDoThing.ApplicationUser.ToDoThings })
            //    .FirstOrDefaultAsync();


            // when u change the result of the query by using a select any .Includes() 0r .ThenIncludes are ignored.
            //var result = _dbContext.ToDoThingTags
            //    .Select(tdtt => tdtt.ToDoThing.ApplicationUser)
            //    .FirstOrDefaultAsync(user => user.Id == message.Id);


            // this biulds a stupid ass query.
            //var result = await _dbContext.Users
            //    .Include(user => user.ToDoThings)
            //    .ThenInclude(tdt => tdt.ToDoThingTags)
            //    .ThenInclude(tdtt => tdtt.Tag)
            //    .FirstOrDefaultAsync(user => user.Id == message.Id);

            // gets everything but is shitty looking sql
            var result = await _dbContext.Users
                .Where(u => u.Id == message.Id)
                .Include(u => u.ToDoThings)
                .ThenInclude(tdt => tdt.ToDoThingTags)
                .ThenInclude(tdtt => tdtt.Tag)
                .FirstOrDefaultAsync();

            var userDto = new UserDto();

            //userDto.Email = result.ToDoThing.ApplicationUser.Id;
            //userDto.Email = result.Result.ApplicationUser.Id;
            userDto.Email = result.Email;

            return userDto;
        }
    }
}

