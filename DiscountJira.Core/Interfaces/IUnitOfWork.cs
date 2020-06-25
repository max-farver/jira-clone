using System;
using System.Threading.Tasks;
using DiscountJira.Core.Interfaces.Repositories;

namespace DiscountJira.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // IUserRepository Users { get; }
        ITaskItemRepository Tasks { get; }
        IProjectRepository Projects { get; }
        ISprintRepository Sprints { get; }
        Task<int> Complete();
    }
}