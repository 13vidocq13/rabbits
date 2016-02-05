using System.Collections.Generic;
using Entities;

namespace Contract
{
    public interface IFemalesRepository
    {
        IList<Females> GetFemales();
        Females GetFemale(int femaleId);
        void AddFemale(Females female);
        void UpdateFemale(Females female);
        void DeleteFemale(int femaleId);
    }
}
