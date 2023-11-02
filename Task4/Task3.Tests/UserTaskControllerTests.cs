using NUnit.Framework;
using Task3.DoNotChange;
using Task3.Tests.Stubs;

namespace Task3.Tests
{
    [TestFixture]
    public class UserTaskControllerTests
    {
        UserTaskController _controller;
        IUserDao _userDao;
        ResponseModelStub _model;

        [SetUp]
        public void TestSetup()
        {
            _userDao = new UserDaoStub();
            _controller = new UserTaskController(new UserTaskService(_userDao));
            _model = new ResponseModelStub();
        }

        [TestCase("task4", 1, 3)]
        public void CreateUserTask_ValidData_CheckDescription(
            string description, int userId, int taskNumb)
        {
            _controller.AddTaskForUser(userId, description, _model);
            StringAssert.AreEqualIgnoringCase(_userDao.GetUser(userId).Tasks[taskNumb].Description, description);
        }


        [TestCase("task4", 1, true)]
        [TestCase("task4", -11, false)]
        [TestCase("task4", 2, false)]
        public void AddTaskForUser_CheckResult(
            string description, int userId, bool isSuccessful)
        {
            bool result = _controller.AddTaskForUser(userId, description, _model);
            Assert.That(result, Is.EqualTo(isSuccessful));
        }

        [TestCase("task4", 1, 1, 4)]
        [TestCase("task4", -11, 1, 3)]
        [TestCase("task4", 2, 1, 3)]
        public void AddTaskForUser_CheckTheNumberOfTasks(
            string description, int userId, int existingUserId, int tasksNumber)
        {
            _controller.AddTaskForUser(userId, description, _model);
            Assert.That(_userDao.GetUser(existingUserId).Tasks.Count, Is.EqualTo(tasksNumber));
        }

        [TestCase("task4", 1, null)]
        [TestCase("task4", -11, "Invalid userId")]
        [TestCase("task4", 2, "User not found")]
        public void AddTaskForUser_CheckErrorMessage(
            string description, int userId, string? errorMessage)
        {
            _controller.AddTaskForUser(userId, description, _model);
            StringAssert.AreEqualIgnoringCase(_model.GetActionResult(), errorMessage);
        }
    }
}