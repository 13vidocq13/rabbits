using System.Collections.Generic;
using Data;
using Entities;

namespace BusonessLogic
{
    public class ResultsManager
    {
        public IList<Results> GetResults()
        {
            return new ResultsRepository().GetResults();
        }

        public Results GetResult(int resultId)
        {
            return new ResultsRepository().GetResult(resultId);
        }

        public void AddResult(Results result)
        {
            new ResultsRepository().AddResult(result);
        }

        public void UpdateResult(Results result)
        {
            new ResultsRepository().UpdateResult(result);
        }

        public void DeleteResult(int resultId)
        {
            new ResultsRepository().DeleteResult(resultId);
        }
    }
}
