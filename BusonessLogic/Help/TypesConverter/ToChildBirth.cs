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
                Birthday = childBirthParrents.ChildBirth.Birthday,
                ExpectBirthday = childBirthParrents.ChildBirth.ExpectBirthday,
                FemaleId = childBirthParrents.Female.Id,
                MaleId1 = childBirthParrents.Male1.Id,
                MaleId2 = childBirthParrents.Male2.Id,
                Notes = childBirthParrents.ChildBirth.Notes,
                ResultId = childBirthParrents.Result.Id,
                StartDate1 = childBirthParrents.ChildBirth.StartDate1,
                StartDate2 = childBirthParrents.ChildBirth.StartDate2
            };
        } 
    }
}
