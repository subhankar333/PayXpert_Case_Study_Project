using PayXpert.Exception;
using PayXpert.Model;
using PayXpert.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Repository
{
    public class PayrollRepository : IPayrollRepository
    {
        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;
        public PayrollRepository()
        {
            sqlconnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        public int GeneratePayroll(int payrollId,int empId, DateTime startDate, DateTime endDate, int basicSalary, int overtimePay, int deductions)
        {
            Payroll payroll = new Payroll();
            payroll.PayrollId = payrollId;
            payroll.EmployeeID = empId;
            payroll.PayPeriodStartDate = startDate;
            payroll.PayPeriodEndDate = endDate;
            payroll.BasicSalary = basicSalary;
            payroll.OvertimePay = overtimePay;
            payroll.Deductions = deductions;
            payroll.NetSalary = basicSalary + overtimePay - deductions;


            cmd.CommandText = "insert into Payroll values (@PayrollId, @EmployeeID, @PayPeriodStartDate, @PayPeriodEndDate, @BasicSalary, @OvertimePay,@Deductions,@NetSalary)";
            cmd.Parameters.AddWithValue("@PayrollId", payroll.PayrollId);
            cmd.Parameters.AddWithValue("@EmployeeID", payroll.EmployeeID);
            cmd.Parameters.AddWithValue("@PayPeriodStartDate", payroll.PayPeriodStartDate);
            cmd.Parameters.AddWithValue("@PayPeriodEndDate", payroll.PayPeriodEndDate);
            cmd.Parameters.AddWithValue("@BasicSalary", payroll.BasicSalary);
            cmd.Parameters.AddWithValue("@OvertimePay", payroll.OvertimePay);
            cmd.Parameters.AddWithValue("@Deductions", payroll.Deductions);
            cmd.Parameters.AddWithValue("@NetSalary", payroll.NetSalary);

            cmd.Connection = sqlconnection;
            sqlconnection.Open();
            int addUserStatus = cmd.ExecuteNonQuery();

            sqlconnection.Close();
            cmd.Parameters.Clear();

            return addUserStatus;
        }

        private bool PayrollExists(int id)
        {

            SqlConnection sqlconnection = new SqlConnection(DbConnUtil.GetConnectionString()); ;
            SqlCommand cmd = new SqlCommand(); ;
            cmd.CommandText = "select * from Payroll where PayrollID = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = sqlconnection;
            sqlconnection.Open();

            object obj = cmd.ExecuteScalar();
            //Console.WriteLine(obj);
            return obj != null;
        }

        public Payroll GetPayrollById(int id)
        {

            try
            {
                if (!PayrollExists(id))
                {
                    throw new PayrollGenerationException($"Payroll record not found for Payroll id-{id}");
                }

                cmd.CommandText = "select * from Payroll where PayrollID = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();

                Payroll payroll = new Payroll();


                while (reader.Read())
                {
                    payroll.PayrollId = (int)reader["PayrollId"];
                    payroll.EmployeeID = (int)reader["EmployeeID"];
                    payroll.PayPeriodStartDate = (DateTime)reader["PayPeriodStartDate"];
                    payroll.PayPeriodEndDate = (DateTime)reader["PayPeriodEndDate"];
                    payroll.BasicSalary = (int)reader["BasicSalary"];
                    payroll.OvertimePay = (int)reader["OvertimePay"];
                    payroll.Deductions = (int)reader["Deductions"];
                    payroll.NetSalary = (int)reader["NetSalary"];


                }

                return payroll;
            }

            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (PayrollGenerationException ex)
            {
                Console.WriteLine($"Error occured : {ex.Message}");
            }
            finally
            {
                sqlconnection.Close();
            }

            return null;
        }

        private bool PayrollExistsFoEmployee(int empId)
        {

            SqlConnection sqlconnection = new SqlConnection(DbConnUtil.GetConnectionString()); ;
            SqlCommand cmd = new SqlCommand(); ;
            cmd.CommandText = "select * from Payroll where EmployeeID = @empId";
            cmd.Parameters.AddWithValue("@empId", empId);
            cmd.Connection = sqlconnection;
            sqlconnection.Open();

            object obj = cmd.ExecuteScalar();
            //Console.WriteLine(obj);
            return obj != null;
        }

        public Payroll GetPayrollsForEmployee(int empId)
        {
            try
            {
                if (!PayrollExistsFoEmployee(empId))
                {
                    throw new PayrollGenerationException($"Payroll record not found for employee id-{empId}");
                }

                cmd.CommandText = "select * from Payroll where EmployeeID = @empId";
                cmd.Parameters.AddWithValue("@empId", empId);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();

                Payroll payroll = new Payroll();


                while (reader.Read())
                {
                    payroll.PayrollId = (int)reader["PayrollId"];
                    payroll.EmployeeID = (int)reader["EmployeeID"];
                    payroll.PayPeriodStartDate = (DateTime)reader["PayPeriodStartDate"];
                    payroll.PayPeriodEndDate = (DateTime)reader["PayPeriodEndDate"];
                    payroll.BasicSalary = (int)reader["BasicSalary"];
                    payroll.OvertimePay = (int)reader["OvertimePay"];
                    payroll.Deductions = (int)reader["Deductions"];
                    payroll.NetSalary = (int)reader["NetSalary"];


                }


                return payroll;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PayrollGenerationException ex)
            {
                Console.WriteLine($"Error occured : {ex.Message}");
            }
            finally
            {
                sqlconnection.Close();
            }

            return null;
        }

        public List<Payroll> GetPayrollsForPeriod(DateTime startDate, DateTime endDate)
        {
            cmd.CommandText = "select * from Payroll where PayPeriodStartDate = @startDate and PayPeriodEndDate = @endDate";
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);
            cmd.Connection = sqlconnection;
            sqlconnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.Parameters.Clear();

            List<Payroll> payrollList = new List<Payroll>();

            while (reader.Read())
            {
                Payroll payroll = new Payroll();
                payroll.PayrollId = (int)reader["PayrollId"];
                payroll.EmployeeID = (int)reader["EmployeeID"];
                payroll.PayPeriodStartDate = (DateTime)reader["PayPeriodStartDate"];
                payroll.PayPeriodEndDate = (DateTime)reader["PayPeriodEndDate"];
                payroll.BasicSalary = (int)reader["BasicSalary"];
                payroll.OvertimePay = (int)reader["OvertimePay"];
                payroll.Deductions = (int)reader["Deductions"];
                payroll.NetSalary = (int)reader["NetSalary"];
                payrollList.Add(payroll);

            }
            sqlconnection.Close();

            return payrollList;
        }
    }
}


