using Supabase.Microservices.DTO;

namespace Supabase.Microservices.DAL.Interfaces
{
    public interface ITaskInfoRepo
    {
        Task<List<TaskInfoDto>> GetAllTasks();
    }
}
