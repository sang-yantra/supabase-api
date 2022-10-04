using Microsoft.EntityFrameworkCore;
using Supabase.Microservices.Context;
using Supabase.Microservices.DAL.Interfaces;
using Supabase.Microservices.DTO;

namespace Supabase.Microservices.DAL.Repos
{
    public class TaskInfoRepo : ITaskInfoRepo
    {
        private readonly JiraDbContext _context;

        public TaskInfoRepo(JiraDbContext context)
        {
            _context = context;
        }
        public async Task<List<TaskInfoDto>> GetAllTasks()
        {

            var tasks = new List<TaskInfoDto>();
            tasks = await _context.TaskInfos.Select(task => new TaskInfoDto()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                Priority = task.Priority,
                Completed = task.Completed,
                OriginalEstimate = task.OriginalEstimate,

            }).ToListAsync();
            return tasks;
        }
    }
}
