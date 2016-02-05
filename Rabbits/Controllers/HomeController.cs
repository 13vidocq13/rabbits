using System;
using System.Web.Mvc;
using BusonessLogic;
using Entities;

namespace Rabbits.Controllers
{
    public class HomeController : Controller
    {
        private const string ActionShowCages = "ShowCages";
        private const string ActionError = "Error";
        private const string ActionUpdateRabbitsInCage = "UpdateRabbitsInCage";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ShowCages()
        {
            return View(new CagesManager().GetCages());
        }

        public ActionResult ShowProfile(int cageId)
        {
            ViewBag.RabbitsInCage = new FemalesManager().GetFemales(cageId);

            return View(new CagesManager().GetCage(cageId));
        }

        public ActionResult AddCage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCage(Cages cage)
        {
            try
            {
                new CagesManager().AddCage(cage);

                return RedirectToAction(ActionShowCages);
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ActionError, new {exception});
            }
        }

        public ActionResult UpdateCage(int cageId)
        {
            return View(new CagesManager().GetCage(cageId));
        }

        [HttpPost]
        public ActionResult UpdateCage(Cages cage)
        {
            try
            {
                new CagesManager().UpdateCage(cage);

                return RedirectToAction(ActionShowCages);
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ActionError, new { exception });
            }
        }

        public ActionResult UpdateRabbitsInCage(int cageId)
        {
            return View(new FemalesManager().GetFemales(cageId));
        }

        public ActionResult DeleteRabbitFormCage(int femaleId, int cageId)
        {
            try
            {
                new FemalesManager().DeleteFemaleFromCage(femaleId);
                return RedirectToAction(ActionUpdateRabbitsInCage, new {cageId});
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ActionError, new {exception});
            }
        }

        public ActionResult DeleteCage(int cageId)
        {
            try
            {
                new CagesManager().DeleteCage(cageId);

                return RedirectToAction(ActionShowCages);
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ActionError, new { exception });
            }
        }

        public ActionResult Error(InvalidOperationException exception)
        {
            return View(exception);
        }
    }
}