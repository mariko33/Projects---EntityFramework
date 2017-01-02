using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalSystem;
using HospitalSystem.Models;

namespace HospitalSystemClient2
{
    public partial class DoctorPatients : Form
    {
        HospitalDatabse context=new HospitalDatabse();
        Doctor doctor=new Doctor();
        
        
        public DoctorPatients()
        {
            InitializeComponent();
        }

        public DoctorPatients(int Id)
        {
            int curentId = Id;
            InitializeComponent();
            this.doctor = context.Doctors.FirstOrDefault(d => d.Id == Id);

        }

        private void DoctorPatients_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f=new Form1(doctor.Id);
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
