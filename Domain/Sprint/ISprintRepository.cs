using System;
using System.Collections.Generic;

namespace Domain {
    public interface ISpringRepository : IRepository<Sprint> {
        IEnumerable<Sprint> GetSprintsWithProject(Guid projectId);
    }
}