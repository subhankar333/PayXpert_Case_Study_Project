using PayXpert.Model;
using PayXpert.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Service
{
    internal class PayrollService : IPayrollService
    {
        readonly IPayrollRepository _payrollrepository;

        public PayrollService()
        {
            _payrollrepository = new PayrollRepository();
        }

        public void GeneratePayroll()
        {
            Console.WriteLine("Enter payroll id: ");
            int payrollId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter employee id: ");
            int empId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter start date of payroll: ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter end date of payroll: ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter basic salary: ");
            int basicSalary = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter overtime pay: ");
            int overtimePay = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter all deductions: ");
            int deductions = int.Parse(Console.ReadLine());

            int addPayrollStatus = _payrollrepository.GeneratePayroll(payrollId, empId, startDate, endDate,basicSalary,overtimePay, deductions);
            if(addPayrollStatus > 0)
            {
                Console.WriteLine("Payroll generated successfully..");
            }
            else
            {
                Console.WriteLine("Payroll generation failed..");
            }

        }
        public void GetPayrollById()
        {
            Console.WriteLine("Enter id of payroll:");
            int id = int.Parse(Console.ReadLine());
            Payroll payroll = _payrollrepository.GetPayrollById(id);
            Console.WriteLine(payroll);
        }
        public void GetPayrollsForEmployee()
        {
            Console.WriteLine("Enter id of Employee:");
            int id = int.Parse(Console.ReadLine());
            Payroll payroll = _payrollrepository.GetPayrollsForEmployee(id);
            Console.WriteLine(payroll);
        }

        public void GetPayrollsForPeriod()
        {
            Console.WriteLine("Enter startDate:");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter endDate:");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            List<Payroll> payrollList = _payrollrepository.GetPayrollsForPeriod(startDate, endDate);
            foreach (Payroll item in payrollList)
            {
                Console.WriteLine(item);
            }
        }
    }
}


