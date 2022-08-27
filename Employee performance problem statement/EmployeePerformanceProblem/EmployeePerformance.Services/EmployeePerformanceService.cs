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
            List<AverageTeamProjectPerformance> averageTeamProjectPerformances = GetAverageTeamProjectsPerformance(performances);
            List<AverageTeamPerformanceResponse> averageTeamPerformances = GetTeamPerformanceForProjects(averageTeamProjectPerformances);
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
            var employeesLowestPerformances = GetEmployeesLowestPerformances(performances);
            return employeesLowestPerformances.OrderBy(x => x.Hours).Take(n).ToList();
        }

        #region Private Methods

        private List<EmployeeEfficiency> GetEmployeesLowestPerformances(List<DataAccess.EmployeePerformance> performances)
        {
            return performances.GroupBy(x => x.Owner).Select(z => new EmployeeEfficiency { EmployeeName = z.Key, Hours = z.Sum(z => z.Hours) }).ToList();
        }

        private List<AverageTeamPerformanceResponse> GetTeamPerformanceForProjects(List<AverageTeamProjectPerformance> averageTeamProjectPerformances)
        {
            return averageTeamProjectPerformances.GroupBy(x => x.Team)
                                                     .Select(n => new AverageTeamPerformanceResponse
                                                     {
                                                         Team = n.Key,
                                                         Projects = n.Select(y => new ProjectMeanTime { Hours = y.MeanTime, ProjectName = y.ProjectName })
                                                                     .ToList()
                                                     }).ToList();
        }        

        private List<AverageTeamProjectPerformance> GetAverageTeamProjectsPerformance(List<DataAccess.EmployeePerformance> performances)
        {
            return performances.GroupBy(x => new { x.Team, x.ProjectName })
                        .Select(n => new AverageTeamProjectPerformance
                        {
                            Team = n.Key.Team,
                            ProjectName = n.Key.ProjectName,
                            MeanTime = n.Average(z => z.Hours)
                        }).ToList();
        }
        #endregion
    }
}
