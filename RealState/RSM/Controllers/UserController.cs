using RSM.BLL;
using RSM.BOL.Models;
using RSM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RSM.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private readonly RSMContext _ctx;
        private readonly UserBll _userBll;
        public UserController()
        {
            _userBll = new UserBll();
        }
        //public UserController()
        //{
        //    _ctx = new RSMContext();
        //}
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                //var data = _ctx.Users.Where(u => u.UserEmail == user.UserEmail
                //&& u.UserPassword == user.UserPassword).FirstOrDefault();
                bool isAuthenticated = _userBll.AuthenticateUser(user.UserEmail, user.UserPassword);
                Session["UserName"] = user.UserEmail.Split('@')[0];
                if (isAuthenticated)
                {
                    return RedirectToAction("AddProperty", "Property");
                }

            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
        public ActionResult Test()
        {
            
            return View();
        }
    }
}