using RSM.BOL.Models;
using RSM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaymentPlan = RSM.BOL.Models.PaymentPlan;

namespace RSM.Controllers
{
    public class PropertySellController : Controller
    {
        private readonly RSMContext _ctx;
        public PropertySellController()
        {
            _ctx = new RSMContext();
        }
        //property Id = 1
        //OwnerId = 3

        public ActionResult ConfirmSale()
        {
            var propertySell = new PropertySell(true);
            return View(propertySell);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ConfirmSale(PropertySell propertySell)
        {
            propertySell.EntryByUser = 1;
            propertySell.CareOf = 2;
            return View(propertySell);
        }


        public ActionResult Create()
        {
            ViewBag.typeList = new SelectList(Helper.GetEnumSelectList<PaymentPlan>(), "Value", "Text");

            return View();
        }
        [HttpPost]
        public ActionResult Create(PropertySell propertySell)
        {
            ViewBag.typeList = new SelectList(Helper.GetEnumSelectList<PaymentPlan>(), "Value", "Text");
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
            ViewBag.typeList = new SelectList(Helper.GetEnumSelectList<PaymentPlan>(), "Value", "Text");

            var data = _ctx.propertySells.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(PropertySell model) 
        {
            ViewBag.typeList = new SelectList(Helper.GetEnumSelectList<PaymentPlan>(), "Value", "Text");
            var data = _ctx.propertySells.Find(model.ID);
            if(data != null && ModelState.IsValid)
            {

                data.CornerCharges = model.CornerCharges;
                data.PossessionCharges= model.PossessionCharges;
                data.PaymentOnBooking = model.PaymentOnBooking;
                data.EntryByUser = model.EntryByUser;
                data.Balance = model.Balance;
                data.EntryByUser =model.EntryByUser;
                data.SoldDate = model.SoldDate;
                data.DevelopmentCharges = model.DevelopmentCharges;
                data.TotalCostOfProperty = model.TotalCostOfProperty;
                data.NumberOfInstallments  = model.NumberOfInstallments;
                //data.Type   = model.Type;
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