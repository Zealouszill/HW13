﻿using HW11Types;
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
            context = new PotentialGirlfriendsContext();
        }

        public SqliteDataStore()
        {
            context = new PotentialGirlfriendsContext();
        }

        public void AddPotential(Potential p)
        {
            Console.WriteLine(p.FirstName);
            context.Potentials.Add(p);
            context.SaveChanges();
        }

        public void AddUserStats(UserProfileStats u)
        {
            context.UserStats.Add(u);
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

        public UserProfileStats GetUserStats()
        {
            return context.UserStats.Find((long)1);
        }

        public void ChangeUserStats(UserProfileStats u)
        {
            
            context.UserStats.Find((long)1).FirstName = u.FirstName;
            context.UserStats.Find((long)1).LastName = u.LastName;
            context.UserStats.Find((long)1).Age = u.Age;
            context.UserStats.Find((long)1).EnjoysSportsRating = u.EnjoysSportsRating;
            context.UserStats.Find((long)1).FrugalityRating = u.FrugalityRating;
            context.UserStats.Find((long)1).PhysicallyActiveRating = u.PhysicallyActiveRating;
            context.UserStats.Find((long)1).DesireForKidsRating = u.DesireForKidsRating;
            context.UserStats.Find((long)1).SenseOfHumorRating = u.SenseOfHumorRating;
            context.UserStats.Find((long)1).DrivenRating = u.DrivenRating;
            context.UserStats.Find((long)1).AdditionalDetails = u.AdditionalDetails;

            context.SaveChanges();
        }

        public string RemovePotentialById(int id)
        {
            try
            {
                context.Potentials.Remove(context.Potentials.Find((long)id));
            } catch
            {
                return "Was unable to remove potential";
            }
            
            context.SaveChanges();
            return "Potential Removed";
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
            optionbuilder.UseSqlite($@"Data Source=Sample.db");
        }

        public DbSet<Potential> Potentials { get; set; }
        public DbSet<UserProfileStats> UserStats { get; set; }

    }
}
