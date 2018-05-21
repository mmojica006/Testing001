using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.App_Start;

namespace Proyecto.Controllers
{
    public class DefaultController : Controller
    {

        private TablaDato tabladato = new TablaDato();
        private Usuario usuario = new Usuario();


        //public int Index()
        //{


        //    return tabladato.Conteo();
        //}

        public ActionResult     Index()
        {

            return View(usuario.Obtener(FrontOfficeStartUp.UsuarioVisualizando(),true));
        }
    }
}