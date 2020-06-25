using System.Threading.Tasks;
using DiscountJira.Core.Interfaces;
using DiscountJira.Core.Interfaces.Repositories;
using DiscountJira.Persistence.Repositories;

namespace DiscountJira.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public ITaskItemRepository Tasks { get; private set; }
        public IProjectRepository Projects { get; private set; }
        public ISprintRepository Sprints { get; private set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Tasks = new TaskItemRepository(_context);
            Projects = new ProjectRepository(_context);
            Sprints = new SprintRepository(_context);
        }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}