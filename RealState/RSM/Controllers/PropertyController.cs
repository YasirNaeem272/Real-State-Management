using Newtonsoft.Json.Linq;
using RSM.BOL.Models;
using RSM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Size = RSM.BOL.Models.Size;

namespace RSM.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Property
        private readonly RSMContext _ctx;
        public PropertyController()
        {
            _ctx = new RSMContext();
        }
        //[HttpGet]
        public ActionResult Create()
        {
            Property property = new Property();
            //ViewBag.SizeList = new SelectList(Enum.GetValues(typeof(Size)).Cast<Size>().Select(s => new
            //{
            //    Value = s.ToString(),
            //    Text = s.ToString()
            //}), "Value", "Text");
            //var sizeList = Enum.GetValues(typeof(Size))
            //       .Cast<Size>()
            //       .Select(s => new { Value = s.ToString(), Text = s.ToString() })
            //       .ToList();

            //sizeList.Insert(0, new { Value = "", Text = "Select Size" }); // Add placeholder

            //ViewBag.SizeList = new SelectList(sizeList, "Value", "Text");
            ViewBag.SizeList = new SelectList(Helper.GetEnumSelectList<Size>(), "Value", "Text");


            //
            //var propertList = Enum.GetValues(typeof(PropertType))
            //       .Cast<PropertType>()
            //       .Select(s => new { Value = s.ToString(), Text = s.ToString() })
            //       .ToList();

            //propertList.Insert(0, new { Value = "", Text = "Select Size" }); // Add placeholder

            //ViewBag.PropertyList = new SelectList(propertList, "Value", "Text");
            ViewBag.PropertyList = new SelectList(Helper.GetEnumSelectList<PropertType>(), "Value", "Text");

            //
            //     var statusList = Enum.GetValues(typeof(Status))
            //.Cast<Status>()
            //.Select(s => new { Value = s.ToString(), Text = s.ToString() })
            //.ToList();

            //     statusList.Insert(0, new { Value = "", Text = "Select Size" }); // Add placeholder

            //     ViewBag.StatusList = new SelectList(statusList, "Value", "Text");
            ViewBag.StatusList = new SelectList(Helper.GetEnumSelectList<Status>(), "Value", "Text");


            return View();
        }
        [HttpPost]
        public ActionResult Create(Property property)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                _ctx.Properties.Add(property);
                _ctx.SaveChanges();
                return RedirectToAction("Index");

                //}
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
        public ActionResult Edit(int Id)
        {
            var sizeList = Enum.GetValues(typeof(Size))
                  .Cast<Size>()
                  .Select(s => new { Value = s.ToString(), Text = s.ToString() })
                  .ToList();

            sizeList.Insert(0, new { Value = "", Text = "Select Size" }); // Add placeholder

            ViewBag.SizeList = new SelectList(sizeList, "Value", "Text");


            //
            var propertList = Enum.GetValues(typeof(PropertType))
                   .Cast<PropertType>()
                   .Select(s => new { Value = s.ToString(), Text = s.ToString() })
                   .ToList();

            propertList.Insert(0, new { Value = "", Text = "Select Size" }); // Add placeholder

            ViewBag.PropertyList = new SelectList(propertList, "Value", "Text");
            //
            var statusList = Enum.GetValues(typeof(Status))
       .Cast<Status>()
       .Select(s => new { Value = s.ToString(), Text = s.ToString() })
       .ToList();

            statusList.Insert(0, new { Value = "", Text = "Select Size" }); // Add placeholder

            ViewBag.StatusList = new SelectList(statusList, "Value", "Text");

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
        public ActionResult Edit(Property model)
        {
            var data = _ctx.Properties.Find(model.ID);
            if (data != null)
            {
                data.PlotNo = model.PlotNo;
                data.ProjectName = model.ProjectName;
                data.Block = model.Block;
                data.Size = model.Size;
                data.PropertyType = model.PropertyType;
                data.North = model.North;
                data.South = model.South;
                data.West = model.West;
                data.East = model.East;
                data.StreetNo = model.StreetNo;
                //data.OpenSide = model.OpenSide;
                _ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var list = _ctx.Properties.ToList();
            return View(list);
        }
        public ActionResult Delete(int id)
        {
            var list = _ctx.Properties.Find(id);
            _ctx.Properties.Remove(list);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}