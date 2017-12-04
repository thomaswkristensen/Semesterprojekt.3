﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;
using DTO;

namespace PresentationLogic
{
    public partial class SSNForm : Form
    {
        private IBusinessLogic _BL;
        private string _employeeID;
        private Measurement_DTO _measurementDTO;
        public SSNForm(IBusinessLogic BL, string employeeID, Measurement_DTO measurementDTO)
        {
            InitializeComponent();
            _BL = BL;
            _employeeID = employeeID;
            _measurementDTO = measurementDTO;

        }

        private void save_button_Click(object sender, EventArgs e)
        {
            _BL.SaveMeasurementBusiness(_measurementDTO, SSN_textBox.Text, employeeID_textBox.Text);
        }

        private void information_button_Click(object sender, EventArgs e)
        {
            Patient_DTO patientDTO = _BL.GetPatientInformation(SSN_textBox.Text);
            if (patientDTO != null && patientDTO.Age != 0)
            {
                name_textBox.Text = patientDTO.FirstName + " " + patientDTO.LastName;
                age_textBox.Text = Convert.ToString(patientDTO.Age);
                employeeID_textBox.Text = _employeeID;
                save_button.Enabled = true;
            }
            else
            {
                name_textBox.Clear();
                age_textBox.Clear();
                employeeID_textBox.Clear();
                save_button.Enabled = false;
                MessageBox.Show("Patient ikke fundet");
            }
        }
    }
}
