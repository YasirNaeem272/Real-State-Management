using RSM.BLL;
using RSM.BOL.Models;
using RSM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;

namespace RSM.Controllers
{
    public class PropertySellController : Controller
    {
        private readonly RSMContext _ctx;
        private readonly PropertySaleLogic _saleLogic;

        
        public PropertySellController()
        {
            _ctx = new RSMContext();
            _saleLogic = new PropertySaleLogic();
        }
        //property Id = 1
        //OwnerId = 3

        public ActionResult ConfirmSale()
        {
            var propertySell = new PropertySell();
            var propertyId = Session["propertyID"];
            var ownerId = Session["ownerId"];
            var NomineeId = Session["nomineeId"];
            return View(propertySell);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ConfirmSale(PropertySell propertySell)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("PropertySaleSummary", "PropertySell");


            }
          
            return View();
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
                _ctx.propertySales.Add(propertySell);
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.typeList = new SelectList(Helper.GetEnumSelectList<PaymentPlan>(), "Value", "Text");

            var data = _ctx.propertySales.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(PropertySell model) 
        {
            ViewBag.typeList = new SelectList(Helper.GetEnumSelectList<PaymentPlan>(), "Value", "Text");
            var data = _ctx.propertySales.Find(model.ID);
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
            var list = _ctx.propertySales.ToList();
            return View(list);
        }

        private PropertySell CreateDummyData()
        {
            return new PropertySell
            {
                PaymentOnBooking = 100000,
                PossessionCharges = 50000,
                TotalCostOfProperty = 2000000,
                CornerCharges = 50000,
                DevelopmentCharges = 200000,
                SoldDate = DateTime.Now.ToString("yyyy-MM-dd"),
                PossessionDate = new DateTime(2024, 11, 5).ToString("yyyy-MM-dd"),
                NumberOfInstallments = 12,
                EntryByUser = 1,
                CareOf = 2
            };
        }
    }
}