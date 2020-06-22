using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence {
    public class ProjectRepository : Repository<Project>, IProjectRepository {
        public ProjectRepository(AppContext context) : base(context) { }

        public IEnumerable<Project> GetProjectsWithUser(Guid userId, int count) {
            return AppContext.Projects.Take(count).ToList();
        }

        public AppContext AppContext {
            get { return Context as AppContext; }
        }
    }
}