using PayXpert.Model;
using PayXpert.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Service
{
    internal class FinancialRecordService : IFinancialRecordService
    {
        readonly IFinancialRecordRepository _financialrecordrepository;  

        public FinancialRecordService()
        {
            _financialrecordrepository = new FinancialRecordRepository();
        }

        public void AddFinancialRecord()
        {
            try
            {
                Console.WriteLine("Enter id of the record:");
                int recordId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter id of the employee:");
                int empId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter description:");
                string description = (Console.ReadLine());

                Console.WriteLine("Enter amount:");
                int amount = int.Parse(Console.ReadLine());

                if(amount < 0)
                {
                    throw new InvalidDataException("Amount must be a positive value!");
                }

                Console.WriteLine("Enter type of the record:");
                string recordType = Console.ReadLine();

                int addStatus = _financialrecordrepository.AddFinancialRecord(recordId, empId, description, amount, recordType);
                if (addStatus > 0)
                {
                    Console.WriteLine("Record added successfully!");
                }
                else
                {
                    Console.WriteLine("Record not added");
                }
            }
            catch(InvalidDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void GetFinancialRecordById()
        {
            Console.WriteLine("Enter id of record:");
            int recordId = int.Parse(Console.ReadLine());
            FinancialRecord finalcialRecord = _financialrecordrepository.GetFinancialRecordById(recordId);
            Console.WriteLine(finalcialRecord);
        }

        public void GetFinancialRecordsForEmployee()
        {
            Console.WriteLine("Enter id of employee:");
            int empId = int.Parse(Console.ReadLine());
            List<FinancialRecord> financialRecordList = _financialrecordrepository.GetFinancialRecordsForEmployee(empId);
            if(financialRecordList != null)
            {
                foreach (var item in financialRecordList)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void GetFinancialRecordsForDate()
        {
            Console.WriteLine("Enter date of the record:");
            DateTime dateOfRecord = DateTime.Parse(Console.ReadLine());
            List<FinancialRecord> financialRecordList = _financialrecordrepository.GetFinancialRecordsForDate(dateOfRecord);
            if (financialRecordList != null)
            {
                foreach (var record in financialRecordList)
                {
                    Console.WriteLine(record);
                }
            }
        }
    }
}


