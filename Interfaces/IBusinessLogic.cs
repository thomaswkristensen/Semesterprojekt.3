﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Interfaces
{
    public interface IBusinessLogic
    {
        void ZeroAdjust(List<double> dataList);
        Patient_DTO getSSN(string SSN);
    }
}
