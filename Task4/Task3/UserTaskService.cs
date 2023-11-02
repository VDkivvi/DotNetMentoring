using System.Linq;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao _userDao;

        public UserTaskService(IUserDao userDao) => _userDao = userDao;

        public int AddTaskForUser(int userId, UserTask task)
        {
            UserErrors.CheckUser(userId);
            var user = _userDao.GetUser(userId);
            UserErrors.CheckUser(user);
            var tasks = user.Tasks;
            tasks.ToList().ForEach(t => UserErrors.CheckTasks(t.Description, task.Description));
            tasks.Add(task);
            return 0;
        }
    }
}