using System;
using Domain.Users;
using Domain.Sprints;
using Domain.Tasks;
using Domain.Projects;


namespace Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ITaskRepository Tasks { get; }
        IProjectRepository Projects { get; }
        ISprintRepository Sprints { get; }
        int Complete();
    }
}