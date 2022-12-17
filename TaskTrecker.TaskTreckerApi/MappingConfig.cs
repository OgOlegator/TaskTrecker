using AutoMapper;
using TaskTrecker.TaskTreckerApi.Models;
using TaskTrecker.TaskTreckerApi.Models.Dto;

namespace TaskTrecker.TaskTreckerApi
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<TaskDto, Models.Task>();
                config.CreateMap<Models.Task, TaskDto>();
                config.CreateMap<ProjectDto, Project>();
                config.CreateMap<Project, ProjectDto>();
            });

            return mappingConfig;
        }

    }
}
