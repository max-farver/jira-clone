using System;

namespace Domain {
    public interface IUnitOfWork : IDisposable {
        IUserRepository Users { get; }
        ITaskRepository Tasks { get; }
        IProjectRepository Projects { get; }
        int Complete();
    }
}