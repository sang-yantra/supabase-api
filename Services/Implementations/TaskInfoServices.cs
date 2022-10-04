using Supabase.Microservices.DAL.Interfaces;
using Supabase.Microservices.DTO;
using Supabase.Microservices.Services.Interface;

namespace Supabase.Microservices.Services.Implementations
{
    public class TaskInfoServices : ITaskInfo
    {
        private readonly ITaskInfoRepo _taskInforepo;

        public TaskInfoServices(ITaskInfoRepo taskInfoRepo)
        {
            _taskInforepo = taskInfoRepo;
        }
        public async Task<List<TaskInfoDto>> GetAllTasks()
        {
            var tasks = await _taskInforepo.GetAllTasks();
            return tasks;
        }
    }
}
