
using TaskTrecker.TaskTreckerApi.Repository.IRepository;

namespace TaskTrecker.TaskTreckerApiTest
{
    [TestClass]
    public class TestProjectRepository
    {
        [TestMethod]
        public void CreateUpdateProject_CreateProject_success()
        {
            var testContext = TestContexts.GetContext();
            var mapper = MappingConfig.RegisterMaps().CreateMapper();

            IProjectRepository repository = new ProjectRepository(testContext, mapper);

            var testCreate = repository.CreateUpdateProject(new ProjectDto
            {
                Name = "AddTest",
                CreatedDate = DateTime.Now,
                Priority = SD.Priority.Medium,
                Status = StatusProject.NotStarted,
            });

            var expected = new ProjectDto
            {
                Id = 1,
                Name = "AddTest",
                CreatedDate = DateTime.Now,
                Priority = SD.Priority.Medium,
                Status = StatusProject.NotStarted,
            };

            Assert.AreEqual(expected, testCreate.Result);
        }

    }
}