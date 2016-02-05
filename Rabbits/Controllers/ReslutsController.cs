using System;
using System.Web.Mvc;
using BusonessLogic;
using Entities;

namespace Rabbits.Controllers
{
    public class ReslutsController : Controller
    {
        private const string ActionShowResults = "ShowResults";
        private const string ActionError = "Error";

        // GET: Resluts
        public ActionResult ShowResults()
        {
            return View(new ResultsManager().GetResults());
        }

        public ActionResult ShowProfile(int resultId)
        {
            return View(new ResultsManager().GetResult(resultId));
        }

        public ActionResult AddResult()
        {
            return View();
        }

        // POST: Resluts/Create
        [HttpPost]
        public ActionResult AddResult(Results result)
        {
            try
            {
                new ResultsManager().AddResult(result);

                return RedirectToAction(ActionShowResults);
            }
            catch
            {
                return RedirectToAction(ActionError);
            }
        }

        // GET: Resluts/Edit/5
        public ActionResult UpdateResult(int resultId)
        {
            return View(new ResultsManager().GetResult(resultId));
        }

        // POST: Resluts/Edit/5
        [HttpPost]
        public ActionResult UpdateResult(Results result)
        {
            try
            {
                new ResultsManager().UpdateResult(result);

                return RedirectToAction(ActionShowResults);
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ActionError, new { exception });
            }
        }

        // POST: Resluts/Delete/5
        [HttpPost]
        public ActionResult DeleteResult(int resultId)
        {
            try
            {
                new ResultsManager().DeleteResult(resultId);

                return RedirectToAction(ActionShowResults);
            }
            catch(InvalidOperationException exception)
            {
                return RedirectToAction(ActionError, new { exception });
            }
        }

        public ActionResult Error(InvalidOperationException exception)
        {
            return null;
        }
    }
}
