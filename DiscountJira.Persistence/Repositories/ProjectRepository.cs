using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiscountJira.Core.Interfaces.Repositories;
using DiscountJira.Core.Models;

namespace DiscountJira.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DataContext context) : base(context) { }
    }
}