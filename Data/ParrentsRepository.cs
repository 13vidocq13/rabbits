using System;
using System.Linq;
using Contract;
using Entities;

namespace Data
{
    public class ParrentsRepository : IParrentsRepository
    {
        private const string NotFound = "родители не найдены";

        public Parrents GetParrents(int femaleId)
        {
            using (var context = new RabbitsDBEntities())
            {
                return context.Parrents.FirstOrDefault(x => x.FemaleId == femaleId);
            }
        }

        public void AddParrents(Parrents parrents)
        {
            using (var context = new RabbitsDBEntities())
            {
                context.Parrents.Add(parrents);
                context.SaveChanges();
            }
        }

        public void UpdateParrents(Parrents parrents)
        {
            using (var context = new RabbitsDBEntities())
            {
                var entity = context.Parrents.FirstOrDefault(x => x.Id == parrents.Id);

                if(entity == null)
                    throw new InvalidOperationException(NotFound);

                entity.FatherId1 = parrents.FatherId1;
                entity.FatherId2 = parrents.FatherId2;
                entity.MotherId = parrents.MotherId;

                context.SaveChanges();
            }
        }

        public void DeleteParrents(int parrentsId)
        {
            using (var context = new RabbitsDBEntities())
            {
                var entity = context.Parrents.FirstOrDefault(x => x.Id == parrentsId);

                if (entity == null)
                    throw new InvalidOperationException(NotFound);

                context.Parrents.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
