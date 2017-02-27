namespace ToDoThing.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Description { get; set; }

        // string not GUID cuz reasons i guess.
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
