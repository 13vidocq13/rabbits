using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusonessLogic;
using BusonessLogic.Help.Types;

namespace Rabbits.Controllers
{
    public class ChildBirthController : Controller
    {
        private const string ShowChildBirthAction = "ShowChildBirth";
        private const string ErrorAction = "Error";
        private const string ErrorLists = "Обнаружена ошибка со списками";

        // GET: Profiles
        public ActionResult ShowChildBirth()
        {
            return View(new ChildBirthManager().GetChildBirth());
        }

        public ActionResult ShowProfile(int childBirthId)
        {
            return View(new ChildBirthManager().GetChildBirth(childBirthId));
        }

        public ActionResult AddChildBirth()
        {
            ViewData["malesDdl1"] = BindMalesList(null);
            ViewData["malesDdl2"] = BindMalesList(null);
            ViewData["femalesDdl"] = BindFemalesList(null);
            ViewData["resultsDdl"] = BindResultsList(null);

            return View();
        }

        [HttpPost]
        public ActionResult AddChildBirth(ChildBirthParrents childBirth, FormCollection formCollection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AddDataFromDdls(childBirth, formCollection);

                    new ChildBirthManager().AddChildBirth(childBirth);
                }

                return RedirectToAction(ShowChildBirthAction);
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ErrorAction, new {exception});
            }
        }

        public ActionResult UpdateChildBirth(int childBirthId)
        {
            var childBirthParrents = new ChildBirthManager().GetChildBirth(childBirthId);
            ViewData["malesDdl1"] = BindMalesList(childBirthParrents.MaleId1);
            ViewData["malesDdl2"] = BindMalesList(childBirthParrents.MaleId2);
            ViewData["femalesDdl"] = BindFemalesList(childBirthParrents.FemaleId);
            ViewData["resultsDdl"] = BindResultsList(childBirthParrents.ResultId);

            return View(childBirthParrents);
        }

        [HttpPost]
        public ActionResult UpdateChildBirth(ChildBirthParrents childBirth, FormCollection formCollection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AddDataFromDdls(childBirth, formCollection);

                    new ChildBirthManager().UpdateChildBirth(childBirth);
                }

                return RedirectToAction(ShowChildBirthAction);
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ErrorAction, new {exception});
            }
        }

        private static void AddDataFromDdls(ChildBirthParrents childBirth, FormCollection formCollection)
        {
            if (formCollection["ddlMale1"] == null
                    || formCollection["ddlMale2"] == null
                    || formCollection["ddlFemale"] == null
                    || formCollection["ddlResult"] == null)
                throw new InvalidOperationException(ErrorLists);

            var male1Id = formCollection["ddlMale1"];
            var male2Id = formCollection["ddlMale2"];
            var femaleId = formCollection["ddlFemale"];
            var resultId = formCollection["ddlResult"];

            childBirth.MaleId1 = int.Parse(male1Id);
            childBirth.MaleId2 = int.Parse(male2Id);
            childBirth.FemaleId = int.Parse(femaleId);
            childBirth.ResultId = int.Parse(resultId);
        }

        public ActionResult DeleteChildBirth(int childBirthId)
        {
            try
            {
                new ChildBirthManager().DeleteChildBirth(childBirthId);
                return RedirectToAction(ShowChildBirthAction);
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ErrorAction, new {exception});
            }
        }

        public ActionResult Error()
        {
            return null;
        }

        static IList<SelectListItem> BindMalesList(int? selectedId)
        {
            return new MalesManager().GetMales().Select(item => new SelectListItem
            {
                Text = item.Name,
                Value = item.Id.ToString(),
                Selected = item.Id == selectedId
            }).ToList();
        }

        static IList<SelectListItem> BindFemalesList(int? selectedId)
        {
            var females = new FemalesManager().GetFemales();

            return (from item in females
                    where item.Id != selectedId
                    select new SelectListItem
                    {
                        Text = item.FemaleName,
                        Value = item.Id.ToString(),
                        Selected = item.Id == selectedId
                    }).ToList();
        }

        static IList<SelectListItem> BindResultsList(int? selectedId)
        {
            return new ResultsManager().GetResults().Select(item => new SelectListItem
            {
                Text = item.Name,
                Value = item.Id.ToString(),
                Selected = item.Id == selectedId
            }).ToList();
        }
    }
}