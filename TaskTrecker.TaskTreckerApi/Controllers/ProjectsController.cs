﻿using Microsoft.AspNetCore.Http;
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
        [Route("{taskId}")]
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
        [Route("{searchName}")]
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
        [Route("{status}")]
        public async Task<ResponseDto> GetProjectsByStatus(string status)
        {
            try
            {
                _response.Result = await _repository.GetProjectsByStatus((StatusProject)Enum.Parse(typeof(StatusProject), status));
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
        [Route("{priority}")]
        public async Task<ResponseDto> GetProjectsByPriority(string priority)
        {
            try
            {
                _response.Result = await _repository.GetProjectsByPriority((SD.Priority)Enum.Parse(typeof(SD.Priority), priority));
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
        [Route("{dateFrom}")]
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
        [Route("{dateFrom dateTo}")]
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


        [HttpPost]
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
