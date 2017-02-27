namespace ToDoGaveUpProbablyCQRS.Dtos
{
    public class ToDoDto
    {
        public ToDoDto(string title, string description, string ownerEmail)
        {
            Title = title;
            Description = description;
            OwnerEmail = ownerEmail;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string OwnerEmail { get; set; }
    }
}