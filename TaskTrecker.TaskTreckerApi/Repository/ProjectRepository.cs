using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
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

        /// <summary>
        /// Add new project or change project info in data base
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Project> CreateUpdateProject(Project project)
        {
            if (project.Id > 0)
            {
                _db.Projects.Update(project);
            }
            else
            {
                _db.Projects.Add(project);
            }

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create/update project", ex);
            }

            return project;
        }

        /// <summary>
        /// Delete project and tasks this project in data base
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteProject(int id)
        {
            var project = await _db.Projects.FirstOrDefaultAsync(item => item.Id == id);

            if (project == null)
            {
                throw new ArgumentNullException("Project not found");
            }

            var projectTasks = _db.Tasks.Where(item => item.IdProject == id);

            if (projectTasks != null)
                _db.Tasks.RemoveRange(projectTasks);

            _db.Projects.Remove(project);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete project in db", ex);
            }

            return true;
        }

        /// <summary>
        /// Get concrete project in data base
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Project> GetProjectById(int id)
        {
            return await _db.Projects.FirstOrDefaultAsync(item => item.Id == id);
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Project>> GetProjects()
        {
            var listProjects = await _db.Projects.ToListAsync();

            return listProjects;
        }

        public Task<IEnumerable<Project>> GetProjectsByDate(DateTime dateStart)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetProjectsByDateRange(DateTime dateStart, DateTime dateEnd)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetProjectsByName(string nameProject)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetProjectsByPriority(SD.Priority priority)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetProjectsByStatus(StatusProject status)
        {
            throw new NotImplementedException();
        }
    }
}
