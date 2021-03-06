﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Interfaces;
using ObserverPattern;

namespace Buisnesslogic
{
    public class BusinessController : IBusinessLogic
    {
        private IDataAccesLogic _DAL;
        private Zero_pointAdjusment _ZPA;
        private Calibration _calibration;
        private HP_DTO _hpDTO;
        private Login _login;
        private Filter _filter;
        private Consumer _consumer;
        private ThreadControllerBL _threadController;
        private Converter _converter;
        private FilterContainer _filterContainer;
        private AnalysisContainer _analysisContainer;
        private Alarm _alarm;
        public BusinessController(IDataAccesLogic DAL, Consumer consumer, FilterContainer filterContainer, AnalysisContainer analysisContainer)
        {
            _DAL = DAL;
            _calibration = new Calibration();
            _ZPA = new Zero_pointAdjusment();
            _alarm = new Alarm();
            _hpDTO = new HP_DTO();
            _login = new Login();
            _filter = new Filter(filterContainer);
            _consumer = consumer;
            _threadController = new ThreadControllerBL(_consumer);
            _converter = new Converter();
            _filterContainer = filterContainer;
            _analysisContainer = analysisContainer;

        }

        public void StartZPA()
        {
            _DAL.ZPAVolt = _ZPA.CalculateZPA(_DAL.PullData());
            //_DAL.ZPAVolt = 0.01613;
        }

        public bool StartCalibration(int value)
        {
            return _calibration.Calibrate(_DAL.PullData(), value);
        }

        public Calibration_DTO ViewCalibration()
        {
            return _calibration.ShowCalibration(_DAL.ZPAVolt);
        }

        public Calibration_DTO ChangeSlope(double slope)
        {

            return _calibration.ChangeCalibration(slope);
        }

        public bool GetLogin(string employeeID, string password)
        {
            _hpDTO = _DAL.getLoginDatabase(employeeID);

            return _login.get_Login(employeeID, password, _hpDTO);
        }

        public bool SaveMeasurementBusiness(Measurement_DTO measurementDTO, string ssn, string employeeID)
        {
            if (_DAL.SaveMeasurementDataAcces(measurementDTO, ssn, employeeID))
            {
                return true;
            }
            return false;
        }

        public void UseDigitalFilterBL()
        {
            _filter.UseDigitalFilter();
        }


        public Patient_DTO GetPatientInformation(string ssn)
        {
            Patient_DTO patient;

            patient = _DAL.verifySSN(ssn);

            return patient;
        }

        public bool SaveCalibrationLogic(Calibration_DTO calibrationData)
        {
            if (_DAL.SaveCalibrationDataAcces(calibrationData))
            {
                return true;
            }
            return false;

        }

        public void SetAlarmLimitsBusiness(Alarm_DTO alarmDTO)
        {
            _DAL.SetAlarmLimitsDataAccess(alarmDTO);
        }

        public void StartMeasuringBL()
        {
            
            _consumer.SetConverter(_converter);
            _converter.SetDependencies(_analysisContainer,_filter,_alarm, _DAL.ZPAVolt,_DAL.PullSlope());
            _alarm.Limits(_DAL.GetAlarmLimitsDataAcces());
            if(_DAL.PullData()==null)
            {
                System.Windows.Forms.MessageBox.Show("Data ikke til rådighed, tjek om udstyret er sat til");
            }
            else
            {
                _threadController.CreateThread();
                _DAL.StartMeasuringDAL();
            }



        }

       
        public void StopMeasuringBL()
        {
            _DAL.StopMeasuringDAL();
            _threadController.StopThread();
            
        }

        public void StopAlarm()
        {
            _alarm.AlarmStop = true;
            _alarm.Tone = false;
        }

        public void StartAlarm()
        {
            _alarm.AlarmStop = false;
        }

        public void StopAlarmTone()
        {
            _alarm.StopTone();
            _alarm.Tone = true;  
        }

    }

    
}
