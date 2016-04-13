using System.Collections.Generic;
using BusonessLogic.Help.Types;
using BusonessLogic.Help.TypesConverter;
using Contract;
using Data;
using Entities;

namespace BusonessLogic
{
    public class ChildBirthManager
    {
        public IList<ChildBirthParrents> GetChildBirth()
        {
            var childBirth = new ChildBirthRepository().GetChildBirth();

            return new ToChildBirthParrents().Convert(childBirth);
        }

        public IList<ChildBirth> GetChildBirth(Filters filter)
        {
            return new ChildBirthRepository().GetChildBirth(filter);
        }

        public ChildBirth GetChildBirth(int childBirthId)
        {
            return new ChildBirthRepository().GetChildBirth(childBirthId);
        }

        public void AddChildBirth(ChildBirth childBirthParrents)
        {
            new ChildBirthRepository().AddChildBirth(childBirthParrents);
        }

        public void UpdateChildBirth(ChildBirth childBirthParrents)
        {
            new ChildBirthRepository().UpdateChildBirth(childBirthParrents);
        }

        public void DeleteChildBirth(int childBirthId)
        {
            new ChildBirthRepository().DeleteChildBirth(childBirthId);
        }
    }
}
