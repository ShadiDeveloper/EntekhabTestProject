using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SalaryRepository: ISalaryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SalaryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Salary> GetAsync(int id)
        {
            return await _dbContext.Salaries.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(Salary salary)
        {
           await _dbContext.Salaries.AddAsync(salary);
        }

        public void Update(Salary salary)
        {
            _dbContext.Salaries.Update(salary);
        }

        public void Delete(Salary salary)
        {
            _dbContext.Salaries.Remove(salary);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
