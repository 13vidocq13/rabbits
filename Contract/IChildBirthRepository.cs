using System.Collections.Generic;
using Entities;

namespace Contract
{
    public interface IChildBirthRepository
    {
        IList<ChildBirth> GetChildBirth();
        ChildBirth GetChildBirth(int childBirthId);
        void AddChildBirth(ChildBirth childBirth);
        void UpdateChildBirth(ChildBirth childBirth);
        void DeleteChildBirth(int childBirthId);
    }
}
