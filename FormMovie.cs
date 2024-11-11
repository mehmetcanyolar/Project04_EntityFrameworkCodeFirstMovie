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
    public partial class FormMovie : Form
    {
        public FormMovie()
        {
            InitializeComponent();
        }

        MovieContext context = new MovieContext();  

        void CategoryList()
        {
            var values = context.Categories.ToList();
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
            cmbCategory.DataSource = values;

        }
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = context.Movies.ToList();
            dataGridView1.DataSource = values;
        }

        private void FormMovie_Load(object sender, EventArgs e)
        {
            CategoryList(); 
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie();

            movie.MovieTitle = txtName.Text;
            movie.Duration= int.Parse(txtDuration.Text);
            movie.Description = txtDescription.Text;
            movie.CreateDate = DateTime.Parse(mskDate.Text);   //DateTime formatı maskbox ta US sistemine göre
            movie.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            context.Movies.Add(movie);
            context.SaveChanges();
            MessageBox.Show("İşlem Başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
               var value = context.Movies.Find(id);
             
           

            context.Movies.Remove(value);

            context.SaveChanges();
            MessageBox.Show("İşlem Başarılı");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var values = context.Movies.Where(x=>x.MovieTitle==txtName.Text).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var value = context.Movies.Find(id);
            value.MovieTitle = txtName.Text;
            value.Duration = int.Parse(txtDuration.Text);
            value.Description = txtDescription.Text;
            value.CreateDate = DateTime.Parse(mskDate.Text);   //DateTime formatı maskbox ta US sistemine göre bilgisayardan alıyor sistem özellikle datetime ise ondan benim pc us formata göre
            value.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());


            context.SaveChanges();
            MessageBox.Show("İşlem Başarılı");
        }

        private void btnMovieWithCategory_Click(object sender, EventArgs e)
        {
            var values = context.Movies.Join(context.Categories,movies =>movies.CategoryId,category =>category.CategoryId,(movie,category)=> new
            {
                MovieId = movie.MovieId,
                MovieTitle=movie.MovieTitle,
                Description=movie.Description,
                Duration=movie.Duration,
                CategoryName=category.CategoryName
            }).ToList();

            dataGridView1.DataSource = values;
        }
    }
}
