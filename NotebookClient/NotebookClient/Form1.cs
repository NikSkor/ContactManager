using NotebookAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotebookClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const string _baseAddress = "http://localhost:15355/";
        private void btnRead_Click(object sender, EventArgs e)
        {
            Update();
        }

        private new void Update()
        {

            listView.Items.Clear();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                response = client.GetAsync("api/People").Result;
                if (response.IsSuccessStatusCode)
                {
                    Person[] reports = response.Content.ReadAsAsync<Person[]>().Result;
                    foreach (var p in reports)
                    {
                        var item = new ListViewItem(new[] { p.Firstname, p.Secondname, p.BirthDay.ToShortDateString() });
                        item.Tag = p.Id;
                        listView.Items.Add(item);
                    }
                }
            }

        }
        private void Delete(int delete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:15355/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.DeleteAsync("api/People/" + delete).Result;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count != 0)
            {
                int id = (int)listView.SelectedItems[0].Tag;

                Delete(id);

                Update();
            }

        }

        private void Add(Person newReport)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync("api/People", newReport).Result;

            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FormAdd frm = new FormAdd();
            if (frm.ShowDialog()==DialogResult.OK)
            {
                Add(frm.Person);
            }
            Update();
        }

        private void Reduct (int id, Person newReport)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PutAsJsonAsync($"api/People/{id}", newReport).Result;

            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if (listView.SelectedItems.Count != 0)
            {
                int id = (int)listView.SelectedItems[0].Tag;

                FormRed frm = new FormRed();
                
                frm.Person = new Person() { Firstname = listView.SelectedItems[0].Text, Secondname = listView.SelectedItems[0].SubItems[1].Text, BirthDay = DateTime.Parse(listView.SelectedItems[0].SubItems[2].Text) };
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var p = frm.Person;
                    p.Id = id;
                    Reduct(id, p);
                }
                Update();
            }
        }
    }
}
