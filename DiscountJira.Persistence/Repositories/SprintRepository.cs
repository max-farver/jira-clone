using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiscountJira.Core.Interfaces.Repositories;
using DiscountJira.Core.Models;

namespace DiscountJira.Persistence.Repositories
{
    public class SprintRepository : BaseRepository<Sprint>, ISprintRepository
    {
        public SprintRepository(DataContext context) : base(context) { }
    }
}