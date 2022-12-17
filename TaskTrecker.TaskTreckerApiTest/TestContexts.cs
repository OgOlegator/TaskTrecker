using Microsoft.EntityFrameworkCore;

namespace TaskTrecker.TaskTreckerApiTest
{
    public class TestContexts
    {
        public static ApplicationDbContext GetContext()
        {
            var testContext = new TaskTreckerApi.DbContexts.ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());

            //testContext.Projects.AddRange(GetProjectsData());
            //testContext.Tasks.AddRange(GetTasksData());

            return testContext;
        }

        public static List<Project> GetProjectsData()
        {
            return new List<Project>
            {
                new Project{ Id = 1, Name = "1", Priority = TaskTreckerApi.SD.Priority.VeryHigh, Status = StatusProject.NotStarted, CreatedDate = DateTime.Now },
                new Project{ Id = 2, Name = "2", Priority = TaskTreckerApi.SD.Priority.High, Status = StatusProject.NotStarted, CreatedDate = DateTime.Now },
                new Project{ Id = 3, Name = "3", Priority = TaskTreckerApi.SD.Priority.Low, Status = StatusProject.Completed, CreatedDate = DateTime.Now },
                new Project{ Id = 4, Name = "4", Priority = TaskTreckerApi.SD.Priority.Medium, Status = StatusProject.Active, CreatedDate = DateTime.Now },
                new Project{ Id = 5, Name = "5", Priority = TaskTreckerApi.SD.Priority.Medium, Status = StatusProject.Active, CreatedDate = DateTime.Now },
                new Project{ Id = 6, Name = "6", Priority = TaskTreckerApi.SD.Priority.Low, Status = StatusProject.NotStarted, CreatedDate = DateTime.Parse("2025.09.16") },
                new Project{ Id = 7, Name = "66", Priority = TaskTreckerApi.SD.Priority.Medium, Status = StatusProject.Active, CreatedDate = DateTime.Parse("2011.08.17") },
                new Project{ Id = 8, Name = "123", Priority = TaskTreckerApi.SD.Priority.High, Status = StatusProject.Completed, CreatedDate = DateTime.Parse("1999.12.11") },
            };
        }

        public static List<Models.Task> GetTasksData()
        {
            return new List<Models.Task>
            {
                new Models.Task{ Id = 1, Name = "1", Description = "1", IdProject = 1, Priority = TaskTreckerApi.SD.Priority.Medium, Status = StatusTask.Todo },
                new Models.Task{ Id = 2, Name = "2", Description = "1", IdProject = 1, Priority = TaskTreckerApi.SD.Priority.High, Status = StatusTask.Todo },
                new Models.Task{ Id = 21, Name = "21", Description = "1", IdProject = 2, Priority = TaskTreckerApi.SD.Priority.Medium, Status = StatusTask.Done },
                new Models.Task{ Id = 3, Name = "31", Description = "1", IdProject = 3, Priority = TaskTreckerApi.SD.Priority.High, Status = StatusTask.Done },
                new Models.Task{ Id = 412, Name = "411", Description = "1", IdProject = 2, Priority = TaskTreckerApi.SD.Priority.Medium, Status = StatusTask.InProgress },
                new Models.Task{ Id = 41, Name = "41", Description = "1", IdProject = 1, Priority = TaskTreckerApi.SD.Priority.Medium, Status = StatusTask.InProgress },
                new Models.Task{ Id = 4, Name = "4", Description = "1", IdProject = 4, Priority = TaskTreckerApi.SD.Priority.Low, Status = StatusTask.InProgress },
                new Models.Task{ Id = 55, Name = "55", Description = "1", IdProject = 5, Priority = TaskTreckerApi.SD.Priority.Medium, Status = StatusTask.Done },
                new Models.Task{ Id = 65, Name = "228", Description = "1", IdProject = 6, Priority = TaskTreckerApi.SD.Priority.Medium, Status = StatusTask.InProgress },
                new Models.Task{ Id = 7, Name = "21", Description = "1", IdProject = 6, Priority = TaskTreckerApi.SD.Priority.Medium, Status = StatusTask.Todo },
                new Models.Task{ Id = 8, Name = "56", Description = "1", IdProject = 1, Priority = TaskTreckerApi.SD.Priority.VeryHigh, Status = StatusTask.Todo },
                new Models.Task{ Id = 9, Name = "50", Description = "1", IdProject = 2, Priority = TaskTreckerApi.SD.Priority.Low, Status = StatusTask.Todo },
                new Models.Task{ Id = 10, Name = "10", Description = "1", IdProject = 3, Priority = TaskTreckerApi.SD.Priority.Low, Status = StatusTask.Todo },
                new Models.Task{ Id = 11, Name = "111", Description = "1", IdProject = 1, Priority = TaskTreckerApi.SD.Priority.VeryHigh, Status = StatusTask.Todo },
            };
        }
    }
}
