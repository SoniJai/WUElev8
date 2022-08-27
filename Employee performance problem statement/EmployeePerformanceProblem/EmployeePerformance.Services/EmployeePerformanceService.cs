using EmployeePerformance.DataAccess;

namespace EmployeePerformance.Services
{
    public partial class EmployeePerformanceService : IEmployeePerformanceService
    {
        private readonly IEmployeePerformanceRepository _repo;
        public EmployeePerformanceService(IEmployeePerformanceRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<AverageTeamPerformanceResponse>> GetTeamEffortAsync()
        {
            var performances = await _repo.GetData();
            var averageTeamProjectPerformances = performances.GroupBy(x => new { x.Team, x.ProjectName })
                        .Select(n => new AverageTeamPerformance 
                        { 
                            Team = n.Key.Team, 
                            ProjectName = n.Key.ProjectName, 
                            MeanTime = n.Average(z => z.Hours) 
                        }).ToList();

            var averageTeamPerformances = averageTeamProjectPerformances.GroupBy(x => x.Team)
                                                     .Select(n => new AverageTeamPerformanceResponse
                                                     {
                                                         Team = n.Key,
                                                         Projects = n.Select(y => new ProjectMeanTime { Hours = y.MeanTime, ProjectName = y.ProjectName })
                                                                     .ToList()
                                                     }).ToList();

            return averageTeamPerformances;
        }

        public async Task<List<EmployeeEfficiency>> GetLowestEfficientEmployees(int n)
        {
            var performances = await _repo.GetData();
            var distinctEmployeeCount = performances.Select(x => x.Owner).Distinct().Count();
            if (distinctEmployeeCount < n)
            {
                throw new ArgumentException($"Input must be less than total employee count :{distinctEmployeeCount}");
            }
            var employeesLowestPerformances = performances.GroupBy(x => x.Owner).Select(z => new EmployeeEfficiency { EmployeeName = z.Key, Hours = z.Sum(z => z.Hours) }).ToList();
            return employeesLowestPerformances.OrderBy(x => x.Hours).Take(n).ToList();
        }
    }

    public class EmployeeEfficiency
    {
        public string EmployeeName { get; set; } = null!;
        public double Hours { get; set; }
    }
}
