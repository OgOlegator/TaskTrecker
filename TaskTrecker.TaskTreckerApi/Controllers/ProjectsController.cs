using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TaskTrecker.TaskTreckerApi.Models;
using TaskTrecker.TaskTreckerApi.Models.Dto;
using TaskTrecker.TaskTreckerApi.Repository.IRepository;
using static TaskTrecker.TaskTreckerApi.SD;

namespace TaskTrecker.TaskTreckerApi.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        /// <summary>
        /// Object to work with data base
        /// </summary>
        private readonly IProjectRepository _repository;
        private ResponseDto _response = new ResponseDto();

        public ProjectsController(IProjectRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseDto> GetProjects()
        {
            try
            {
                _response.Result = await _repository.GetProjects();
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
        /// Get concrete project in data base
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{projectId}")]
        public async Task<ResponseDto> GetProjectById(string projectId)
        {
            try
            {
                _response.Result = await _repository.GetProjectById(int.Parse(projectId));
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
        /// Get projects by the occurrence of the search string
        /// </summary>
        /// <param name="searchName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByName/{searchName}")]
        public async Task<ResponseDto> GetProjectsByName(string searchName)
        {
            try
            {
                _response.Result = await _repository.GetProjectsByName(searchName);
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
        /// Get projects by execution status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByStatus/{status}")]
        public async Task<ResponseDto> GetProjectsByStatus(StatusProject status)
        {
            try
            {
                _response.Result = await _repository.GetProjectsByStatus(status);
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
        /// Get projects by task execution priority
        /// </summary>
        /// <param name="priority"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByPriority/{priority}")]
        public async Task<ResponseDto> GetProjectsByPriority(SD.Priority priority)
        {
            try
            {
                _response.Result = await _repository.GetProjectsByPriority(priority);
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
        /// Get projects whose start date is after the date from
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByDateFrom/{dateFrom}")]
        public async Task<ResponseDto> GetProjectsByDateFrom(string dateFrom)
        {
            try
            {
                _response.Result = await _repository.GetProjectsByDateFrom(DateTime.Parse(dateFrom));
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
        /// Get projects whose start date is between date from and date to
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByDateRange/{dateFrom} {dateTo}")]
        public async Task<ResponseDto> GetProjectsByDateRange(string dateFrom, string dateTo)
        {
            try
            {
                _response.Result = await _repository.GetProjectsByDateRange(DateTime.Parse(dateFrom), DateTime.Parse(dateTo));
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
        /// Add new project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseDto> CreateProject([FromBody] Project project)
        {
            try
            {
                _response.Result = await _repository.CreateUpdateProject(project);
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
        /// Update project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResponseDto> UpdateProject([FromBody] Project project)
        {
            try
            {
                _response.Result = await _repository.CreateUpdateProject(project);
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
        /// Delete project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{projectId}")]
        public async Task<ResponseDto> DeleteProject(string projectId)
        {
            try
            {
                _response.Result = await _repository.DeleteProject(int.Parse(projectId));
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
