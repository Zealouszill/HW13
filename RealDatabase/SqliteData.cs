using HW11Types;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace HW11Database
{
    public class SqliteDataStore : IDataStorage
    {
        private readonly PotentialGirlfriendsContext context;
        //private readonly string dbPath;

        public SqliteDataStore(string dbPath)
        {
            //this.dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));
            context = new PotentialGirlfriendsContext();
        }

        public SqliteDataStore()
        {
            context = new PotentialGirlfriendsContext();
        }

        public void AddPotential(Potential p)
        {            
            context.Potentials.Add(p);
            context.SaveChanges();
        }

        public IEnumerable<Potential> GetAllPotentials()
        {
            return context.Potentials;
        }

        public Potential GetPotentialById(int id)
        {
            return context.Potentials.Find((long)id);
        }

        public void RemovePotentialById(int id)
        {
            context.Potentials.Remove(context.Potentials.Find((long)id));
            context.SaveChanges();

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
