using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTrecker.TaskTreckerApi.Models;
using TaskTrecker.TaskTreckerApi.Models.Dto;
using TaskTrecker.TaskTreckerApi.Repository.IRepository;

namespace TaskTrecker.TaskTreckerApi.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        /// <summary>
        /// Object to work with data base
        /// </summary>
        private readonly ITaskRepository _repository;
        private ResponseDto _response = new ResponseDto();

        public TasksController(ITaskRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseDto> GetTasks()
        {
            try
            {
                _response.Result = await _repository.GetTasks();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = ex.Message;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        /// <summary>
        /// Get concrete task in data base
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{taskId}")]
        public async Task<ResponseDto> GetTaskById(string taskId)
        {
            try
            {
                _response.Result = await _repository.GetTaskById(int.Parse(taskId));
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = ex.Message;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        /// <summary>
        /// Get tasks by the occurrence of the search string
        /// </summary>
        /// <param name="searchName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{searchName}")]
        public async Task<ResponseDto> GetTasksByName(string searchName)
        {
            try
            {
                _response.Result = await _repository.GetTasksByName(searchName);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = ex.Message;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        /// <summary>
        /// Get tasks by execution status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{status}")]
        public async Task<ResponseDto> GetTasksByStatus(string status)
        {
            try
            {
                _response.Result = await _repository.GetTasksByStatus((StatusTask)Enum.Parse(typeof(StatusTask), status));
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = ex.Message;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        /// <summary>
        /// Get tasks by task execution priority
        /// </summary>
        /// <param name="priority"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{priority}")]
        public async Task<ResponseDto> GetTasksByPriority(string priority)
        {
            try
            {
                _response.Result = await _repository.GetTasksByPriority((SD.Priority)Enum.Parse(typeof(SD.Priority), priority));
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = ex.Message;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        /// <summary>
        /// Add new task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseDto> CreateTask([FromBody] Models.Task task)
        {
            try
            {
                _response.Result = await _repository.CreateUpdateTask(task);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = ex.Message;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpPut]
        public async Task<ResponseDto> UpdateTask([FromBody] Models.Task task)
        {
            try
            {
                _response.Result = await _repository.CreateUpdateTask(task);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = ex.Message;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpDelete]
        [Route("{taskId}")]
        public async Task<ResponseDto> DeleteTask(string taskId)
        {
            try
            {
                _response.Result = await _repository.DeleteTask(int.Parse(taskId));
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = ex.Message;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

    }
}
