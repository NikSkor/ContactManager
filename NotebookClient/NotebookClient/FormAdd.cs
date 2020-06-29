using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using NotebookAPI.Models;

namespace NotebookClient
{
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();

        }

        public Person Person
        {
            get
            {
                return new Person() { Firstname = tbName.Text, Secondname = tbSurname.Text, BirthDay = dateTimePicker.Value };
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            DialogResult = DialogResult.OK;
            Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
