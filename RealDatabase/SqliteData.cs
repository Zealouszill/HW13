using HW11Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HW11Database
{
    public class SqliteDataStore : IDataStorage
    {
        private readonly PotentialGirlfriendsContext context;
        private readonly string dbPath;

        public SqliteDataStore(string dbPath)
        {
            this.dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));
            context = new PotentialGirlfriendsContext();
        }

        public SqliteDataStore()
        {
            context = new PotentialGirlfriendsContext();
        }

        public void AddPotential(Potential p)
        {
            Console.WriteLine("This Code executed in SqliteData.");
            
            context.Potentials.Add(p);
            context.SaveChanges();
        }

        public IEnumerable<Potential> GetAllPotentials()
        {
            return context.Potentials;
        }

        public Potential GetPotentialById(int id)
        {
            Console.WriteLine("This GetASpecificId executed in SqliteData.");
            
            long tempId = (long)id;

            Console.WriteLine(context.Potentials.Find(tempId));
            return context.Potentials.Find(tempId);
        }
    }

    public class PotentialGirlfriendsContext : DbContext
    {

        private static bool _created = false;

        public PotentialGirlfriendsContext()
        {
            if (!_created)
            {
                _created = true;

                //Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=Sample.db");
        }

        public DbSet<Potential> Potentials { get; set; }
    }
}
