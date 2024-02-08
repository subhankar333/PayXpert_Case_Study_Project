using PayXpert.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Repository
{
    internal interface IFinancialRecordRepository
    {
        int AddFinancialRecord(int recordId, int empId, string description, int amount, string recordType);
        FinancialRecord GetFinancialRecordById(int recordId);
        List<FinancialRecord> GetFinancialRecordsForEmployee(int empId);
        List<FinancialRecord> GetFinancialRecordsForDate(DateTime dateOfRecord);
    }
}
