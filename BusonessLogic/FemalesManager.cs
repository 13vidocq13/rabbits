using System.Collections.Generic;
using System.Transactions;
using BusonessLogic.Help.Types;
using Data;
using Entities;

namespace BusonessLogic
{
    public class FemalesManager
    {
        public IList<FemaleParrentsMale> GetFemales()
        {
            var females = new FemalesRepository().GetFemales();
            return new Help.TypesConverter.ToFemaleParrentsMale().Convert(females);
        }

        public FemaleParrentsMale GetFemale(int femaleId)
        {
            var female = new FemalesRepository().GetFemale(femaleId);
            return new Help.TypesConverter.ToFemaleParrentsMale().Convert(female);
        }

        public IList<Females> GetFemales(int cageId)
        {
            return new FemalesRepository().GetFemales(cageId);
        }

        public void AddFemale(FemaleParrentsMale female)
        {
            var femaleEntity = new Help.TypesConverter.ToFemales().Convert(female);
            var parrents = new Help.TypesConverter.ToParrents().Convert(female);

            using (var transaction = new TransactionScope())
            {
                new FemalesRepository().AddFemale(femaleEntity);
                parrents.FemaleId = new FemalesRepository().GetFemale(femaleEntity.Name).Id;
                new ParrentsRepository().AddParrents(parrents);

                transaction.Complete();
            }
        }

        public void UpdateFemale(FemaleParrentsMale female)
        {
            var femaleEntity = new Help.TypesConverter.ToFemales().Convert(female);
            var parrents = new Help.TypesConverter.ToParrents().Convert(female);
            parrents.Id = new ParrentsManager().GetParrents(female.Id).Id;

            using (var transaction = new TransactionScope())
            {
                new FemalesRepository().UpdateFemale(femaleEntity);
                new ParrentsRepository().UpdateParrents(parrents);

                transaction.Complete();
            }
        }

        public void DeleteFemaleFromCage(int femaleId)
        {
            new FemalesRepository().DeleteFemaleFromCage(femaleId);
        }

        public void DeleteFemale(int femaleId)
        {
            using (var transaction = new TransactionScope())
            {
                new ParrentsRepository().DeleteParrents(new ParrentsManager().GetParrents(femaleId).Id);
                new FemalesRepository().DeleteFemale(femaleId);
                
                transaction.Complete();
            }
        }
    }
}
