using EmployeePerformance.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePerformanceProblem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePerformanceController : ControllerBase
    {
        private readonly IEmployeePerformanceService _service;
        public EmployeePerformanceController(IEmployeePerformanceService service)
        {
            _service = service;
        }

        [HttpGet("teamEffort")]
        public async Task<IActionResult> GetMeanTeamPerformanceAsync()
        {
            var result = await _service.GetTeamEffortAsync();
            return Ok(result);

        }

        [HttpGet("lowestEmployeeEfficiency")]
        public async Task<IActionResult> GetLowestEfficientEmployeesAsync([FromQuery] int n = 5)
        {
            var result = await _service.GetLowestEfficientEmployees(n);
            return Ok(result);

        }
    }
}
