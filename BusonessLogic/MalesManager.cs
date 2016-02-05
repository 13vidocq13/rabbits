using System.Collections.Generic;
using Data;
using Entities;

namespace BusonessLogic
{
    public class MalesManager
    {
        public IList<Males> GetMales()
        {
            return new MalesRepository().GetMales();
        }

        public Males GetMale(int maleId)
        {
            return new MalesRepository().GetMale(maleId);
        }

        public void AddMale(Males male)
        {
            new MalesRepository().AddMale(male);
        }

        public void UpdateMale(Males male)
        {
            new MalesRepository().UpdateMale(male);
        }

        public void DeleteMale(int maleId)
        {
            new MalesRepository().DeleteMale(maleId);
        }
    }
}
