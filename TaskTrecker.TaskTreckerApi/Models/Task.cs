using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskTrecker.TaskTreckerApi.Models
{
    public enum StatusTask
    {
        Todo,
        InProgress,
        Done
    }

    public class Task
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public int IdProject { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }

        [Required]
        public StatusTask Status { get; set; }

        [Required]
        public SD.Priority Priority { get; set; }

        [ForeignKey("IdProject")]
        public Project Project { get; set; }
    }
}
