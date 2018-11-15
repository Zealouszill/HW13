using Microsoft.EntityFrameworkCore;
using System;

namespace HW11Database
{
    public class SampleDBContext : DbContext
    {
        private static bool _created = false;
        public SampleDBContext()
        {
            if (!_created)
            {
                Console.WriteLine("I wroke tehise");
                _created = true;

                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=Sample.db");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
