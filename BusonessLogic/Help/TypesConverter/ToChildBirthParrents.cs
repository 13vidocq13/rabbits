using System.Collections.Generic;
using System.Linq;
using BusonessLogic.Help.Types;
using Data;
using Entities;

namespace BusonessLogic.Help.TypesConverter
{
    public class ToChildBirthParrents
    {
        public IList<ChildBirthParrents> Convert(IList<ChildBirth> childBirthList)
        {
            return childBirthList.Select(Convert).ToList();
        }

        public ChildBirthParrents Convert(ChildBirth childBirth)
        {
            return new ChildBirthParrents
            {
                Female = new FemalesRepository().GetFemale(childBirth.FemaleId),
                Male1 = new MalesRepository().GetMale(childBirth.MaleId1),
                Male2 = childBirth.MaleId2 != null
                    ? new MalesRepository().GetMale((int) childBirth.MaleId2)
                    : null,
                Result = new ResultsRepository().GetResult(childBirth.ResultId),
                ChildBirth = childBirth
            };
        }
    }
}
