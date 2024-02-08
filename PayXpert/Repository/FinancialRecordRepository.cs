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
    internal class FinancialRecordRepository : IFinancialRecordRepository
    {
        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;
        public FinancialRecordRepository()
        {
            sqlconnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        public int AddFinancialRecord(int recordId, int empId, string description, int amount, string recordType)
        {
            FinancialRecord financialrecord = new FinancialRecord();
            financialrecord.RecordID = recordId;
            financialrecord.EmployeeID = empId;
            financialrecord.Description = description;
            financialrecord.Amount = amount;
            financialrecord.RecordType = recordType;

            cmd.CommandText = "insert into FinancialRecord values (@RecordID, @EmployeeID, @RecordDate, @Description, @Amount, @RecordType)";
            cmd.Parameters.AddWithValue("@RecordID", financialrecord.RecordID);
            cmd.Parameters.AddWithValue("@EmployeeID", financialrecord.EmployeeID);
            cmd.Parameters.AddWithValue("@RecordDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@Description", financialrecord.Description);
            cmd.Parameters.AddWithValue("@Amount", financialrecord.Amount);
            cmd.Parameters.AddWithValue("@RecordType", financialrecord.RecordType);

            cmd.Connection = sqlconnection;
            sqlconnection.Open();
            int addUserStatus = cmd.ExecuteNonQuery();

            sqlconnection.Close();
            cmd.Parameters.Clear();

            return addUserStatus;
        }


        private bool FinancialRecordExists(int recordId)
        {
            SqlConnection sqlconnection = new SqlConnection(DbConnUtil.GetConnectionString()); ;
            SqlCommand cmd = new SqlCommand(); ;
            cmd.CommandText = "select * from FinancialRecord where recordId = @recordId";
            cmd.Parameters.AddWithValue("@recordId", recordId);
            cmd.Connection = sqlconnection;
            sqlconnection.Open();

            object obj = cmd.ExecuteScalar();
            //Console.WriteLine(obj);
            return obj != null;
        }

        private bool FinancialRecordExistsForEmployee(int empId)
        {
            SqlConnection sqlconnection = new SqlConnection(DbConnUtil.GetConnectionString()); ;
            SqlCommand cmd = new SqlCommand(); ;
            cmd.CommandText = "select * from FinancialRecord where EmployeeID = @empId";
            cmd.Parameters.AddWithValue("@empId", empId);
            cmd.Connection = sqlconnection;
            sqlconnection.Open();

            object obj = cmd.ExecuteScalar();
            //Console.WriteLine(obj);
            return obj != null;
        }

        private bool FinancialRecordExistsForDate(DateTime dateOfRecord)
        {
            SqlConnection sqlconnection = new SqlConnection(DbConnUtil.GetConnectionString()); ;
            SqlCommand cmd = new SqlCommand(); ;
            cmd.CommandText = "select * from FinancialRecord where RecordDate = @dateOfRecord";
            cmd.Parameters.AddWithValue("@dateOfRecord", dateOfRecord);
            cmd.Connection = sqlconnection;
            sqlconnection.Open();

            object obj = cmd.ExecuteScalar();
            //Console.WriteLine(obj);
            return obj != null;
        }

        public FinancialRecord GetFinancialRecordById(int recordId)
        {

            try
            {
                if (!FinancialRecordExists(recordId))
                {
                    throw new FinancialRecordException($"Financial record not found for id-{recordId}");
                }

                cmd.CommandText = "select * from FinancialRecord where RecordID = @recordId";
                cmd.Parameters.AddWithValue("@recordId", recordId);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();

                FinancialRecord financialRecord = new FinancialRecord();


                while (reader.Read())
                {
                    financialRecord.RecordID = (int)reader["RecordID"];
                    financialRecord.EmployeeID = (int)reader["EmployeeID"];
                    financialRecord.RecordDate = (DateTime)reader["RecordDate"];
                    financialRecord.Description = (string)reader["Description"];
                    financialRecord.Amount = (int)reader["Amount"];
                    financialRecord.RecordType = (string)reader["RecordType"];

                }


                return financialRecord;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FinancialRecordException ex)
            {
                Console.WriteLine($"Error occured : {ex.Message}");
            }
            finally
            {
                sqlconnection.Close();
            }

            return null;
        }

        public List<FinancialRecord> GetFinancialRecordsForEmployee(int empId)
        {

            try
            {
                if (!FinancialRecordExistsForEmployee(empId))
                {
                    throw new FinancialRecordException($"Financial record not found for id-{empId}");
                }

                cmd.CommandText = "select * from FinancialRecord where EmployeeID = @empId";
                cmd.Parameters.AddWithValue("@empId", empId);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();

                
                List<FinancialRecord> financialrecordList = new List<FinancialRecord>();

                while (reader.Read())
                {
                    FinancialRecord financialRecord = new FinancialRecord();
                    financialRecord.RecordID = (int)reader["RecordID"];
                    financialRecord.EmployeeID = (int)reader["EmployeeID"];

                    var _recordDate = reader["RecordDate"];
                    if(_recordDate != DBNull.Value)
                    {
                       financialRecord.RecordDate = (DateTime)reader["RecordDate"];
                    }
                    else
                    {
                        financialRecord.RecordDate = DateTime.Now;
                    }

                    financialRecord.Description = (string)reader["Description"];
                    financialRecord.Amount = (int)reader["Amount"];
                    financialRecord.RecordType = (string)reader["RecordType"];
                    financialrecordList.Add(financialRecord);
                }


                return financialrecordList;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FinancialRecordException ex)
            {
                Console.WriteLine($"Error occured : {ex.Message}");
            }
            finally
            {
                sqlconnection.Close();
            }

            return null;

        }

        public List<FinancialRecord> GetFinancialRecordsForDate(DateTime dateOfRecord)
        {
            try
            {
                if (!FinancialRecordExistsForDate(dateOfRecord))
                {
                    throw new FinancialRecordException($"Financial record not found on {dateOfRecord}");
                }

                cmd.CommandText = "select * from FinancialRecord where RecordDate = @dateOfRecord";
                cmd.Parameters.AddWithValue("@dateOfRecord", dateOfRecord);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();

                List<FinancialRecord> financialRecordList = new List<FinancialRecord>();

                while (reader.Read())
                {
                    FinancialRecord financialRecord = new FinancialRecord();
                    financialRecord.RecordID = (int)reader["RecordID"];
                    financialRecord.EmployeeID = (int)reader["EmployeeID"];
                    financialRecord.RecordDate = (DateTime)reader["RecordDate"];
                    financialRecord.Description = (string)reader["Description"];
                    financialRecord.Amount = (int)reader["Amount"];
                    financialRecord.RecordType = (string)reader["RecordType"];
                    financialRecordList.Add(financialRecord);
                }


                return financialRecordList;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FinancialRecordException ex)
            {
                Console.WriteLine($"Error occured : {ex.Message}");
            }
            finally
            {
                sqlconnection.Close();
            }

            return null;
        }

    }
}


