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
    public class TaxRepository : ITaxRepository
    {
        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;

        public TaxRepository()
        {
            sqlconnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        private bool TaxExistsForEmployeeAndYear(int empId, int taxYear)
        {
            SqlConnection sqlconnection = new SqlConnection(DbConnUtil.GetConnectionString()); ;
            SqlCommand cmd = new SqlCommand(); ;
            cmd.CommandText = "select * from Tax where EmployeeID = @empId and TaxYear = @taxYear";
            cmd.Parameters.AddWithValue("@empId", empId);
            cmd.Parameters.AddWithValue("@taxYear", taxYear);
            cmd.Connection = sqlconnection;
            sqlconnection.Open();

            object obj = cmd.ExecuteScalar();
            //Console.WriteLine(obj);
            return obj != null;
        }
        private bool TaxExists(int taxId)
        {
            SqlConnection sqlconnection = new SqlConnection(DbConnUtil.GetConnectionString()); ;
            SqlCommand cmd = new SqlCommand(); ;
            cmd.CommandText = "select * from Tax where TaxID = @taxId";
            cmd.Parameters.AddWithValue("@taxId", taxId);
            cmd.Connection = sqlconnection;
            sqlconnection.Open();

            object obj = cmd.ExecuteScalar();
            //Console.WriteLine(obj);
            return obj != null;
        }
        private bool TaxExistsForEmployee(int empId)
        {
            SqlConnection sqlconnection = new SqlConnection(DbConnUtil.GetConnectionString()); ;
            SqlCommand cmd = new SqlCommand(); ;
            cmd.CommandText = "select * from Tax where EmployeeID = @empId";
            cmd.Parameters.AddWithValue("@empId", empId);
            cmd.Connection = sqlconnection;
            sqlconnection.Open();

            object obj = cmd.ExecuteScalar();
            //Console.WriteLine(obj);
            return obj != null;
        }
        public int CalculateTax(int empId, int taxYear)
        {
            try
            {
                if (!TaxExistsForEmployeeAndYear(empId, taxYear))
                {
                    throw new TaxCalculationException($"Tax record not found for Employee id-{empId} and year-{taxYear}");
                }

                cmd.CommandText = "select * from Tax where EmployeeID = @empid and TaxYear = @taxYear";
                cmd.Parameters.AddWithValue("@empId", empId);
                cmd.Parameters.AddWithValue("@taxYear", taxYear);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Tax tax = new Tax();

                while (reader.Read())
                {
                    tax.TaxID = (int)reader["TaxID"];
                    tax.EmployeeID = (int)reader["EmployeeID"];
                    tax.TaxYear = (int)reader["TaxYear"];
                    tax.TaxableIncome = (int)reader["TaxableIncome"];
                    tax.TaxAmount = (int)reader["TaxAmount"];
                }


                return (tax.TaxableIncome*10)/100;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (TaxCalculationException ex)
            {
                Console.WriteLine($"Error occured : {ex.Message}");
            }
            finally
            {
                sqlconnection.Close();
                cmd.Parameters.Clear();
            }

            return 0;
        }
        public void GetTaxById(int id)
        {
            try
            {
                if (!TaxExists(id))
                {
                    throw new TaxCalculationException($"Tax record not found for id-{id}");
                }

                cmd.CommandText = "select * from Tax where TaxID = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Tax tax = new Tax();

                while (reader.Read())
                {
                    tax.TaxID = (int)reader["TaxID"];
                    tax.EmployeeID = (int)reader["EmployeeID"];
                    tax.TaxYear = (int)reader["TaxYear"];
                    tax.TaxableIncome = (int)reader["TaxableIncome"];
                    tax.TaxAmount = (int)reader["TaxAmount"];
                }

                Console.WriteLine(tax);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (TaxCalculationException ex)
            {
                Console.WriteLine($"Error occured : {ex.Message}");
            }
            finally
            {
                sqlconnection.Close();
                cmd.Parameters.Clear();
            }

        }
        public void GetTaxesForEmployee(int empid)
        {
            try
            {
                if (!TaxExistsForEmployee(empid))
                {
                    throw new TaxCalculationException($"Tax record not found for id-{empid}");
                }

                cmd.CommandText = "select * from Tax where EmployeeID = @empid";
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();

                Tax tax = new Tax();

                while (reader.Read())
                {
                    tax.TaxID = (int)reader["TaxID"];
                    tax.EmployeeID = (int)reader["EmployeeID"];
                    tax.TaxYear = (int)reader["TaxYear"];
                    tax.TaxableIncome = (int)reader["TaxableIncome"];
                    tax.TaxAmount = (int)reader["TaxAmount"];
                }


                Console.WriteLine(tax);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (TaxCalculationException ex)
            {
                Console.WriteLine($"Error occured : {ex.Message}");
            }
            finally
            {
                sqlconnection.Close();
            }

        }
        public void GetTaxesForYear(int taxYear)
        {
            cmd.CommandText = "select * from Tax where TaxYear = @taxYear";
            cmd.Parameters.AddWithValue("@taxYear", taxYear);
            cmd.Connection = sqlconnection;
            sqlconnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.Parameters.Clear();

            List<Tax> taxList = new List<Tax>();

            while (reader.Read())
            {
                Tax tax = new Tax();
                tax.TaxID = (int)reader["TaxID"];
                tax.EmployeeID = (int)reader["EmployeeID"];
                tax.TaxYear = (int)reader["TaxYear"];
                tax.TaxableIncome = (int)reader["TaxableIncome"];
                tax.TaxAmount = (int)reader["TaxAmount"];

                taxList.Add(tax);
            }
            sqlconnection.Close();


            foreach (Tax item in taxList)
            {
                Console.WriteLine(item);
            }
        }
    }
}

