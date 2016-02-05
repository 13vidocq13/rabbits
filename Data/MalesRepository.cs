using System;
using System.Collections.Generic;
using System.Linq;
using Contract;
using Entities;

namespace Data
{
    public class MalesRepository : IMalesRepository
    {
        private const string AlreadyExist = "самец с такой кличкой уже существует";
        private const string NotFound = "самец не найден";

        public IList<Males> GetMales()
        {
            using (var context = new RabbitsDBEntities())
            {
                return context.Males.ToList();
            }
        }

        public Males GetMale(int maleId)
        {
            using (var context = new RabbitsDBEntities())
            {
                return context.Males.FirstOrDefault(x => x.Id == maleId);
            }
        }

        public void AddMale(Males male)
        {
            using (var context = new RabbitsDBEntities())
            {
                if (IsNameExist(male.Name, context))
                    throw new InvalidOperationException(AlreadyExist);

                context.Males.Add(male);
                context.SaveChanges();
            }
        }

        public void UpdateMale(Males male)
        {
            using (var context = new RabbitsDBEntities())
            {
                if (IsNameExist(male.Name, context))
                    throw new InvalidOperationException(AlreadyExist);

                var result = context.Males.FirstOrDefault(x => x.Id == male.Id);
                if (result == null)
                    throw new InvalidOperationException(NotFound);

                result.Name = male.Name;

                context.SaveChanges();
            }
        }

        public void DeleteMale(int maleId)
        {
            using (var context = new RabbitsDBEntities())
            {
                var result = context.Males.FirstOrDefault(x => x.Id == maleId);
                if (result == null)
                    throw new InvalidOperationException(NotFound);

                context.Males.Remove(result);
                context.SaveChanges();
            }
        }

        static bool IsNameExist(string maleName, RabbitsDBEntities context)
        {
            return context.Males.Count(x => x.Name == maleName) > 0;
        }
    }
}
