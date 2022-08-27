using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePerformance.DataAccess
{
    public class EmployeePerformance
    {
        [JsonProperty("Project Name")]
        public string ProjectName { get; set; } = null!;
        public string Team { get; set; } = null!;
        public string Owner { get; set; } = null!;
        public DateTime Date { get; set; }
        public double Hours { get; set; }
        [JsonProperty("Billing Status")]
        public string BillingStatus { get; set; } = null!;
    }
}
