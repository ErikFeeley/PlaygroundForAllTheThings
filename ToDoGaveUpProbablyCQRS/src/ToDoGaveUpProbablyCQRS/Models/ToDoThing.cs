namespace ToDoGaveUpProbablyCQRS.Models
{
    public class ToDoThing
    {
        public int Id { get; set; }

        // string here for appuserid instead of int because identity by default uses a guid for its key.
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }        
    }
}
