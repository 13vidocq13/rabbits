using System;
using System.Collections.Generic;
using System.Linq;
using Contract;
using Entities;

namespace Data
{
    public class FemalesRepository : IFemalesRepository
    {
        private const string AlreadyExist = "самка с таким именем уже существует";
        private const string DoesNotExist = "самка не найдена";

        public IList<Females> GetFemales()
        {
            using (var context = new RabbitsDBEntities())
            {
                return context.Females.ToList();
            }
        }

        public Females GetFemale(int femaleId)
        {
            using (var context = new RabbitsDBEntities())
            {
                return context.Females.FirstOrDefault(x => x.Id == femaleId);
            }
        }

        public IList<Females> GetFemales(int cageId)
        {
            using (var context = new RabbitsDBEntities())
            {
                return context.Females.Where(x => x.CageId == cageId).ToList();
            }
        }

        public Females GetFemale(string femaleName)
        {
            using (var context = new RabbitsDBEntities())
            {
                return context.Females.FirstOrDefault(x => x.Name == femaleName);
            }
        }

        public void AddFemale(Females female)
        {
            using (var context = new RabbitsDBEntities())
            {
                if (IsNameExist(female.Name, context))
                    throw new InvalidOperationException(AlreadyExist);

                context.Females.Add(female);
                context.SaveChanges();
            }
        }

        public void UpdateFemale(Females female)
        {
            using (var context = new RabbitsDBEntities())
            {
                var result = context.Females.FirstOrDefault(x => x.Id == female.Id);
                if (result == null)
                    throw new InvalidOperationException(DoesNotExist);

                if (result.Name != female.Name && IsNameExist(female.Name, context))
                    throw new InvalidOperationException(AlreadyExist);

                result.Name = female.Name;
                result.DateOfBirth = female.DateOfBirth;
                result.CageId = female.CageId;

                context.SaveChanges();
            }

        }

        public void DeleteFemaleFromCage(int femaleId)
        {
            using (var context = new RabbitsDBEntities())
            {
                var female = context.Females.FirstOrDefault(x => x.Id == femaleId);

                if (female == null)
                    throw new InvalidOperationException(DoesNotExist);

                female.CageId = null;

                context.SaveChanges();
            }
        }

        public void DeleteFemale(int femaleId)
        {
            using (var context = new RabbitsDBEntities())
            {
                var result = context.Females.FirstOrDefault(x => x.Id == femaleId);
                if (result == null)
                    throw new InvalidOperationException(DoesNotExist);

                context.Females.Remove(result);
                context.SaveChanges();
            }

        }

        static bool IsNameExist(string rabbitName, RabbitsDBEntities context)
        {
            return context.Females.Count(x => x.Name == rabbitName) > 0;
        }
    }
}
