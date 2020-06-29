using System.Collections.Generic;
using System.Threading.Tasks;
using DiscountJira.Core.Models;

namespace DiscountJira.Core.Services.ProjectService
{
    public interface ITaskService
    {
        Task<bool> CreateTask(Project project, TaskItem newTask);
        Task<bool> UpdateTask(TaskItem oldTask, TaskItem updatedTask);
        Task<bool> DeleteTask(TaskItem taskToDelete);
    }
}