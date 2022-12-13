﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTrecker.TaskTreckerApi.Models.Dto;
using TaskTrecker.TaskTreckerApi.Repository.IRepository;

namespace TaskTrecker.TaskTreckerApi.Controllers
{
    /// <summary>
    /// API for getting tasks of a specific project
    /// </summary>
    [Route("api/tasksproject")]
    [ApiController]
    public class TasksProjectController : ControllerBase
    {
        /// <summary>
        /// Object to work with data base
        /// </summary>
        private readonly ITaskRepository _repository;
        private ResponseDto _response = new ResponseDto();

        public TasksProjectController(ITaskRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all tasks in a project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{projectId}")]
        public async Task<ResponseDto> GetProjectTasks(string projectId)
        {
            try
            {
                _response.Result = await _repository.GetTasksByProject(int.Parse(projectId));
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
