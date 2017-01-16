using System.Collections.Generic;

namespace ToDoGaveUpProbablyCQRS.Dtos
{
    public class ToDoThingDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<TagDto> Tags { get; set; }        
    }
}
