using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Model
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime TerminationDate { get; set; }

        public Employee()
        {

        }

        // toString() 
        public override string ToString()
        {
            return $"EmployeeId:: {EmployeeID}\t FirstName:: {FirstName} LastName:: {LastName}\t DateOfBirth:: {DateOfBirth}\t Gender:: {Gender}";
        }
    }
}
