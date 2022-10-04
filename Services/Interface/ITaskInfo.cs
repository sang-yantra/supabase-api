using Supabase.Microservices.DTO;

namespace Supabase.Microservices.Services.Interface
{
    public interface ITaskInfo
    {
        Task<List<TaskInfoDto>> GetAllTasks();
    }
}
