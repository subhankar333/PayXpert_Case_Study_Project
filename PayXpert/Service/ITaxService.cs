using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Service
{
    internal interface ITaxService
    {
        void CalculateTax();
        void GetTaxById();
        void GetTaxesForEmployee();
        void GetTaxesForYear();
    }
}
