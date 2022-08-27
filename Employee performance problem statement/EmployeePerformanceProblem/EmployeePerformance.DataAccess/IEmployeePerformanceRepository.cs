using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePerformance.DataAccess
{
    public interface IEmployeePerformanceRepository
    {
        Task<List<EmployeePerformance>> GetData();
    }
}
