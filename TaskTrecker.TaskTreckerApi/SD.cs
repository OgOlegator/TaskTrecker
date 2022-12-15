using System.ComponentModel.DataAnnotations;

namespace TaskTrecker.TaskTreckerApi
{
    public class SD
    {
        /// <summary>
        /// execution priority
        /// </summary>
        public enum Priority
        {
            [Display(Name = "VeryHigh")]
            VeryHigh,
            [Display(Name = "High")]
            High,
            [Display(Name = "Medium")]
            Medium,
            [Display(Name = "Low")]
            Low
        }

    }
}
