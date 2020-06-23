using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Sprints;

namespace Persistence
{
    public class SprintRepository : Repository<Sprint>, ISprintRepository
    {
        public SprintRepository(DataContext context) : base(context) { }

        public IEnumerable<Sprint> GetSprintsWithProject(Guid projectId)
        {
            return DataContext.Sprints.ToList();
        }


        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}