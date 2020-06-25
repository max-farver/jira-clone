using DiscountJira.Core.Interfaces.Repositories;
using DiscountJira.Core.Models;

namespace DiscountJira.Persistence.Repositories
{
    public class TaskItemRepository : BaseRepository<TaskItem>, ITaskItemRepository
    {
        public TaskItemRepository(DataContext context) : base(context) { }
    }
}