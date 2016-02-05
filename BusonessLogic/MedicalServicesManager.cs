using System.Collections.Generic;
using Data;
using Entities;

namespace BusonessLogic
{
    public class MedicalServicesManager
    {
        public IList<MedicalServices> GetMedicalServices()
        {
            return new MedicalServicesRepository().GetMedicalServices();
        }

        public MedicalServices GetMedicalService(int serviceId)
        {
            return new MedicalServicesRepository().GetMedicalService(serviceId);
        }

        public void AddMedicalService(MedicalServices medicalService)
        {
            new MedicalServicesRepository().AddMedicalService(medicalService);
        }

        public void UpdateMedicalService(MedicalServices medicalService)
        {
            new MedicalServicesRepository().UpdateMedicalService(medicalService);
        }

        public void DeleteMedicalService(int medicalServiceId)
        {
            new MedicalServicesRepository().DeleteMedicalService(medicalServiceId);
        }
    }
}
