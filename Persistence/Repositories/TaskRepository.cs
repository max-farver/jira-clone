using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence {
    public class TaskRepository : Repository<Task>, ITaskRepository {
        public TaskRepository(AppContext context) : base(context) { }

        public IEnumerable<Task> GetTasksWithUser(int count) {
            return AppContext.Tasks.Take(count).ToList();
        }

        public AppContext AppContext {
            get { return Context as AppContext; }
        }
    }
}