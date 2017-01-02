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
    public partial class Doctors : Form
    {
        HospitalDatabse context=new HospitalDatabse();
        Doctor doctor=new Doctor();

        public Doctors()
        {
            InitializeComponent();
        }

        private void Doctors_Load(object sender, EventArgs e)
        {

        }

        private void Name_TextChanged(object sender, EventArgs e)
        {
            doctor.Name = DoctorName.Text;

        }

        private void Specialization_TextChanged(object sender, EventArgs e)
        {
            doctor.Speciality = Specialization.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            context.Doctors.Add(doctor);
            context.SaveChanges();
            this.Controls.Clear();
            this.InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartPage s=new StartPage();
            s.Show();
            this.Hide();

        }

        private void Doctors_Load_1(object sender, EventArgs e)
        {

        }
    }
}
