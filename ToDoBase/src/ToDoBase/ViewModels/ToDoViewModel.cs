using System.ComponentModel.DataAnnotations;

namespace ToDoBase.ViewModels
{
    public class ToDoViewModel
    {
        [Required]
        [MaxLength(25)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
