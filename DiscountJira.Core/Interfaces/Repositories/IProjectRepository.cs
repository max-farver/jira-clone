using System.Collections.Generic;
using System.Threading.Tasks;
using DiscountJira.Core.Models;

namespace DiscountJira.Core.Interfaces.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<IEnumerable<Project>> GetProjectsWithTasks();
        Task<Project> GetProjectByIdWithTasks(int Id);
    }
}