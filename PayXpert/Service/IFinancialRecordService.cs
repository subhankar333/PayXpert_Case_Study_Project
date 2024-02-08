﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Service
{
    internal interface IFinancialRecordService
    {
        void AddFinancialRecord();
        void GetFinancialRecordById();
        void GetFinancialRecordsForEmployee();

        void GetFinancialRecordsForDate();
    }
}
