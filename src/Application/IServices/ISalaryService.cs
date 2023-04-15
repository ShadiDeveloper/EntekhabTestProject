using Application.Models.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ISalaryService
    {
        Task AddAsync(SalaryRequestDTO model, string OverTimeCalculator);
        Task DeleteAsync(int id);
        Task<SalaryResponseDTO> GetAsync(int id);
        Task<List<SalaryResponseDTO>> GetRangeAsync(string fromDate, string toDate);
        Task UpdateAsync(int id, SalaryRequestDTO model, string OverTimeCalculator);
    }
}
