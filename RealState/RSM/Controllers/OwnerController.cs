﻿using RSM.BOL.Models;
using System;
using System.Web.Mvc;
using RSM.BLL;
using RSM.DAL.DatabaseService;
using RSM.DAL.Context;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Metadata.Edm;

namespace RSM.Controllers
{
    public class OwnerController : Controller
    {
        private ImageValidation _imageValidation = new ImageValidation();
        private DBOperations_Owners _dbOperations = new DBOperations_Owners();

        public ActionResult ViewOwners(/*int propertyId = 0, bool isSelectionMode = false*/)
        {
            //fetch All Owners
            var owners = _dbOperations.GetOwners();

            //save property id get property page to pass it ViewownerPage
            //ViewBag.PropertyID = propertyId;
            return View(owners);
        }

        public ActionResult GetSelectedOwner(int ownerId)
        {
            Session["ownerId"] = ownerId;
            return RedirectToAction("ViewNominees", "Nominee");
        }




        public ActionResult AddOwner()
        {
            Owner ownerDummy = new Owner
            {
                FirstName = "Haider",
                LastName = "ALi",
                CNIC = "6556546",
                CellNo = "35265656",
                Gender = "Male",
                ContactNo = "654856485",
                Address = "Gulshan hadeed",
                ImagePath = "~/SystemImages/NoUserImage.png",
                SODOWO = "jsdujsdh",
                DOB = DateTime.Now.ToString("yyyy-MM-dd"),
            };
            return View(ownerDummy);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddOwner(Owner ownerData)
        {
            if (ModelState.IsValid)
            {
                if (ownerData.ImageFile != null)
                {
                    //image validaton logic (checks for prefered extension and size)
                    if (_imageValidation.IsValidImage(ownerData.ImageFile))
                    {
                        var path = _imageValidation.SaveImageOnServer(ownerData.ImageFile);
                        var isDataInserted = _dbOperations.InsertOwnerData(ownerData, path);


                        ViewBag.Message = isDataInserted ? "<script>alert('Record Inserted')</script>" : "<script>alert('Record not Inserted')</script>";
                    }
                    else
                        ViewBag.Message = "<script>alert('Invalid Image type, only png, jpg and jpeg files are supported')</script>";
                }
                else
                {
                    var isDataInserted = _dbOperations.InsertOwnerData(ownerData);

                    ViewBag.Message = isDataInserted ? "<script>alert('Record Inserted')</script>" : "<script>alert('Record not Inserted')</script>";
                }
                TempData["OwnerId"] = ownerData.OwnerID;
                return RedirectToAction("AddNominee", "Nominee");
            }

            return View();
        }
       
    }
}




        
        
