﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisnesslogic
{
    class RawFilter : IFilter
    {
        public List<double> Filtering(List<double> list)
        {
            return list;
        }
    }
}
