using Data;
using Entities;

namespace BusonessLogic
{
    public class ParrentsManager
    {
        public Parrents GetParrents(int femaleId)
        {
            return new ParrentsRepository().GetParrents(femaleId);
        }
    }
}
