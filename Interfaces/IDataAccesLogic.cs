﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace Interfaces
{
    public interface IDataAccesLogic
    {
        double ZPAVolt { get; set; }
        HP_DTO getLoginDatabase(string username);
        bool SaveCalibrationDataAcces(Calibration_DTO calibration);
        Patient_DTO verifySSN(string ssn);
        double PullSlope();
        bool SaveMeasurementDataAcces(Measurement_DTO measurementDTO, string ssn, string employeeID);
        void SetAlarmLimitsDataAccess(Alarm_DTO alarmDTO);

    }
}
