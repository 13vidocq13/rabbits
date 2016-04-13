using Contract;
using Entities;

namespace BusonessLogic.Help.TypesConverter
{
    public class ToParrents
    {
        public Parrents Convert(FemaleParrentsMale femaleParrentsMale)
        {
            return new Parrents
            {
                FemaleId = femaleParrentsMale.Id,
                FatherId1 = femaleParrentsMale.FatherId1,
                FatherId2 = femaleParrentsMale.FatherId2,
                MotherId = femaleParrentsMale.MotherId
            };
        } 
    }
}
