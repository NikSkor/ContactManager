using NotebookAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotebookClient
{
    public partial class FormRed : Form
    {
        public FormRed()
        {
            InitializeComponent();
        }
        public Person Person
        {
            get
            {
               return new Person() { Firstname = tbName.Text, Secondname = tbSurname.Text, BirthDay = dateTimePicker.Value };
            }

            set
            {
                tbName.Text = value.Firstname;
                tbSurname.Text = value.Secondname;
                dateTimePicker.Value = value.BirthDay;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
