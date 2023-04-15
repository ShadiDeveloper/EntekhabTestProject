using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Domain.IRepositories;

namespace Infrastructure.Repositories
{
    public class SalaryDapperRepository: ISalaryDapperRepository
    {
        private readonly ApplicationDbContext _context;

        public SalaryDapperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Salary> GetSingleAsync(int id)
        {
            string sqlQuery = $"SELECT * FROM Salaries WHERE Id={id}";
            using (var connection = _context.CreateConnection())
            {
                var salary = await connection.QuerySingleAsync<Salary>(sqlQuery);
                return salary;
            }
        }


        public async Task<List<Salary>> GetRangeAsync(string fromDate,string toDate)
        {
            string sqlQuery = $"SELECT * FROM Salaries WHERE DateSalary BETWEEN '{fromDate}' AND '{toDate}'";
            using (var connection = _context.CreateConnection())
            {
                var salaries = await connection.QueryAsync<Salary>(sqlQuery);
                return salaries.ToList();
            }
        }
    }
}
