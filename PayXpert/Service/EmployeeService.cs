using PayXpert.Exception;
using PayXpert.Model;
using PayXpert.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Service
{
    internal class EmployeeService : IEmployeeService
    {
        readonly IEmployeeRepository _employeeRepository;

        //Constructor
        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public void GetEmployeeById()
        {
            
            try
            {
                Console.WriteLine("Enter id of the Employee :");
                int id = int.Parse(Console.ReadLine());
                Employee employee = _employeeRepository.GetEmployeeById(id);
                Console.WriteLine(employee);
            }
            catch(EmployeeNotFoundException ex)
            {
                Console.WriteLine($"Error occured : {ex.Message}");
            }
            
        }

        public void GetAllEmployees()
        {
            List<Employee> employeeList = _employeeRepository.GetAllEmployees();
            foreach (Employee item in employeeList)
            {
                Console.WriteLine(item);
            }
        }

        public void AddEmployee()
        {
            Employee employee = new Employee();

            Console.WriteLine("Enter EmployeeID: ");
            employee.EmployeeID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter FirstName: ");
            employee.FirstName = (Console.ReadLine());

            Console.WriteLine("Enter LastName: ");
            employee.LastName = (Console.ReadLine());

            Console.WriteLine("Enter Date of birth: ");
            employee.DateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter gender: ");
            employee.Gender = (Console.ReadLine());

            Console.WriteLine("Enter email: ");
            employee.Email = (Console.ReadLine());

            Console.WriteLine("Enter phone number: ");
            employee.PhoneNumber = (Console.ReadLine());

            Console.WriteLine("Enter Address: ");
            employee.Address = (Console.ReadLine());

            Console.WriteLine("Enter position: ");
            employee.Position = (Console.ReadLine());

            Console.WriteLine("Enter Joining date: ");
            employee.JoiningDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Termination date: ");
            employee.TerminationDate = DateTime.Parse(Console.ReadLine());

            _employeeRepository.AddEmployee(employee);

        }

        public void UpdateEmployee()
        {
            Console.WriteLine("Enter id of the employee record you want to update :");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the updated position of the employee:");
            string position = Console.ReadLine();

            _employeeRepository.UpdateEmployee(id, position);
        }

        public void RemoveEmployee()
        {
            Console.WriteLine("Enter id of the employee you want to delete:");
            int id = int.Parse(Console.ReadLine());

            _employeeRepository.RemoveEmployee(id);
        }
    }
}


