using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SingleToDoWebApp.Models
{
    public class ToDoStatement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "ToDo is required.")]
        public string? ToDo { get; set; }

        public DateTime? date { get; set; }
    }
}
