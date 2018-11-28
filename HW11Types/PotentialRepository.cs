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
            Console.WriteLine("This Code executed in PotentialRepository.");
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

        public IEnumerable<Potential> GetAllCards()
        {
            return dataStore.GetAllPotentials();
        }

        public Potential GetASpecificId(int index)
        {
            Console.WriteLine("This GetASpecificId executed in PotentialRepository.");
            return dataStore.GetPotentialById(index);
        }
    }
}
