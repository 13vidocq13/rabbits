using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using Contract;
using Entities;

namespace Data
{
    public class CagesRepository : ICagesRepository
    {
        private const string AlreadyExist = "клетка с таким названием уже существует";
        private const string DoesNotExist = "клетка не найдена";

        public IList<Cages> GetCages()
        {
            using (var context = new RabbitsDBEntities())
            {
                return context.Cages.ToList();
            }
        }

        public Cages GetCage(int cageId)
        {
            using (var context = new RabbitsDBEntities())
            {
                return context.Cages.FirstOrDefault(x => x.Id == cageId);
            }
        }

        public void AddCage(Cages cage)
        {
            using (var context = new RabbitsDBEntities())
            {
                if (IsNameExist(cage.Name, context))
                    throw new InvalidOperationException(AlreadyExist);

                context.Cages.Add(cage);
                context.SaveChanges();
            }
        }

        public void UpdateCage(Cages cage)
        {
            using (var context = new RabbitsDBEntities())
            {
                if (IsNameExist(cage.Name, context))
                    throw new InvalidOperationException(AlreadyExist);

                var entity = context.Cages.FirstOrDefault(x => x.Id == cage.Id);

                if (entity == null)
                    throw new InvalidOperationException(DoesNotExist);

                entity.Name = cage.Name;

                context.SaveChanges();
            }
        }

        public void DeleteCage(int cageId)
        {
            using (var context = new RabbitsDBEntities())
            {
                var entity = context.Cages.FirstOrDefault(x => x.Id == cageId);

                if (entity == null)
                    throw new InvalidOperationException(DoesNotExist);

                context.Cages.Remove(entity);
                context.SaveChanges();
            }
        }

        static bool IsNameExist(string cageName, RabbitsDBEntities context)
        {
            return context.Cages.Count(x => x.Name == cageName) > 0;
        }
    }
}
