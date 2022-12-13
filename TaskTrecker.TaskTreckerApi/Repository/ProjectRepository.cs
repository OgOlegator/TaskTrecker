using TaskTrecker.TaskTreckerApi.DbContexts;
using TaskTrecker.TaskTreckerApi.Models;
using TaskTrecker.TaskTreckerApi.Repository.IRepository;

namespace TaskTrecker.TaskTreckerApi.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Project AddProject(Project project)
        {
            throw new NotImplementedException();
        }

        public Project ChangeProject(Project project)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public Project GetProjectById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjects()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjectsByDate(DateTime dateStart)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjectsByDateRange(DateTime dateStart, DateTime dateEnd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjectsByName(string nameProject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjectsByPriority(SD.Priority priority)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjectsByStatus(StatusProject status)
        {
            throw new NotImplementedException();
        }
    }
}
