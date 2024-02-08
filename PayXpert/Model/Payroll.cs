using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Model
{
    public class Payroll
    {
        public int PayrollId { get; set; }
        public int EmployeeID { get; set; }
        public DateTime PayPeriodStartDate { get; set; }
        public DateTime PayPeriodEndDate { get; set; }
        public int BasicSalary { get; set; }
        public int OvertimePay { get; set; }
        public int Deductions { get; set; }
        public int NetSalary { get; set; }

        public Payroll()
        {

        }

        public override string ToString()
        {
            return $"PayrollId:: {PayrollId}\t EmployeeID:: {EmployeeID} PayPeriodStartDate:: {PayPeriodStartDate}\t PayPeriodEndDate:: {PayPeriodEndDate}\t NetSalary:: {NetSalary}";
        }
    }
}
