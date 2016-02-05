using System.Collections.Generic;
using System.Linq;
using BusonessLogic.Help.Types;
using Data;
using Entities;

namespace BusonessLogic.Help.TypesConverter
{
    public class ToFemaleParrentsMale
    {
        public IList<FemaleParrentsMale> Convert(IList<Females> femalesList)
        {
            return femalesList.Select(Convert).ToList();
        }

        public FemaleParrentsMale Convert(Females female)
        {
            var parrents = new ParrentsRepository().GetParrents(female.Id);

            var currentRabbit = new FemaleParrentsMale
            {
                Id = female.Id,
                FemaleName = female.Name,
                DateOfBirth = female.DateOfBirth,
                CageId = female.CageId,
                FatherId1 = parrents.FatherId1,
                FatherId2 = parrents.FatherId2,
                MotherId = parrents.MotherId,
                MotherName = new FemalesRepository().GetFemale(parrents.MotherId).Name
            };

            if (female.CageId != null)
                currentRabbit.CageName = new CagesRepository().GetCage((int)female.CageId).Name;
            if (parrents.FatherId1 != null)
                currentRabbit.FatherName1 = new MalesRepository().GetMale((int) parrents.FatherId1).Name;
            if (parrents.FatherId2 != null)
                currentRabbit.FatherName2 = new MalesRepository().GetMale((int) parrents.FatherId2).Name;

            return currentRabbit;
        }
    }
}
