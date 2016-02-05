using System.Collections.Generic;
using Data;
using Entities;

namespace BusonessLogic
{
    public class CagesManager
    {
        public IList<Cages> GetCages()
        {
            return new CagesRepository().GetCages();
        }

        public Cages GetCage(int cageId)
        {
            return new CagesRepository().GetCage(cageId);
        }

        public void AddCage(Cages cage)
        {
            new CagesRepository().AddCage(cage);
        }

        public void UpdateCage(Cages cage)
        {
            new CagesRepository().UpdateCage(cage);
        }

        public void DeleteCage(int cageId)
        {
            new CagesRepository().DeleteCage(cageId);
        }
    }
}
