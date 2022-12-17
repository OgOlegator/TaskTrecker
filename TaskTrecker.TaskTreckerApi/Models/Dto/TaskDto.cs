using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskTrecker.TaskTreckerApi.Models.Dto
{
    /// <summary>
    /// Data transfer object for Task model
    /// </summary>
    public class TaskDto
    {
        /// <summary>
        /// Unique id Task
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ID of the project under which the task is
        /// </summary>
        public int IdProject { get; set; }

        /// <summary>
        /// Name task
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description task
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Task execution status
        /// </summary>
        public StatusTask Status { get; set; }

        /// <summary>
        /// Task execution priority
        /// </summary>
        public SD.Priority Priority { get; set; }

    }
}
