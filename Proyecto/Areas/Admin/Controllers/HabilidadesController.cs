﻿using Proyecto.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Areas.Admin.Controllers
{
    [Autenticado]
    public class HabilidadesController : Controller
    {
        // GET: Admin/Habilidades
        public ActionResult Index()
        {
            return View();
        }
    }
}