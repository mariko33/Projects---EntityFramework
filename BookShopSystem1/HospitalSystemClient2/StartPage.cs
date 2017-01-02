using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalSystem.Models;

namespace HospitalSystemClient2
{
    public partial class StartPage : Form
    {
       
        public StartPage()
        {
            InitializeComponent();
        }

        private void DoctorId_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Doctors d=new Doctors();
            d.Show();
            this.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Id = int.Parse(DoctorId.Text);
            DoctorPatients dp=new DoctorPatients(Id);
            dp.Show();
            this.Hide();
        }
    }
}
