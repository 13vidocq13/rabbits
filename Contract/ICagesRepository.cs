using System.Collections.Generic;
using Entities;

namespace Contract
{
    public interface ICagesRepository
    {
        IList<Cages> GetCages();
        Cages GetCage(int cageId);
        void AddCage(Cages cage);
        void UpdateCage(Cages cage);
        void DeleteCage(int cageId);
    }
}
