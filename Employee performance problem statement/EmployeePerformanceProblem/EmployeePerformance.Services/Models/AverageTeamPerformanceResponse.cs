namespace EmployeePerformance.Services
{
    public partial class EmployeePerformanceService
    {
        public class AverageTeamPerformanceResponse
        {
            public string Team { get; set; } = null!;
            public List<ProjectMeanTime> Projects { get; set; } = null!;

        }
    }
}
