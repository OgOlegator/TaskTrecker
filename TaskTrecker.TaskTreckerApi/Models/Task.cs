using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static TaskTrecker.TaskTreckerApi.SD;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
        /// <summary>
        /// Unique id Task
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The ID of the project under which the task is
        /// </summary>
        [Required]
        public int IdProject { get; set; }

        /// <summary>
        /// Name task
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        /// <summary>
        /// Description task
        /// </summary>
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }

        /// <summary>
        /// Task execution status
        /// </summary>
        [Required]
        public StatusTask Status { get; set; }

        /// <summary>
        /// Task execution priority
        /// </summary>
        [Required]
        public SD.Priority Priority { get; set; }

        /// <summary>
        /// Navigation object
        /// </summary>
        [ForeignKey("IdProject")]
        public Project Project { get; set; }
    }
}
