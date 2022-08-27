using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReminderServiceProblem.Domain;

namespace ReminderServiceProblem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessTaskReminderController : ControllerBase
    {
        private readonly ITaskReminderProcessor _taskReminderProcessor;
        public ProcessTaskReminderController(ITaskReminderProcessor taskReminderProcessor)
        {
            _taskReminderProcessor = taskReminderProcessor;
        }

        [HttpGet("process")]
        public async Task<IActionResult> ProcessTaskReminders()
        {
            var result = await _taskReminderProcessor.GetAllTasks();
            return Ok(result);
        }
    }
}
