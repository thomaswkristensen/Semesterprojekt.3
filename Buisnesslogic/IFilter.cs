﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisnesslogic
{
    interface IFilter
    {
        List<double> Filtering(List<double> list);
    }
}
