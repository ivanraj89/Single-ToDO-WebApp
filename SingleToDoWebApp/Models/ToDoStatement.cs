using System.ComponentModel.DataAnnotations;

namespace SingleToDoWebApp.Models
{
    public class ToDoStatement
    {
        [Key]
        public int TaskId { get; set; }

        public string ToDo { get; set; }

        public DateTime date { get; set; }
    }
}
