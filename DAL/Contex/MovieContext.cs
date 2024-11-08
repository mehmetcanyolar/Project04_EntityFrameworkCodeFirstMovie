using Project04_EntityFrameworkCodeFirstMovie.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project04_EntityFrameworkCodeFirstMovie.DAL.Contex
{
    public class MovieContext:DbContext
    {
        //Bağlantı adresi context sınıfı üzerinden verilecek.Burası bağlantı stringlerinin tutulduğu folder 

       public DbSet<Movie> Movies { get; set; } // movie class ımı sql de Movies isimli bir tabloya dönüştürme işlemi, class name is odd, table name is plural


        public DbSet<Category> Categories { get; set; }
    }
}
