using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Model
{
    internal class FinancialRecord
    {
        public int RecordID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime RecordDate { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string RecordType { get; set; }

        public FinancialRecord()
        {

        }

        public override string ToString()
        {
            return $"RecordID:: {RecordID}\t EmployeeID:: {EmployeeID} RecordDate:: {RecordDate}\t Description:: {Description}\t Amount:: {Amount}\t RecordType:: {RecordType}";
        }
    }



}
