using System.Collections.Generic;
using Entities;

namespace Contract
{
    public interface IMalesRepository
    {
        IList<Males> GetMales();
        Males GetMale(int maleId);
        void AddMale(Males male);
        void UpdateMale(Males male);
        void DeleteMale(int maleId);
    }
}
