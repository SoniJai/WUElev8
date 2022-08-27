namespace EmployeePerformance.Services
{
    public class AverageTeamProjectPerformance
    {
        public string Team { get; set; } = null!;
        public string ProjectName { get; set; } = null!;
        public double MeanTime { get; set; }

    }
}