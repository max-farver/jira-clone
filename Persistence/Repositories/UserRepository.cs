using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Projects;
using Domain.Users;

namespace Persistence
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }

        public IEnumerable<Project> GetProjectsWithUser(Guid userId, int count)
        {
            return DataContext.Projects.Take(count).ToList();
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}