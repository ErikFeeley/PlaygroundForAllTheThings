using System.Collections.Generic;
using ToDoGaveUpProbablyCQRS.Models;

namespace ToDoGaveUpProbablyCQRS.Dtos
{
    public class UserDto
    {
        public string Email { get; set; }

        public IEnumerable<ToDoThingDto> ToDoThings { get; set; }
    }
}
