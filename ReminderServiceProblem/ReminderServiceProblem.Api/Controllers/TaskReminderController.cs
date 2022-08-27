using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReminderServiceProblem.DataAccess;

namespace ReminderServiceProblem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskReminderController : ControllerBase
    {
        private readonly IReminderRepo _reminderRepo;
        
        public TaskReminderController(IReminderRepo reminderRepo)
        {
            _reminderRepo = reminderRepo;
        }

        [HttpPost]
        public async Task <IActionResult> Create([FromBody]TaskReminder taskReminder)
        {
            await _reminderRepo.Create(taskReminder);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _reminderRepo.GetAll();
            return Ok(result);
        }

    }
}
