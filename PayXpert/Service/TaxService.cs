using PayXpert.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Service
{
    internal class TaxService : ITaxService
    {
        readonly ITaxRepository _taxRepository;

        public TaxService()
        {
            _taxRepository = new TaxRepository();
        }

        public void CalculateTax()
        {
            Console.WriteLine("Enter id of the employee :");
            int empId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Tax year:");
            int taxYear = int.Parse(Console.ReadLine());

            int tax_amount = _taxRepository.CalculateTax(empId, taxYear);
            if(tax_amount > 0)
            {
                Console.WriteLine($"Tax Amount : {tax_amount} ");
            }
        }

        public void GetTaxById()
        {
            Console.WriteLine("Enter id of tax:");
            int id = int.Parse(Console.ReadLine());
            _taxRepository.GetTaxById(id);
        }

        public void GetTaxesForEmployee()
        {
            Console.WriteLine("Enter id of the employee:");
            int empid = int.Parse(Console.ReadLine());
            _taxRepository.GetTaxById(empid);
        }

        public void GetTaxesForYear()
        {
            Console.WriteLine("Enter tax year:");
            int taxYear = int.Parse(Console.ReadLine());
            _taxRepository.GetTaxesForYear(taxYear);
        }
    }
}


