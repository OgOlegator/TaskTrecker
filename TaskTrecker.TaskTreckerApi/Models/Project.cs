using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static TaskTrecker.TaskTreckerApi.SD;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

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
        /// <summary>
        /// Unique id project
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name project
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        /// <summary>
        /// Create date project
        /// </summary>
        [Required]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Project end date
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Project execution status
        /// </summary>
        [Required]
        public StatusProject Status { get; set; }

        /// <summary>
        /// Project execution priority
        /// </summary>
        [Required]
        public SD.Priority Priority { get; set; }

    }
}
