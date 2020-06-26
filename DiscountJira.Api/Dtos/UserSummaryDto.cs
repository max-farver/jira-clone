using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscountJira.Api.Dtos
{
    public class UserSummaryDto
    {
        public IEnumerable<ProjectSummaryDto> Projects { get; set; }
        public IEnumerable<TaskItemDto> UserTasks { get; set; }
    }
}