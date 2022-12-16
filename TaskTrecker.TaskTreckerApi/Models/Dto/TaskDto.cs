using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskTrecker.TaskTreckerApi.Models.Dto
{
    public class TaskDto
    {

        public int Id { get; set; }

        public int IdProject { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public StatusTask Status { get; set; }

        public SD.Priority Priority { get; set; }

    }
}
