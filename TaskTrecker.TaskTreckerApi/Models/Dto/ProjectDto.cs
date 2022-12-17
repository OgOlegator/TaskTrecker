using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskTrecker.TaskTreckerApi.Models.Dto
{
    /// <summary>
    /// Data transfer object for Project model
    /// </summary>
    public class ProjectDto
    {
        /// <summary>
        /// Unique id project
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name project
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Create date project
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Project end date
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Project execution status
        /// </summary>
        public StatusProject Status { get; set; }

        /// <summary>
        /// Project execution priority
        /// </summary>
        public SD.Priority Priority { get; set; }

    }
}
