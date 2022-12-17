namespace TaskTrecker.TaskTreckerApi.Models.Dto
{
    public class ResponseDto
    {
        /// <summary>
        /// Method is success
        /// </summary>
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// Result execution
        /// </summary>
        public object Result { get; set; }

        /// <summary>
        /// Special message
        /// </summary>
        public string DisplayMessage { get; set; } = "";

        /// <summary>
        /// Error messages
        /// </summary>
        public List<string> ErrorMessages { get; set; }
    }
}
