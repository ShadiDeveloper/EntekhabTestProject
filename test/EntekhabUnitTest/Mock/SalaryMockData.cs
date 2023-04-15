using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace EntekhabUnitTest.Mock
{
    public class SalaryMockData
    {

        public Salary GetSalary()
        {
            var salary = new Filler<Salary>().Create();
            return salary;
        }
    }
}
