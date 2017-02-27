using System.Collections.Generic;

namespace ToDoGaveUpProbablyCQRS.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public IEnumerable<ToDoThingTag> ToDoThingTags { get; set; }        
    }
}
