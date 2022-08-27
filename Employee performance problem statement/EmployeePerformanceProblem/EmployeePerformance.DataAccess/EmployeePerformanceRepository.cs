using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EmployeePerformance.DataAccess
{
    public class EmployeePerformanceRepository : IEmployeePerformanceRepository
    {
        public async Task<List<EmployeePerformance>> GetData()
        {
            var jsonData = EmployeePerformanceData.GetData();
            await Task.CompletedTask;
            var dateFormat = "dd-MM-yyyy";
            return JsonConvert.DeserializeObject<List<EmployeePerformance>>(jsonData, new IsoDateTimeConverter { DateTimeFormat = dateFormat})!;
        }
    }
}
