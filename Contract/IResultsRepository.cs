using System.Collections.Generic;
using Entities;

namespace Contract
{
    public interface IResultsRepository
    {
        IList<Results> GetResults();
        Results GetResult(int resultId);
        void AddResult(Results result);
        void UpdateResult(Results result);
        void DeleteResult(int resultId);
    }
}
