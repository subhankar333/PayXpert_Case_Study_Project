using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Model;
using PayXpert.Repository;
using System.Data.SqlClient;
using PayXpert.Exception;
using PayXpert.Utility;

namespace PayXpert.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //sql connection class
        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;
        string connectionString;
        public EmployeeRepository()
        {
            sqlconnection = new SqlConnection(DbConnUtil.GetConnectionString());
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public Employee GetEmployeeById(int id)
        {
            
                if (!EmployeeExists(id))
                {
                    throw new EmployeeNotFoundException($"Employee data not found for EmployeeID {id}!");
                }

                cmd.CommandText = "select * from Employee where EmployeeID = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();

                Employee employee = new Employee();

                while (reader.Read())
                {
                    employee.EmployeeID = (int)reader["EmployeeID"];
                    employee.FirstName = (string)reader["FirstName"];
                    employee.LastName = (string)reader["LastName"];
                    employee.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    employee.Gender = (string)reader["Gender"];
                    employee.Email = (string)reader["Email"];
                    employee.PhoneNumber = (string)reader["PhoneNumber"];
                    employee.Address = (string)reader["Address"];
                    employee.Position = (string)reader["Position"];
                    employee.JoiningDate = (DateTime)reader["JoiningDate"];
                    employee.TerminationDate = (DateTime)reader["TerminationDate"];
                }

                return employee;
                sqlconnection.Close();
            
        }



        private bool EmployeeExists(int id)
        {

            SqlConnection sqlconnection = new SqlConnection(DbConnUtil.GetConnectionString()); ;
            SqlCommand cmd = new SqlCommand(); ;
            cmd.CommandText = "select * from Employee where EmployeeID = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = sqlconnection;
            sqlconnection.Open();

            object obj = cmd.ExecuteScalar();
            //Console.WriteLine(obj);
            return obj != null;
        }

        public List<Employee> GetAllEmployees()
        {
            cmd.CommandText = "select * from Employee";
            cmd.Connection = sqlconnection;
            sqlconnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Employee> employeeList = new List<Employee>();

            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.EmployeeID = (int)reader["EmployeeID"];
                employee.FirstName = (string)reader["FirstName"];
                employee.LastName = (string)reader["LastName"];
                employee.DateOfBirth = (DateTime)reader["DateOfBirth"];
                employee.Gender = (string)reader["Gender"];
                employee.Email = (string)reader["Email"];
                employee.PhoneNumber = (string)reader["PhoneNumber"];
                employee.Address = (string)reader["Address"];
                employee.Position = (string)reader["Position"];
                employee.JoiningDate = (DateTime)reader["JoiningDate"];
                employee.TerminationDate = (DateTime)reader["TerminationDate"];

                employeeList.Add(employee);

            }
            cmd.Parameters.Clear();
            sqlconnection.Close();
            return employeeList;
        }


        public bool AddEmployee(Employee employee)
        {
            cmd.CommandText = "insert into Employee values(@EmployeeID,@FirstName,@LastName,@DateOfBirth,@Gender,@Email,@PhoneNumber,@Address,@Position,@JoiningDate,@TerminationDate)";
            cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            cmd.Parameters.AddWithValue("@Gender", employee.Gender);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            cmd.Parameters.AddWithValue("@Address", employee.Address);
            cmd.Parameters.AddWithValue("@Position", employee.Position);
            cmd.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
            cmd.Parameters.AddWithValue("@TerminationDate", employee.TerminationDate);

            cmd.Connection = sqlconnection;
            sqlconnection.Open();
            int addUserStatus = cmd.ExecuteNonQuery();
            sqlconnection.Close();
            cmd.Parameters.Clear();

            if (addUserStatus > 0)
                Console.WriteLine("Employee added successfully!");
            else
                Console.WriteLine("Employee not added!");

            return addUserStatus > 0;
        }


        public bool UpdateEmployee(int id, string position)
        {
            try
            {
                if (!EmployeeExists(id))
                {
                    throw new EmployeeNotFoundException($"Employee data not found for EmployeeID {id} !");
                }
                cmd.CommandText = "update Employee set Position = @position where EmployeeID = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@position", position);

                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                int addUserStatus = cmd.ExecuteNonQuery();
                sqlconnection.Close();

                cmd.Parameters.Clear();

                if (addUserStatus > 0)
                    Console.WriteLine("Employee updated successfully!");
                else
                    Console.WriteLine("Employee not updated!");

                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine($"Error occured : {ex.Message}");

            }
            return false;
        }

        public bool RemoveEmployee(int id)
        {
            try
            {
                if (!EmployeeExists(id))
                {
                    throw new EmployeeNotFoundException($"Employee data not found for EmployeeID {id} !");
                }

                cmd.CommandText = "delete Employee where EmployeeID = @id";
                cmd.Parameters.AddWithValue("@id", id);

                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                int addUserStatus = cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                if (addUserStatus > 0)
                    Console.WriteLine("Employee deleted successfully!");
                else
                    Console.WriteLine("Employee not deleted!");

                return addUserStatus > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine($"Error occured : {ex.Message}");
            }
            finally
            {
                sqlconnection.Close();
            }

            return false;
        }
    }


}
