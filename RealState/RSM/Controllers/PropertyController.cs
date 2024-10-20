using Microsoft.SqlServer.Server;
using Newtonsoft.Json.Linq;
using RSM.BOL.Models;
using RSM.DAL.Context;
using RSM.DAL.DatabaseService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSM.Controllers
{
    public class PropertyController : Controller
    {
    private DBOperations_Property _dbOperations = new DBOperations_Property();

        // GET: Property
        private readonly RSMContext _ctx;
        public PropertyController()
        {
            _ctx = new RSMContext();
        }
        //[HttpGet]
        public ActionResult AddProperty()
        {
            Property property = new Property();
            

            return View();
        }
        [HttpPost]
        public ActionResult AddProperty(Property property)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ctx.Properties.Add(property);
                    _ctx.SaveChanges();
                    return RedirectToAction("ViewProperties");

                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        // Log or display the error
                        System.Diagnostics.Debug.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditProperty(int Id)
        {
            
            var data = _ctx.Properties.Find(Id);
            //string idString = EncodeHash(data.ID);
            //data.ID = Convert.ToInt16(idString);
            return View(data);
        }
        //public static string EncodeHash(int id)
        //{
        //    using (SHA256 sha256 = SHA256.Create())
        //    {
        //        byte[] idBytes = BitConverter.GetBytes(id);
        //        byte[] hashBytes = sha256.ComputeHash(idBytes);
        //        return BitConverter.ToString(hashBytes).Replace("-", ""); // Converts byte array to hex string
        //    }
        //}
        [HttpPost]
        public ActionResult EditProperty(Property model)
        {
            //var data = _ctx.Properties.Find(model.PropertyID);
            //if (data != null)
            //{
                _ctx.Entry(model).State=EntityState.Modified;
                _ctx.SaveChanges();
            //}
            return RedirectToAction("ViewProperties");
        }

        public ActionResult ViewProperties()
        {
            var list = _ctx.Properties.ToList();
            return View(list);
        }
        public ActionResult Delete(int id)
        {
            var list = _ctx.Properties.Find(id);
            _ctx.Properties.Remove(list);
            _ctx.SaveChanges();
            return RedirectToAction("ViewProperties");
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


        public ActionResult GetPropertiesByOwnerId(int ownerId)
        {
            var properties=_dbOperations.GetPropertiesByOwner(ownerId).Count();
            
            return View();
        }
    }
}