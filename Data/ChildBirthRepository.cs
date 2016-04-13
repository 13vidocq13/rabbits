using System;
using System.Collections.Generic;
using System.Linq;
using Contract;
using Entities;

namespace Data
{
    public class ChildBirthRepository : IChildBirthRepository
    {
        private const string NotFound = "история рождения не найдена";

        public IList<ChildBirth> GetChildBirth()
        {
            using (var context = new RabbitsDBEntities())
            {
                return context.ChildBirth.ToList();
            }
        }

        public IList<ChildBirth> GetChildBirth(Filters filter)
        {
            using (var context = new RabbitsDBEntities())
            {
                IQueryable<ChildBirth> query = context.ChildBirth;

                if (!string.IsNullOrEmpty(filter.MaleName))
                    query = query.Where(x => x.MaleId1 == new MalesRepository().GetMale(filter.MaleName).Id);

                if (!string.IsNullOrEmpty(filter.FemaleName))
                    query = query.Where(x => x.FemaleId == new FemalesRepository().GetFemale(filter.FemaleName).Id);

                if (filter.DateFrom.HasValue)
                    query = query.Where(x => x.Birthday >= filter.DateFrom);

                if (filter.DateTo.HasValue)
                    query = query.Where(x => x.Birthday <= filter.DateTo);

                return query.ToList();
            }
        }

        public ChildBirth GetChildBirth(int childBirthId)
        {
            using (var context = new RabbitsDBEntities())
            {
                return context.ChildBirth.FirstOrDefault(x => x.Id == childBirthId);
            }
        }

        public void AddChildBirth(ChildBirth childBirth)
        {
            using (var context = new RabbitsDBEntities())
            {
                context.ChildBirth.Add(childBirth);
                context.SaveChanges();
            }
        }

        public void UpdateChildBirth(ChildBirth childBirth)
        {
            using (var context = new RabbitsDBEntities())
            {
                var result = context.ChildBirth.FirstOrDefault(x => x.Id == childBirth.Id);
                if (result == null)
                    throw new InvalidOperationException(NotFound);

                result.FemaleId = childBirth.FemaleId;
                result.Birthday = childBirth.Birthday;
                result.ExpectBirthday = childBirth.ExpectBirthday;
                result.Notes = childBirth.Notes;
                result.MaleId1 = childBirth.MaleId1;
                result.MaleId2 = childBirth.MaleId2;
                result.StartDate1 = childBirth.StartDate1;
                result.StartDate2 = childBirth.StartDate2;
                result.ResultId = childBirth.ResultId;

                context.SaveChanges();
            }
        }

        public void DeleteChildBirth(int childBirthId)
        {
            using (var context = new RabbitsDBEntities())
            {
                var result = context.ChildBirth.FirstOrDefault(x => x.Id == childBirthId);
                if (result == null)
                    throw new InvalidOperationException(NotFound);

                context.ChildBirth.Remove(result);
                context.SaveChanges();
            }
        }
    }
}
