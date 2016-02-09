using System;
using System.Web.Mvc;
using BusonessLogic;
using Entities;

namespace Rabbits.Controllers
{
    public class MedicalServicesController : Controller
    {
        private const string ShowMedicalServicesAction = "ShowMedicalServices";
        private const string ErrorAction = "Error";

        // GET: MedicalServices
        public ActionResult ShowMedicalServices()
        {
            return View(new MedicalServicesManager().GetMedicalServices());
        }

        public ActionResult ShowProfile(int medicalServiceId)
        {
            return View(new MedicalServicesManager().GetMedicalService(medicalServiceId));
        }

        public ActionResult AddMedicalService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMedicalService(MedicalServices medicalService)
        {
            try
            {
                if (ModelState.IsValid)
                    new MedicalServicesManager().AddMedicalService(medicalService);
                

                return RedirectToAction(ShowMedicalServicesAction);
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ErrorAction, new { exception });
            }
        }

        public ActionResult UpdateMedicalService(int medicalServiceId)
        {
            return View(new MedicalServicesManager().GetMedicalService(medicalServiceId));
        }

        [HttpPost]
        public ActionResult UpdateMedicalService(MedicalServices medicalService)
        {
            try
            {
                if (ModelState.IsValid)
                    new MedicalServicesManager().UpdateMedicalService(medicalService);

                return RedirectToAction(ShowMedicalServicesAction);
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ErrorAction, new { exception });
            }
        }

        public ActionResult DeleteMedicalService(int medicalServiceId)
        {
            try
            {
                new MedicalServicesManager().DeleteMedicalService(medicalServiceId);
                return RedirectToAction(ShowMedicalServicesAction);
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ErrorAction, new { exception });
            }
        }

        public ActionResult Error(InvalidOperationException exception)
        {
            return null;
        }
    }
}