using System;
using System.Collections.Generic;

namespace Domain {
    public interface IProjectRepository : IRepository<Project> {
        IEnumerable<Project> GetProjectsWithUser(Guid userId, int count);
    }
}