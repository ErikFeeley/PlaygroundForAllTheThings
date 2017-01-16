namespace ToDoBase.Models
{
    public class ToDo
    {
        public ToDo()
        {
            // For EF to not complain
        }

        public ToDo(string userId, string title, string description)
        {
            ApplicationUserId = userId;
            Title = title;
            Description = description;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }


        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
