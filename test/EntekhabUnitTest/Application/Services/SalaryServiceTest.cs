using Application.Models.DTOs;
using Application.Services;
using Application.Utils;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using EntekhabUnitTest.Mock;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabUnitTest.Application.Services
{
    public class SalaryServiceTest
    {
        private SalaryMockData salaryMockData;
        private Mock<ISalaryRepository> _repository;
        private Mock<ISalaryDapperRepository> _dapperRepository;
        private Mock<ILogger<SalaryService>> _logger;
        private Mock<IMapper> _mapper;
        public SalaryServiceTest()
        {
            salaryMockData = new SalaryMockData();
            _repository = new Mock<ISalaryRepository>();
            _dapperRepository = new Mock<ISalaryDapperRepository>();
            _logger = new Mock<ILogger<SalaryService>>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task GetAsync_Return_SingleSalary_ById()
        {
            //arrange
            var salaryData = salaryMockData.GetSalary();
            int id = salaryData.Id;
            _dapperRepository.Setup(p => p.GetSingleAsync(id)).ReturnsAsync(salaryData);

            //act
            SalaryService salaryService = new SalaryService(_repository.Object, _dapperRepository.Object, _mapper.Object, _logger.Object);
            var salary = await salaryService.GetAsync(id);

            //assert
            Assert.IsType<SalaryResponseDTO>(salary);
            Assert.Equal(salaryData.IncomeSalary, salary.IncomeSalary);
            
            //can control all of fields in salary
        }

        
    }
}
