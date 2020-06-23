using System.Collections.Generic;
using System.Linq;
using Domain.Tasks;

namespace Persistence
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(DataContext context) : base(context) { }

        public IEnumerable<Task> GetTasksWithUser(int count)
        {
            return DataContext.Tasks.Take(count).ToList();
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}