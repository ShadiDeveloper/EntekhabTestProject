using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface ISalaryRepository
    {
        Task<Salary> GetAsync(int id);
        Task InsertAsync(Salary salary);
        void Update(Salary salary);
        void Delete(Salary salary);

        Task SaveChangesAsync();

    }
}
