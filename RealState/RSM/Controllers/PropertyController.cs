using RSM.BOL.Models;
using RSM.DAL.DatabaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSM.Controllers
{
    public class PropertyController : Controller
    {
        private DBOperations_Property _dbOperations = new DBOperations_Property();

        // GET: Property
        public ActionResult AddProperty()
        {
            var property = CreateDummyData();
            return View(property);
        }

        [HttpPost]
        public ActionResult AddProperty(Property property)
        {
            if (ModelState.IsValid)
            {
                var isDataInserted = _dbOperations.InsertPropertyData(property);

                ViewBag.Message = isDataInserted ? "<script>alert('Record Inserted')</script>" : "<script>alert('Record not Inserted')</script>";
            }
            return View();
        }


        public ActionResult ViewProperties()
        {
            var properties = _dbOperations.GetProperties();
            return View(properties);
        }

        //This work will done in property sell table do Here just for now
        public ActionResult ConfirmSale(int ownerId, int propertyId)
        {
            _dbOperations.UpdatePropertyOwner(ownerId, propertyId);


            return RedirectToAction("ViewProperties", "Property"); // Redirect back to the list of properties
        }

        private Property CreateDummyData()
        {
            return new Property
            {
                PlotNo = "D-97",
                PropertyType = PropertyType.Commercial,
                PropertyStatus = PropertyStatus.Available,
            };

        }



    }
}