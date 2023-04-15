using Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Extensions;
using WebUI.Models;

namespace EntekhabUnitTest.WebUI.Extensions
{
    public class ConvertExtensionsTest
    {
        [Fact]
        public void ConvertToSalary_Returns_SalaryDTO_Json()
        {
            //arrange
            var dataType = DataTypeEnum.Json;
            var data = "{'firstName': 'Ali','lastName': 'Ahmadi','basicSalary': 1200000,'allowance': 400000,'transportation': 350000,'date': '14010801'}";
            var salaryDTO = new SalaryRequestDTO
            {
                FirstName = "Ali",
                LastName = "Ahmadi",
                BasicSalary = 1200000,
                Allowance = 400000,
                Transportation = 350000,
                Date = "14010801"
            };

            //act
            var salary = ConvertExtensions.ConvertToSalary(dataType, data);

            //assert
            Assert.NotNull(salary);
            Assert.Equal(salaryDTO.FirstName, salary.FirstName);
        }

        [Fact]
        public void ConvertToSalary_Returns_SalaryDTO_Custom()
        {
            //arrange
            var dataType = DataTypeEnum.Custom;
            var data = "FirstName/LastName/BasicSalary/Allowance/Transportation/Date\nAli/Ahmadi/1200000/400000/350000/14010801";
            var salaryDTO = new SalaryRequestDTO
            {
                FirstName = "Ali",
                LastName = "Ahmadi",
                BasicSalary = 1200000,
                Allowance = 400000,
                Transportation = 350000,
                Date = "14010801"
            };

            //act
            var salary = ConvertExtensions.ConvertToSalary(dataType, data);

            //assert
            Assert.NotNull(salary);
            Assert.Equal(salaryDTO.FirstName, salary.FirstName);
        }

        [Fact]
        public void ConvertToSalary_Returns_SalaryDTO_Custom_Exception()
        {
            //arrange
            var dataType = DataTypeEnum.Custom;
            var data = "FirstName/LastName/BasicSalary/Allowance/Transportation/DateAli/Ahmadi/1200000/400000/350000/14010801";
            var salaryDTO = new SalaryRequestDTO
            {
                FirstName = "Ali",
                LastName = "Ahmadi",
                BasicSalary = 1200000,
                Allowance = 400000,
                Transportation = 350000,
                Date = "14010801"
            };

            //act
            //Action act = () => ConvertExtensions.ConvertToSalary(dataType, data);

            //assert
            var exception= Assert.Throws<Exception>(()=>ConvertExtensions.ConvertToSalary(dataType, data));
            Assert.Equal("data not contains \n", exception.Message);
        }
    }
}
