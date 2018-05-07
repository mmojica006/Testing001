using Proyecto.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace Proyecto.Areas.Admin.Controllers
{
    
    
    [Autenticado]
    public class HabilidadesController : Controller
    {
        private Habilidad habilidad = new Habilidad();
        // GET: Admin/Habilidades
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Listar (AnexGRID grid)
        {

        }
    }


}