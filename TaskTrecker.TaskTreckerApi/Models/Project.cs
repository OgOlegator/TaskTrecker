using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskTrecker.TaskTreckerApi.Models
{
    public enum StatusProject
    {
        NotStarted,
        Active,
        Completed
    }

    public class Project
    {

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public StatusProject Status { get; set; }

        [Required]
        public SD.Priority Priority { get; set; }

    }
}
