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
    public partial class Form1 : Form
    {
        HospitalDatabse context = new HospitalDatabse();
        Patient patient=new Patient();
        Doctor doctor=new Doctor();
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(int Id)
        {
            InitializeComponent();
            this.doctor = context.Doctors.FirstOrDefault(d => d.Id == Id);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.doctor.Patients.Add(patient);
           // this.context.Patients.Add(patient);
            this.context.SaveChanges();
            this.Controls.Clear();
            this.InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.patient.LastName = LastNamePatient.Text;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoctorPatients dp=new DoctorPatients();
            dp.Show();
            this.Hide();
        }

        private void FirstNamePatient_TextChanged(object sender, EventArgs e)
        {
            this.patient.FirstName = FirstNamePatient.Text;
        }

        private void Adress_TextChanged(object sender, EventArgs e)
        {
            this.patient.Address = Adress.Text;
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {
            this.patient.Email = Email.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
