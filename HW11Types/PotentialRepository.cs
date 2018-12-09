using System;
using System.Collections.Generic;

namespace HW11Types
{
    public class PotentialRepository
    {
        private readonly IDataStorage dataStore;

        public PotentialRepository(IDataStorage dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        public bool AddPotential(Potential p)
        {
            try
            {
                dataStore.AddPotential(p);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Potential> GetAllPotentials()
        {
            return dataStore.GetAllPotentials();
        }

        public void AddUserProfile(UserProfileStats u)
        {
            dataStore.AddUserStats(u);
        }

        public Potential GetASpecificId(int index)
        {
            return dataStore.GetPotentialById(index);
        }

        public string RemovePotentialById(int id)
        {
            return dataStore.RemovePotentialById(id);
        }
    }
}
