using RSM.BOL.Models;
using RSM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSM.Controllers
{
    public class OwnerController : Controller
    {
        // GET: Owner
        //public ActionResult GetProperty()
        //{
        //    return View();
        //}
        private readonly RSMContext _ctx;
        public OwnerController()
        {
            _ctx = new RSMContext();  
        }
        public ActionResult GetProperty(int id)
        {
            var propertyCount = _ctx.Properties
               .Where(p => p.OwnerID == id)
               .Select(p => p.Owner)
               .ToList();
            ViewBag.propertyCount = propertyCount.Count();
            ViewBag.OwnerId = id;
            return View();
        }
        public JsonResult GetPropertiesByOwner(int id)
        {
            var properties = _ctx.Properties
                .Where(p => p.OwnerID == id)
                .Select(p => new
                {
                    p.ID,
                    p.PropertyType, // Assuming you have a PropertyName or other fields
                    p.PlotNo // Add more fields as needed
                })
                .ToList();

            return Json(properties, JsonRequestBehavior.AllowGet);
        }

    }
}