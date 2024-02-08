using PayXpert.Repository;
using PayXpert.Exception;
using PayXpert.Model;
namespace PayXpert.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void Test_To_Calculate_Net_Salary()
        {
            int employeeID = 10;
            int expectedNetSalary = 8750;

            PayrollRepository payrollRepository = new PayrollRepository();
            Payroll payroll = payrollRepository.GetPayrollsForEmployee(employeeID);

            int actualNetSalary = payroll.NetSalary;
            Assert.AreEqual(actualNetSalary, expectedNetSalary);
        }


        [Test]
        public void Test_To_Calculate_Tax()
        {
            int employeeId = 3;
            int taxYear = 2024;
            int expectedTax = 2300;

            TaxRepository taxRepository = new TaxRepository();
            int actualTax = taxRepository.CalculateTax(employeeId, taxYear);

            Assert.AreEqual(expectedTax, actualTax);

        }


        [Test]
        [TestCaseSource(nameof(SourceProvider))]
        public void test_to_prcoess_payroll_for_multiple_employees(int payrollId,int employeeId, DateTime startDate, DateTime endDate,int basicSalary,int overtimePay,int deductions,int expectedRecords)
        {
            PayrollRepository payrollrepository = new PayrollRepository();
            int actualRecords = payrollrepository.GeneratePayroll(payrollId,employeeId, startDate, endDate, basicSalary, overtimePay, deductions);

            Console.WriteLine(actualRecords);

            Assert.AreEqual(actualRecords, expectedRecords);

        }

        public static IEnumerable<object[]> SourceProvider()
        {
            yield return new object[] { 21,5, DateTime.Parse("2024-01-01"), DateTime.Parse("2024-04-01"), 20000, 1200, 2000,1};
            yield return new object[] { 22,3, DateTime.Parse("2024-01-01"), DateTime.Parse("2024-04-02"), 25000, 2000, 3000,1};
           
        }


        [Test]
        public void Test_To_Verify_Error_Handling_For_Invalid_Employee_Data()
        {
            int employeeId = 111;
            EmployeeRepository employeeRepository = new EmployeeRepository();

            var ex = Assert.Throws<EmployeeNotFoundException>(() => employeeRepository.GetEmployeeById(employeeId));

            Assert.That(ex.Message, Is.EqualTo($"Employee data not found for EmployeeID {employeeId}!"));


        }
    }
}