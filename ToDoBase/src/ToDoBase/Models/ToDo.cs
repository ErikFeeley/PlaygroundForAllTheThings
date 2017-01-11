namespace ToDoBase.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }


        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
