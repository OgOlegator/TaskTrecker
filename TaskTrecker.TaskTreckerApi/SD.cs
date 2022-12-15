using System.ComponentModel.DataAnnotations;

namespace TaskTrecker.TaskTreckerApi
{
    /// <summary>
    /// Static details 
    /// </summary>
    public class SD
    {
        /// <summary>
        /// execution priority
        /// </summary>
        public enum Priority
        {
            VeryHigh,
            High,
            Medium,
            Low
        }

    }
}
