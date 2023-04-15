using OvetimePoliciesProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabUnitTest.OvertimePolicies
{
    public class OvertTimeMethodsTest
    {
        [Fact]
        public void CalcurlatorA_Return_Sum_Inputs()
        {
            //arrange
            double basicSalary = 12000;
            double allowance = 3500;
            double overtime = 15500;

            //act
            double calculateOvertime = OvertimeMethods.CalcurlatorA(basicSalary, allowance);

            //assert
            Assert.Equal(overtime, calculateOvertime);
        }

        [Fact]
        public void CalcurlatorB_Return_Sum_Inputs()
        {
            //arrange
            double basicSalary = 12000;
            double allowance = 3500;
            double overtime = 15500;

            //act
            double calculateOvertime = OvertimeMethods.CalcurlatorB(basicSalary, allowance);

            //assert
            Assert.Equal(overtime, calculateOvertime);
        }

        [Fact]
        public void CalcurlatorC_Return_Sum_Inputs()
        {
            //arrange
            double basicSalary = 12000;
            double allowance = 3500;
            double overtime = 15500;

            //act
            double calculateOvertime = OvertimeMethods.CalcurlatorC(basicSalary, allowance);

            //assert
            Assert.Equal(overtime, calculateOvertime);
        }
    }
}
