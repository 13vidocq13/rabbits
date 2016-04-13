using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusonessLogic;
using BusonessLogic.Help.Types;
using Contract;
using Entities;

namespace Rabbits.Controllers
{
    public class ChildBirthController : Controller
    {
        private const string ShowChildBirthAction = "ShowChildBirth";
        private const string ErrorAction = "Error";
        private const string ErrorLists = "Обнаружена ошибка со списками";
        private const string None = "Нет";

        // GET: Profiles
        public ActionResult ShowChildBirth(IList<ChildBirthParrents> childBirthParrentsList)
        {
            ViewBag.Results = new ResultsManager().GetResults();

            return View(childBirthParrentsList ?? new ChildBirthManager().GetChildBirth());
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
        public ActionResult AddChildBirth(ChildBirth childBirth, FormCollection formCollection)
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
            var childBirth = new ChildBirthManager().GetChildBirth(childBirthId);
            ViewData["malesDdl1"] = BindMalesList(childBirth.MaleId1);
            ViewData["malesDdl2"] = BindMalesList(childBirth.MaleId2);
            ViewData["femalesDdl"] = BindFemalesList(childBirth.FemaleId);
            ViewData["resultsDdl"] = BindResultsList(childBirth.ResultId);

            return View(childBirth);
        }

        [HttpPost]
        public ActionResult UpdateChildBirth(ChildBirth childBirth, FormCollection formCollection)
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

        private static void AddDataFromDdls(ChildBirth childBirth, FormCollection formCollection)
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

        public ActionResult Filter(string maleName, string femaleName, string[] resultsIds, 
            string dateFrom, string dateTo)
        {
            var filters = new Filters
            {
                MaleName = maleName,
                FemaleName = femaleName,
                DateFrom = DateTime.Parse(dateFrom),
                DateTo = DateTime.Parse(dateTo),
                Results = resultsIds != null ? new ResultsManager().GetResults(resultsIds) : null
            };

            return RedirectToAction(ShowChildBirthAction, new { childBirthParrentsList = new ChildBirthManager().GetChildBirth(filters)});
        }

        static IList<SelectListItem> BindMalesList(int? selectedId)
        {
            var males = new MalesManager().GetMales();

            IList<SelectListItem> result = new List<SelectListItem>
            {
                new SelectListItem {Text = None, Selected = selectedId == null, Value = null}
            };

            foreach (var item in males)
            {
                result.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                    Selected = item.Id == selectedId
                });
            }

            return result;
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
            var results = new ResultsManager().GetResults();

            IList<SelectListItem> result = new List<SelectListItem>
            {
                new SelectListItem {Text = None, Selected = selectedId == null, Value = null}
            };

            foreach (var item in results)
            {
                result.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                    Selected = item.Id == selectedId
                });
            }

            return result;
        }

        Filters GetFiltersData(FormCollection formCollection)
        {
            var filter = new Filters();

            filter.FemaleName = formCollection["textboxFemaleName"];
            filter.MaleName = formCollection["textboxMaleName"];
            filter.DateFrom = Convert.ToDateTime(formCollection["textboxDateFrom"]);
            filter.DateTo = Convert.ToDateTime(formCollection["textboxDateTo"]);
            var names = formCollection.AllKeys.Where(c => c.StartsWith("checkbox"));

            return filter;
        }
    }
}