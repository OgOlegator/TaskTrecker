using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        private readonly ITaskRepository _repositoryTask;
        private readonly IProjectRepository _repositoryProject;
        private ResponseDto _response = new ResponseDto();

        public TasksController(ITaskRepository repositoryTask, IProjectRepository repositoryProject)
        {
            _repositoryTask = repositoryTask;
            _repositoryProject = repositoryProject;
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
                _response.Result = await _repositoryTask.GetTasks();
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
                _response.Result = await _repositoryTask.GetTaskById(int.Parse(taskId));
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
        [Route("GetByName/{searchName}")]
        public async Task<ResponseDto> GetTasksByName(string searchName)
        {
            try
            {
                _response.Result = await _repositoryTask.GetTasksByName(searchName);
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
        [Route("GetByStatus/{status}")]
        public async Task<ResponseDto> GetTasksByStatus(StatusTask status)
        {
            try
            {
                _response.Result = await _repositoryTask.GetTasksByStatus(status);
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
        [Route("GetByPriority/{priority}")]
        public async Task<ResponseDto> GetTasksByPriority(SD.Priority priority)
        {
            try
            {
                _response.Result = await _repositoryTask.GetTasksByPriority(priority);
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
        /// Get all tasks in a project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByProject/{projectId}")]
        public async Task<ResponseDto> GetProjectTasks(string projectId)
        {
            try
            {
                _response.Result = await _repositoryTask.GetTasksByProject(int.Parse(projectId));
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
                SetProjectInTask(task);

                _response.Result = await _repositoryTask.CreateUpdateTask(task);
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
        /// Update task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResponseDto> UpdateTask([FromBody] Models.Task task)
        {
            try
            {
                SetProjectInTask(task);

                _response.Result = await _repositoryTask.CreateUpdateTask(task);
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
        /// Delete task
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{taskId}")]
        public async Task<ResponseDto> DeleteTask(string taskId)
        {
            try
            {
                _response.Result = await _repositoryTask.DeleteTask(int.Parse(taskId));
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
        /// In json Task may not be filled with Project
        /// </summary>
        /// <param name="task"></param>
        /// <exception cref="Exception"></exception>
        private async void SetProjectInTask(Models.Task task)
        {
            if (task.Project.Id == 0 || task.Project == null)
                task.Project = await _repositoryProject.GetProjectById(task.IdProject);

            if (task.Project == null)
                throw new Exception("Project not found");
        }
    }
}
