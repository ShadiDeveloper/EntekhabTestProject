using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface ISalaryDapperRepository
    {
        Task<List<Salary>> GetRangeAsync(string fromDate, string toDate);
        Task<Salary> GetSingleAsync(int id);
    }
}
