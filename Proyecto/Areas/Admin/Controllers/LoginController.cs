using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Helper;
using Proyecto.Areas.Admin.Filters;

namespace Proyecto.Areas.Admin.Controllers
{

    public class LoginController : Controller
    {
        private Usuario usuario = new Usuario();
        [NoLogin]
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Acceder(string Email, string Password) 
        {
            var rm = usuario.Acceder(Email, Password);
            if (rm.response)
            {
                rm.href = Url.Content("~/Admin/usuario");
            }
            return Json(rm);


        } 

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/");
        }


    }
}