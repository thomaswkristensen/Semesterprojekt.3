﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST2Prj2LibNI_DAQ;

namespace DataAccessLogic
{
    public class Data :IData
    {
        List<double> _data;
        private NI_DAQVoltage _datacollector;

        public Data()
        {
            _data = new List<double>();
            _datacollector = new NI_DAQVoltage();
            _datacollector.deviceName = "Dev1/ai0";

            _datacollector.rangeMaximumVolt = 5;
            _datacollector.samplesPerChannel = 5000;
            _datacollector.sampleRateInHz = 1000;

        }

        public List<double> getData()
        {

            _datacollector.getVoltageSeqBlocking();
            _data = _datacollector.currentVoltageSeq;

            return _data;

        }
        
        

    }
}