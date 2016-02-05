using System.Collections.Generic;
using BusonessLogic.Help.Types;
using Data;

namespace BusonessLogic
{
    public class ChildBirthManager
    {
        public IList<ChildBirthParrents> GetChildBirth()
        {
            var childBirthList = new ChildBirthRepository().GetChildBirth();

            return new Help.TypesConverter.ToChildBirthParrents().Convert(childBirthList);
        }

        public ChildBirthParrents GetChildBirth(int childBirthId)
        {
            var childBirth = new ChildBirthRepository().GetChildBirth(childBirthId);
            return new Help.TypesConverter.ToChildBirthParrents().Convert(childBirth);
        }

        public void AddChildBirth(ChildBirthParrents childBirthParrents)
        {
            new ChildBirthRepository().AddChildBirth(new Help.TypesConverter.ToChildBirth().Convert(childBirthParrents));
        }

        public void UpdateChildBirth(ChildBirthParrents childBirthParrents)
        {
            new ChildBirthRepository().UpdateChildBirth(new Help.TypesConverter.ToChildBirth().Convert(childBirthParrents));
        }

        public void DeleteChildBirth(int childBirthId)
        {
            new ChildBirthRepository().DeleteChildBirth(childBirthId);
        }
    }
}
