using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountJira.Core.Interfaces.Repositories;
using DiscountJira.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscountJira.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Project>> GetProjectsWithTasks()
        {
            return await DataContext.Projects.Include(p => p.Tasks).ToListAsync();
        }

        public async Task<Project> GetProjectByIdWithTasks(int Id)
        {
            return await DataContext.Projects.Include(p => p.Tasks).SingleAsync(p => p.Id == Id);
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}