using RSM.BOL.Models;
using RSM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }
        public ActionResult Create(PropertySell propertySell)
        {
           _ctx.propertySells.Add(propertySell);
            _ctx.SaveChanges();
            return View();
        }
    }
}