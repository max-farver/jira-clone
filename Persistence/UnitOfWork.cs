using Domain;

namespace Persistence {
    public class UnitOfWork : IUnitOfWork {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context) {
            _context = context;
            Users = new UserRepository(_context);
            Tasks = new TaskRepository(_context);
            Projects = new ProjectRepository(_context);
        }

        public IUserRepository Users { get; private set; }
        public ITaskRepository Tasks { get; private set; }
        public IProjectRepository Projects { get; private set; }

        public int Complete() {
            return _context.SaveChanges();
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}