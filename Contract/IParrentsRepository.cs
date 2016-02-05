using Entities;

namespace Contract
{
    public interface IParrentsRepository
    {
        Parrents GetParrents(int femaleId);
        void AddParrents(Parrents parrents);
        void UpdateParrents(Parrents parrents);
        void DeleteParrents(int parrentsId);
    }
}
