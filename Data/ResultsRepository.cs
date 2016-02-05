using System;
using System.Collections.Generic;
using System.Linq;
using Contract;
using Entities;

namespace Data
{
    public class ResultsRepository : IResultsRepository
    {
        private const string ResultExist = "результат с данным названием уже существует";
        private const string ResultNotFound = "результат не найден";

        public IList<Results> GetResults()
        {
            using (var context = new RabbitsDBEntities())
            {
                return context.Results.ToList();
            }
        }

        public Results GetResult(int resultId)
        {
            using (var context = new RabbitsDBEntities())
            {
                return context.Results.FirstOrDefault(x => x.Id == resultId);
            }
        }

        public void AddResult(Results result)
        {
            using (var context = new RabbitsDBEntities())
            {
                if(IsExistName(context, result.Name))
                    throw new InvalidOperationException(ResultExist);

                context.Results.Add(result);
                context.SaveChanges();
            }
        }

        public void UpdateResult(Results result)
        {
            using (var context = new RabbitsDBEntities())
            {
                if (IsExistName(context, result.Name))
                    throw new InvalidOperationException(ResultExist);

                var resultNew = context.Results.FirstOrDefault(x => x.Id == result.Id);

                if (resultNew != null) resultNew.Name = result.Name;

                context.SaveChanges();
            }
        }

        public void DeleteResult(int resultId)
        {
            using (var context = new RabbitsDBEntities())
            {
                var result = context.Results.FirstOrDefault(x => x.Id == resultId);

                if(result == null)
                    throw new InvalidOperationException(ResultNotFound);

                context.Results.Remove(result);
                context.SaveChanges();
            }
        }

        static bool IsExistName(RabbitsDBEntities context, string resultName)
        {
            return context.Results.FirstOrDefault(x => x.Name == resultName) != null;
        }
    }
}
