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
