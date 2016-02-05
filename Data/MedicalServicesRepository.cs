using System;
using System.Collections.Generic;
using System.Linq;
using Contract;
using Entities;

namespace Data
{
    public class MedicalServicesRepository : IMedicalServicesRepository
    {
        private const string AlreadyExist = "мед. сервис с таким именем уже существует";
        private const string NotFound = "мед. сервис не найден";

        public IList<MedicalServices> GetMedicalServices()
        {
            using (var context = new RabbitsDBEntities())
            {
                return context.MedicalServices.ToList();
            }
        }

        public MedicalServices GetMedicalService(int serviceId)
        {
            using (var context = new RabbitsDBEntities())
            {
                return context.MedicalServices.FirstOrDefault(x => x.Id == serviceId);
            }
        }

        public void AddMedicalService(MedicalServices medicalService)
        {
            using (var context = new RabbitsDBEntities())
            {
                if(IsNameExist(medicalService.MedicalServiceName, context))
                    throw new InvalidOperationException(AlreadyExist);

                context.MedicalServices.Add(medicalService);
                context.SaveChanges();
            }
        }

        public void UpdateMedicalService(MedicalServices medicalService)
        {
            using (var context = new RabbitsDBEntities())
            {
                if (IsNameExist(medicalService.MedicalServiceName, context))
                    throw new InvalidOperationException(AlreadyExist);

                var result = context.MedicalServices.FirstOrDefault(x => x.Id == medicalService.Id);
                if (result == null)
                    throw new InvalidOperationException(NotFound);

                result.MedicalServiceName = medicalService.MedicalServiceName;

                context.SaveChanges();
            }
        }

        public void DeleteMedicalService(int medicalServiceId)
        {
            using (var context = new RabbitsDBEntities())
            {
                var result = context.MedicalServices.FirstOrDefault(x => x.Id == medicalServiceId);
                if (result == null)
                    throw new InvalidOperationException(NotFound);

                context.MedicalServices.Remove(result);
                context.SaveChanges();
            }
        }

        static bool IsNameExist(string serviceName, RabbitsDBEntities context)
        {
            return context.MedicalServices.Count(x => x.MedicalServiceName == serviceName) > 0;
        }
    }
}
