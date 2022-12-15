using Microsoft.EntityFrameworkCore;

namespace TaskTrecker.TaskTreckerApiTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testContext = TestContexts.GetContext();
            
            var taskRepository = new TaskRepository(testContext);

            var result = taskRepository.GetTasks();
        }
    }
}