using PayXpert.Service;
using System.Threading.Channels;

namespace PayXpert
{
    internal class Program
    {
        static void Main(string[] args)
        {

            void menuImplement()
            {
                Console.WriteLine("---Welcome to the PayXpert Case Study----\n");

                Console.WriteLine("1 --> EmployeeService");
                Console.WriteLine("2 --> PayrollService");
                Console.WriteLine("3 --> TaxService");
                Console.WriteLine("4 --> FinancialRecordService");
                Console.WriteLine("5 --> Exit\n");

                Console.WriteLine("--Enter a key to go ahead--\n");

                int key = int.Parse(Console.ReadLine());

                switch (key)
                {
                    case 1:
                        _EmployeeService();
                        break;
                    case 2:
                        _PayrollService();
                        break;
                    case 3:
                        _TaxService();
                        break;
                    case 4:
                        _FinancialRecordService();
                        break;
                    case 5:
                        return;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid key!");
                        break;

                }
            }

            menuImplement();

            void _EmployeeService()
            {
                
                start:
                    Console.WriteLine("Welcome to Employee Service...");
                    Console.WriteLine("--Enter a key to perform methods--\n");
                    Console.WriteLine("1 --> GetEmployeeById");
                    Console.WriteLine("2 --> GetAllEmployees");
                    Console.WriteLine("3 --> UpdateEmployee");
                    Console.WriteLine("4 --> RemoveEmployee");
                    Console.WriteLine("5 --> AddEmployee");
                    Console.WriteLine("6 --> Exit\n");

                int key = int.Parse(Console.ReadLine());
                IEmployeeService employeeService = new EmployeeService();

                switch (key)
                {
                    case 1:
                        employeeService.GetEmployeeById();
                        goto start;
                    case 2:
                        employeeService.GetAllEmployees(); ;
                        goto start;
                    case 3:
                        employeeService.UpdateEmployee();
                        goto start;
                    case 4:
                        employeeService.RemoveEmployee();
                        goto start;
                    case 5:
                        employeeService.AddEmployee();
                        goto start;
                    case 6:
                        menuImplement();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid key!");
                        goto start;

                }
            }

            void _PayrollService()
            {
                start:
                    Console.WriteLine("Welcome to Payroll Service...");
                    Console.WriteLine("--Enter a key to perform methods--\n");
                    Console.WriteLine("1 --> GeneratePayroll");
                    Console.WriteLine("2 --> GetPayrollById");
                    Console.WriteLine("3 --> GetPayrollsForEmployee");
                    Console.WriteLine("4 --> GetPayrollsForPeriod");
                    Console.WriteLine("5 --> Exit\n");

                int key = int.Parse(Console.ReadLine());
                IPayrollService payrollService = new PayrollService();

                switch (key)
                {
                    case 1:
                        payrollService.GeneratePayroll();
                        goto start;
                    case 2:
                        payrollService.GetPayrollById();
                        goto start;
                    case 3:
                        payrollService.GetPayrollsForEmployee();
                        goto start;
                    case 4:
                        payrollService.GetPayrollsForPeriod();
                        goto start;
                    case 5:
                        menuImplement();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid key!");
                        goto start;

                }
            }

            void _TaxService()
            {
                start:
                    Console.WriteLine("Welcome to Tax Service...");
                    Console.WriteLine("--Enter a key to perform methods--\n");
                    Console.WriteLine("1 --> CalculateTax");
                    Console.WriteLine("2 --> GetTaxById");
                    Console.WriteLine("3 --> GetTaxesForEmployee");
                    Console.WriteLine("4 --> GetTaxesForYear");
                    Console.WriteLine("5 --> Exit\n");

                int key = int.Parse(Console.ReadLine());
                ITaxService taxService = new TaxService();

                switch (key)
                {
                    case 1:
                        taxService.CalculateTax();
                        goto start;
                    case 2:
                        taxService.GetTaxById();
                        goto start;
                    case 3:
                        taxService.GetTaxesForEmployee();
                        goto start;
                    case 4:
                        taxService.GetTaxesForYear();
                        goto start;
                    case 5:
                        menuImplement();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid key!");
                        goto start;

                }
            }

            void _FinancialRecordService()
            {
                start:
                    Console.WriteLine("Welcome to FinancialRecord Service...");
                    Console.WriteLine("--Enter a key to perform methods--\n");
                    Console.WriteLine("1 --> AddFinancialRecord");
                    Console.WriteLine("2 --> GetFinancialRecordById");
                    Console.WriteLine("3 --> GetFinancialRecordsForEmployee");
                    Console.WriteLine("4 --> GetFinancialRecordsForDate");
                    Console.WriteLine("5 --> Exit\n");

                int key = int.Parse(Console.ReadLine());
                IFinancialRecordService financialRecordService = new FinancialRecordService();

                switch (key)
                {
                    case 1:
                        financialRecordService.AddFinancialRecord();
                        goto start;
                    case 2:
                        financialRecordService.GetFinancialRecordById();
                        goto start;
                    case 3:
                        financialRecordService.GetFinancialRecordsForEmployee();
                        goto start;
                    case 4:
                        financialRecordService.GetFinancialRecordsForDate();
                        goto start;
                    case 5:
                        menuImplement();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid key!");
                        goto start;

                }
            } 






           
        }
    }
}
