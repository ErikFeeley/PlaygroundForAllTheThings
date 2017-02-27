namespace ToDoGaveUpProbablyCQRS.Models
{
    public class ToDoThingTag
    {
        public int ToDoThingId { get; set; }
        public ToDoThing ToDoThing { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }        
    }
}
