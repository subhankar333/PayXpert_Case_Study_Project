using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Repository
{
    internal interface ITaxRepository
    {
        int CalculateTax(int empId, int taxYear);
        void GetTaxById(int id);
        void GetTaxesForEmployee(int empid);
        void GetTaxesForYear(int taxYear);
    }
}
