using BusonessLogic.Help.Types;
using Entities;

namespace BusonessLogic.Help.TypesConverter
{
    public class ToChildBirth
    {
        public ChildBirth Convert(ChildBirthParrents childBirthParrents)
        {
            return new ChildBirth
            {
                Id = childBirthParrents.Id,
                Birthday = childBirthParrents.Birthday,
                ExpectBirthday = childBirthParrents.ExpectBirthday,
                FemaleId = childBirthParrents.FemaleId,
                MaleId1 = childBirthParrents.MaleId1,
                MaleId2 = childBirthParrents.MaleId2,
                Notes = childBirthParrents.Notes,
                ResultId = childBirthParrents.ResultId,
                StartDate1 = childBirthParrents.StartDate1,
                StartDate2 = childBirthParrents.StartDate2
            };
        } 
    }
}
