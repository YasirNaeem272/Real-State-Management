using RSM.BOL.Models;
using RSM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Type = RSM.BOL.Models.Type;

namespace RSM.Controllers
{
    public class PropertySellController : Controller
    {
        private readonly RSMContext _ctx;
        public PropertySellController()
        {
            _ctx = new RSMContext();
        }
        // GET: PropertySell
        public ActionResult Create()
        {
            ViewBag.typeList = new SelectList(Helper.GetEnumSelectList<Type>(), "Value", "Text");

            return View();
        }
        [HttpPost]
        public ActionResult Create(PropertySell propertySell)
        {
            ViewBag.typeList = new SelectList(Helper.GetEnumSelectList<Type>(), "Value", "Text");
            if (ModelState.IsValid)
            {
                propertySell.PropertyID = 1;
                _ctx.propertySells.Add(propertySell);
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.typeList = new SelectList(Helper.GetEnumSelectList<Type>(), "Value", "Text");

            var data = _ctx.propertySells.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(PropertySell model) 
        {
            ViewBag.typeList = new SelectList(Helper.GetEnumSelectList<Type>(), "Value", "Text");
            var data = _ctx.propertySells.Find(model.ID);
            if(data != null && ModelState.IsValid)
            {

                data.CornerCharges = model.CornerCharges;
                data.PossessionCharges= model.PossessionCharges;
                data.Onbooking = model.Onbooking;
                data.Recived = model.Recived;
                data.Balance = model.Balance;
                data.Recived =model.Recived;
                data.Date = model.Date;
                data.DevelopmentCharges = model.DevelopmentCharges;
                data.TotalCostOfLand = model.TotalCostOfLand;
                data.TotalInsMonth  = model.TotalInsMonth;
                data.Type   = model.Type;
            }
            return View();
        }
        public ActionResult Index()
        {
            var list = _ctx.propertySells.ToList();
            return View(list);
        }

    }
}