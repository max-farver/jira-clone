using System.Collections.Generic;
using System.Threading.Tasks;
using DiscountJira.Core.Interfaces;
using DiscountJira.Core.Interfaces.Repositories;
using DiscountJira.Core.Models;

namespace DiscountJira.Core.Services.ProjectService
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITaskItemRepository _tasks;

        public TaskService(IUnitOfWork unitOfWork, IProjectService projectService)
        {
            _unitOfWork = unitOfWork;
            _tasks = unitOfWork.Tasks;
        }

        public async Task<bool> CreateTask(Project project, TaskItem newTask)
        {
            var tasks = (List<TaskItem>)project.Tasks;
            tasks.Add(newTask);
            return (await _unitOfWork.Complete()) > 0;
        }

        public async Task<bool> UpdateTask(TaskItem oldTask, TaskItem updatedTask)
        {
            oldTask.Name = updatedTask.Name ?? oldTask.Name;
            oldTask.Description = updatedTask.Description ?? oldTask.Description;
            oldTask.Points = updatedTask.Points != oldTask.Points ? updatedTask.Points : oldTask.Points;
            oldTask.EstimatedTime = updatedTask.EstimatedTime != oldTask.EstimatedTime ? updatedTask.EstimatedTime : oldTask.EstimatedTime;
            oldTask.Status = updatedTask.Status != oldTask.Status ? updatedTask.Status : oldTask.Status;
            oldTask.AssignedMembers = updatedTask.AssignedMembers ?? oldTask.AssignedMembers;
            oldTask.Status = updatedTask.Status != oldTask.Status ? updatedTask.Status : oldTask.Status;
            oldTask.isArchived = updatedTask.isArchived != oldTask.isArchived ? updatedTask.isArchived : oldTask.isArchived;
            return (await _unitOfWork.Complete()) > 0;
        }

        public async Task<bool> DeleteTask(TaskItem taskToDelete)
        {
            _tasks.Remove(taskToDelete);
            return (await _unitOfWork.Complete()) > 0;
        }

    }
}