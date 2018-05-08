using Proyecto.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Helper;

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
            return Json(habilidad.Listar(grid,SessionHelper.GetUser()));

        }

        public JsonResult Guardar(Habilidad model)
        {
            var rm = new  ResponseModel();


            try
            {
               if (ModelState.IsValid)
                {
                    rm = model.Guardar();

                    if (rm.response)
                    {
                        rm.href = Url.Content("~/admin/habilidades/");
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }

            return Json(rm);


        }

        public ActionResult Crud(int id= 0)
        {
            if (id == 0) habilidad.Usuario_id = SessionHelper.GetUser();
            else habilidad = habilidad.Obtener(id);

            return View(habilidad);
        }

        public JsonResult Eliminar(int id)
        {
            return Json(habilidad.Eliminar(id));
        }
    }


}