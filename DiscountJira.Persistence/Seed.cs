using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountJira.Core.Models;

namespace DiscountJira.Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Projects.Any() && !context.Tasks.Any())
            {
                var tasks1 = new List<TaskItem>() {
                    new TaskItem
                    {
                        Name = "Test Task 1",
                        Status = Status.Backlog
                    },
                    new TaskItem
                    {
                        Name = "Test Task 2",
                        Status = Status.Development
                    }
                };

                var tasks2 = new List<TaskItem>() {
                    new TaskItem
                    {
                        Name = "Test Task 3",
                        Status = Status.Backlog
                    },
                };

                var tasks3 = new List<TaskItem>() {
                    new TaskItem
                    {
                        Name = "Test Task 4",
                        Status = Status.Backlog
                    },
                };



                await context.Tasks.AddRangeAsync(tasks1);
                await context.Tasks.AddRangeAsync(tasks2);
                await context.Tasks.AddRangeAsync(tasks3);

                await context.SaveChangesAsync();

                var projects = new List<Project>() {
                    new Project
                    {
                        Id = 1,
                        Name = "value 101",
                        Version = 1.0,
                        Tasks = tasks1

                    },
                    new Project
                    {
                        Id = 2,
                        Name = "value 102",
                        Version = 1.0,
                        Tasks = tasks2
                    },
                    new Project
                    {
                        Id = 3,
                        Name = "value 103",
                        Version = 1.0,
                        Tasks = tasks3
                    }
                };

                await context.Projects.AddRangeAsync(projects);
                await context.SaveChangesAsync();
            }
        }
    }
}