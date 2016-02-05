using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusonessLogic;
using BusonessLogic.Help.Types;
using Entities;

namespace Rabbits.Controllers
{
    public class FemalesController : Controller
    {
        private const string ShowFemalesAction = "ShowFemales";
        private const string ErrorAction = "Error";
        private const string ErrorLists = "Обнаружена ошибка со списками";
        private const string None = "Нет";

        // GET: Rabbits
        public ActionResult ShowFemales()
        {
            return View(new FemalesManager().GetFemales());
        }

        public ActionResult ShowProfile(int femaleId)
        {
            var parrents = new ParrentsManager().GetParrents(femaleId);
            ViewData["malesDdl1"] = BindMalesList(parrents.FatherId1);
            ViewData["malesDdl2"] = BindMalesList(parrents.FatherId2);
            ViewData["femalesDdl"] = BindFemalesList(femaleId);

            return View(new FemalesManager().GetFemale(femaleId));
        }

        public ActionResult AddFemale()
        {
            ViewData["malesDdl"] = BindMalesList(null);
            ViewData["femalesDdl"] = BindFemalesList(null);
            ViewData["cagesDdl"] = BindCagesList(null);

            return View();
        }

        [HttpPost]
        public ActionResult AddFemale(FemaleParrentsMale female, FormCollection formCollection)
        {
            try
            {
                if (formCollection == null)
                    return RedirectToAction(ErrorAction,
                        new {exception = new InvalidOperationException(ErrorLists)});

                //will add normal checks)
                BindReceivedData(female, formCollection);
                new FemalesManager().AddFemale(female);

                return RedirectToAction(ShowFemalesAction);
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ErrorAction, new {exception});
            }
        }

        public ActionResult UpdateFemale(int femaleId)
        {
            var parrents = new ParrentsManager().GetParrents(femaleId);
            var female = new FemalesManager().GetFemale(femaleId);
            ViewData["malesDdl1"] = BindMalesList(parrents.FatherId1);
            ViewData["malesDdl2"] = BindMalesList(parrents.FatherId2);
            ViewData["femalesDdl"] = BindFemalesList(female.MotherId);
            ViewData["cagesDdl"] = BindCagesList(female.CageId);

            return View(new FemalesManager().GetFemale(femaleId));
        }

        [HttpPost]
        public ActionResult UpdateFemale(FemaleParrentsMale female, FormCollection formCollection)
        {
            try
            {
                if (formCollection == null)
                    return RedirectToAction(ErrorAction,
                        new { exception = new InvalidOperationException(ErrorLists)});

                //will add normal checks)
                BindReceivedData(female, formCollection);
                new FemalesManager().UpdateFemale(female);

                return RedirectToAction(ShowFemalesAction);
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ErrorAction, new { exception });
            }
        }

        public ActionResult DeleteFemale(int femaleId)
        {
            try
            {
                new FemalesManager().DeleteFemale(femaleId);

                return RedirectToAction(ShowFemalesAction);
            }
            catch (InvalidOperationException exception)
            {
                return RedirectToAction(ErrorAction, new { exception });
            }
        }

        public ActionResult Error(InvalidOperationException exception)
        {
            return View();
        }

        static void BindReceivedData(FemaleParrentsMale female, FormCollection formCollection)
        {
            var male1 = formCollection["ddlMale1"];
            var male2 = formCollection["ddlMale2"];
            var femaleId = formCollection["ddlFemale"];
            var cageId = formCollection["ddlCages"];

            female.FatherId1 = int.Parse(male1);
            female.FatherId2 = int.Parse(male2);
            female.MotherId = int.Parse(femaleId);
            female.CageId = int.Parse(cageId);
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

            return females.Select(item => new SelectListItem
            {
                Text = item.FemaleName, Value = item.Id.ToString(), Selected = item.Id == selectedId
            }).ToList();
        }

        static IList<SelectListItem> BindCagesList(int? selectedId)
        {
            var cages = new CagesManager().GetCages();

            IList<SelectListItem> result = new List<SelectListItem>
            {
                new SelectListItem {Text = None, Selected = selectedId == null, Value = null}
            };

            foreach (var item in cages)
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
    }
}