using PayXpert.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Repository
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
        List<Employee> GetAllEmployees();
        bool AddEmployee(Employee employee);
        bool UpdateEmployee(int id, string position);
        bool RemoveEmployee(int id);
    }
}
