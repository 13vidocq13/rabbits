using System;
using System.Web.Mvc;
using BusonessLogic;
using Entities;

namespace Rabbits.Controllers
{
    public class MalesController : Controller
    {
        private const string ShowMalesAction = "ShowMales";
        private const string ErrorAction = "Error";
        private const string ControllerName = "Males";

        // GET: Parrents
        public ActionResult ShowMales()
        {
            return View(new MalesManager().GetMales());
        }

        public ActionResult ShowProfile(int maleId)
        {
            return View(new MalesManager().GetMale(maleId));
        }

        public ActionResult AddMale()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMale(Males male)
        {
            try
            {
                new MalesManager().AddMale(male);
                return RedirectToAction(ShowMalesAction);
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ErrorAction, new { exception });
            }
        }

        public ActionResult UpdateMale(int maleId)
        {
            return View(new MalesManager().GetMale(maleId));
        }

        [HttpPost]
        public ActionResult UpdateMale(Males male)
        {
            try
            {
                new MalesManager().UpdateMale(male);
                return RedirectToAction(ShowMalesAction);
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ErrorAction, new { exception });
            }
        }

        public ActionResult DeleteMale(int maleId)
        {
            try
            {
                new MalesManager().DeleteMale(maleId);
                return RedirectToAction(ShowMalesAction);
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ErrorAction, new { exception });
            }
        }

        public ActionResult Error(InvalidOperationException exception)
        {
            ViewBag.Controller = ControllerName;
            ViewBag.Action = ShowMalesAction;

            return View(exception);
        }
    }
}