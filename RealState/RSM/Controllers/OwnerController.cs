using RSM.BOL.Models;
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
        public ActionResult AddOwner()
        {
            var ownerTypes = Enum.GetValues(typeof(OwnerType)).
                Cast<OwnerType>().
                Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                }).ToList();

            ViewBag.OwnerTypes = ownerTypes as List<SelectListItem>;

         
            return View();
        } 
        [HttpPost]
        public ActionResult AddOwner(Owner owner)
        {
            if(ModelState.IsValid)
            {

            }
            else
            {

            }

            return View();
        }
    }


}
