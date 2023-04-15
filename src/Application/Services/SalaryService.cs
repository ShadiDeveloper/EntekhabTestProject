using Application.IServices;
using Application.Models.DTOs;
using Application.Models.Enums;
using Application.Utils;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using Mapster;
using Microsoft.Extensions.Logging;
using OvetimePoliciesProject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SalaryService: ISalaryService
    {
        private readonly ISalaryRepository _repository;
        private readonly ISalaryDapperRepository _dapperRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SalaryService> _logger;

        public SalaryService(
            ISalaryRepository repository,
            ISalaryDapperRepository dapperRepository,
            IMapper mapper,
            ILogger<SalaryService> logger)
        {
            _repository = repository;
            _dapperRepository = dapperRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<SalaryResponseDTO> GetAsync(int id)
        {
            var salary = await _dapperRepository.GetSingleAsync(id);
            if (salary is null)
            {
                _logger.LogError($"UpdateSalary - salay with id : {id} invalid!");
                // can use localizer or const class for message
                // can use custom exception for notFoundException with 404 code
                throw new Exception("شناسه وارد شده نامعتبر است!");
            }

            TypeAdapterConfig<Salary, SalaryResponseDTO>.NewConfig().Map(dest => dest.Date, src => src.DateSalary.DateTimeToShamsi());
            var a= salary.Adapt<SalaryResponseDTO>();
            return a;
        }

        public async Task<List<SalaryResponseDTO>> GetRangeAsync(string fromDate,string toDate)
        {
            var salaries = await _dapperRepository.GetRangeAsync(fromDate.ShamsiToDateTime().ToString(),toDate.ShamsiToDateTime().ToString());

            TypeAdapterConfig<Salary, SalaryResponseDTO>.NewConfig().Map(dest => dest.Date, src => src.DateSalary.DateTimeToShamsi());
            return salaries.Adapt< List<SalaryResponseDTO>>();
        }

        public async Task AddAsync(SalaryRequestDTO model, string OverTimeCalculator)
        {
            var salary = _mapper.Map<Salary>(model);
            salary.IncomeSalary = GetIncomeSalary(OverTimeCalculator, model.BasicSalary, model.Allowance, model.Transportation);
            salary.DateSalary = model.Date.ShamsiToDateTime();

            await _repository.InsertAsync(salary);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, SalaryRequestDTO model, string OverTimeCalculator)
        {
            var salary = await _repository.GetAsync(id);
            if(salary is null)
            {
                _logger.LogError($"UpdateSalary - salay with id : {id} invalid!");
                // can use localizer or const class for message
                // can use custom exception for notFoundException with 404 code
                throw new Exception("شناسه وارد شده نامعتبر است!");
            }

            //prepare model
            _mapper.Map(model, salary);
            salary.IncomeSalary = GetIncomeSalary(OverTimeCalculator, model.BasicSalary, model.Allowance,model.Transportation);
            salary.DateSalary = model.Date.ShamsiToDateTime();

            //save in db
            _repository.Update(salary);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var salary = await _repository.GetAsync(id);
            if (salary is null)
            {
                _logger.LogError($"UpdateSalary - salay with id : {id} invalid!");
                // can use localizer or const class for message
                // can use custom exception for notFoundException with 404 code
                throw new Exception("شناسه وارد شده نامعتبر است!");
            }

            _repository.Delete(salary);
            await _repository.SaveChangesAsync();
        }


        private double GetIncomeSalary(string type, double basicSalary, double allowance,double transportation)
        {
            double overTime = GetOverTime(type, basicSalary, allowance);
            double income= basicSalary + allowance + transportation - overTime;
            return income;
        }
        private double GetOverTime(string type, double basicSalary, double allowance)
        {
            double overtime = 0;

            switch (type)
            {
                case OvertimeConst.CalculatorA:
                    overtime= OvertimeMethods.CalcurlatorA(basicSalary, allowance);break;
                case OvertimeConst.CalculatorB:
                    overtime = OvertimeMethods.CalcurlatorB(basicSalary, allowance); break;
                case OvertimeConst.CalculatorC:
                    overtime = OvertimeMethods.CalcurlatorC(basicSalary, allowance); break;
            }

            return overtime;
        }
    }
}
