using System;
using System.Collections.Generic;

namespace Domain.Projects
{
    public interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> GetProjectsWithUser(Guid userId, int count);
    }
}