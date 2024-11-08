using Project04_EntityFrameworkCodeFirstMovie.DAL.Contex;
using Project04_EntityFrameworkCodeFirstMovie.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project04_EntityFrameworkCodeFirstMovie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MovieContext context = new MovieContext(); 
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = context.Categories.ToList();

            dataGridView1.DataSource = values;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName=txtName.Text;
            context.Categories.Add(category);
            context.SaveChanges();
            MessageBox.Show("İşlem Başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            int id = int.Parse(txtId.Text);
            var values = context.Categories.Find(id);
            values.CategoryName = txtName.Text;
            context.SaveChanges();
            MessageBox.Show("İşlem başarılı");



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = context.Categories.Find(id);
            context.Categories.Remove(values);
            context.SaveChanges();
            MessageBox.Show("İşlem başarılı");

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var values = context.Categories.Where(x => x.CategoryName.Contains(txtName.Text)).ToList();
            //contains = içinde kelime harf geçenini getiren method
            dataGridView1.DataSource = values;

        }
    }
}
