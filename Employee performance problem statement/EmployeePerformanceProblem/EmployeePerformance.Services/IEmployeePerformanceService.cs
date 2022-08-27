using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeePerformance.Services.EmployeePerformanceService;

namespace EmployeePerformance.Services
{
    public interface IEmployeePerformanceService
    {
        Task<List<AverageTeamPerformanceResponse>> GetTeamEffortAsync();
        Task<List<EmployeeEfficiency>> GetLowestEfficientEmployees(int n);
    }
}
