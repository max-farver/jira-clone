using System;
using System.Collections.Generic;

namespace Domain.Sprints
{
    public interface ISprintRepository : IRepository<Sprint>
    {
        IEnumerable<Sprint> GetSprintsWithProject(Guid projectId);
    }
}