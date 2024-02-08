using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Model
{
    public class Tax
    {
        public int TaxID { get; set; }
        public int EmployeeID { get; set; }
        public int TaxYear { get; set; }
        public int TaxableIncome { get; set; }
        public int TaxAmount { get; set; }

        public Tax()
        {

        }

        public override string ToString()
        {
            return $"TaxID:: {TaxID}\t EmployeeID:: {EmployeeID} TaxYear:: {TaxYear}\t TaxableIncome:: {TaxableIncome}\t TaxAmount:: {TaxAmount}";
        }
    }
}
