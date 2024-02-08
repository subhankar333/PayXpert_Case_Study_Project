using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Service
{
    internal interface IPayrollService
    {
        void GeneratePayroll();
        void GetPayrollById();
        void GetPayrollsForEmployee();
        void GetPayrollsForPeriod();
    }
}
