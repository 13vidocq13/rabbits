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
                Id = childBirth.Id,
                Birthday = childBirth.Birthday,
                ExpectBirthday = childBirth.ExpectBirthday,
                FemaleId = childBirth.FemaleId,
                MaleId1 = childBirth.MaleId1,
                MaleId2 = childBirth.MaleId2,
                Notes = childBirth.Notes,
                ResultId = childBirth.ResultId,
                StartDate1 = childBirth.StartDate1,
                StartDate2 = childBirth.StartDate2,
                FemaleName = new FemalesRepository().GetFemale(childBirth.FemaleId).Name,
                MaleName1 = new MalesRepository().GetMale(childBirth.MaleId1).Name,
                MaleName2 = childBirth.MaleId2 != null
                    ? new MalesRepository().GetMale((int) childBirth.MaleId2).Name
                    : null,
                ResultName = new ResultsRepository().GetResult(childBirth.ResultId).Name
            };
        }
    }
}
