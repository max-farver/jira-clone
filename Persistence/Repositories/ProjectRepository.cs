using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence {
    public class ProjectRepository : Repository<Project>, IProjectRepository {
        public ProjectRepository(DataContext context) : base(context) { }

        public IEnumerable<Project> GetProjectsWithUser(Guid userId, int count) {
            return DataContext.Projects.Take(count).ToList();
        }

        public DataContext DataContext {
            get { return Context as DataContext; }
        }
    }
}