using System.Collections.Generic;
using Entities;

namespace Contract
{
    public interface IMedicalServicesRepository
    {
        IList<MedicalServices> GetMedicalServices();
        MedicalServices GetMedicalService(int serviceId);
        void AddMedicalService(MedicalServices medicalService);
        void UpdateMedicalService(MedicalServices medicalService);
        void DeleteMedicalService(int medicalServiceId);
    }
}
