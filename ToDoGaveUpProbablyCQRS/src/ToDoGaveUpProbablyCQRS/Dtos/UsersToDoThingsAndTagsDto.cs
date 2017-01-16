using System.Collections.Generic;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Dtos
{
    public class UsersToDoThingsAndTagsDto
    {
        public UsersToDoThingsAndTagsDto(ApplicationUser user/*, IEnumerable<ToDoThing> toDoThings, IEnumerable<Tag> tags*/)
        {
            ApplicationUser = user;
      //      ToDoThings = toDoThings;
    //        Tags = tags;
        }   

        public ApplicationUser ApplicationUser { get; set; }

//        public IEnumerable<ToDoThing> ToDoThings { get; set; }

  //      public IEnumerable<Tag> Tags { get; set; }
    }
}
