using System.ComponentModel.DataAnnotations;

namespace ToDoGaveUpProbablyCQRS.ViewModels
{
    public class ToDoThingViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }        
    }
}
