﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLogic
{
    public partial class HomeForm : Form
    {
        private LogInForm Login;
        public HomeForm()
        {
            InitializeComponent();
        }

        private void Save_button_HomeForm_Click(object sender, EventArgs e)
        {
            Login.Show();
            
        }
    }
}
