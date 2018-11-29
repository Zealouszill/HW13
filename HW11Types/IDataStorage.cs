﻿using System.Collections.Generic;

namespace HW11Types
{
    public interface IDataStorage
    {
        void AddPotential(Potential p);
        IEnumerable<Potential> GetAllPotentials();
        Potential GetPotentialById(int id);
        void RemovePotentialById(int id);
    }
}
