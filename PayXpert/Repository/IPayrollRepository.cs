using PayXpert.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Repository
{
    internal interface IPayrollRepository
    {
        int GeneratePayroll(int payrollID, int empId, DateTime startDate, DateTime endDate, int basicSalary, int overtimePay, int deductions);
        Payroll GetPayrollById(int id);
        Payroll GetPayrollsForEmployee(int id);
        List<Payroll> GetPayrollsForPeriod(DateTime startDate, DateTime endDate);
    }
}
