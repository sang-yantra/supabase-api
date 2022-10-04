using Microsoft.AspNetCore.Mvc;
using Supabase.Microservices.DTO;
using Supabase.Microservices.Services.Interface;

namespace Supabase.Microservices.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("{v:apiVersion}/[controller]/[action]")]
    public class TaskInfoController : Controller
    {
        private readonly ITaskInfo _taskInfoService;

        public TaskInfoController(ITaskInfo taskInfoservice)
        {
            _taskInfoService = taskInfoservice;
        }



        /// <summary>
        /// Fetch list of task
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("tasks")]
        [ProducesResponseType(200, Type = typeof(List<TaskInfoDto>))]
        public async Task<ActionResult<List<TaskInfoDto>>> GetAllTasks()
        {
            try
            {
                var tasks = await _taskInfoService.GetAllTasks();
                return Ok(tasks);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
