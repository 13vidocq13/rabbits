using BusonessLogic.Help.Types;
using Entities;

namespace BusonessLogic.Help.TypesConverter
{
    public class ToFemales
    {
        public Females Convert(FemaleParrentsMale femaleParrentsMale)
        {
            return new Females
            {
                Id = femaleParrentsMale.Id,
                DateOfBirth = femaleParrentsMale.DateOfBirth,
                CageId = femaleParrentsMale.CageId,
                Name = femaleParrentsMale.FemaleName
            };
        }
    }
}
