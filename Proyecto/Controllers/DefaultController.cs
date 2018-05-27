using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.App_Start;
using Proyecto.ViewModels;
using System.Net.Mail;
using Rotativa.MVC;

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

        public JsonResult EnviarCorreo(ContactoViewModel model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                try
                {
                    var _usuario = usuario.Obtener(FrontOfficeStartUp.UsuarioVisualizando());

                    var mail = new MailMessage();
                    mail.From = new MailAddress(model.Correo, model.Nombre);
                    mail.To.Add(_usuario.Email);
                    mail.Subject = "Correo desde contacto";
                    mail.IsBodyHtml = true;
                    mail.Body = model.Mensaje;

                    var SmtpServer = new SmtpClient("smtp.live.com"); // or "smtp.gmail.com"
                    SmtpServer.Port = 587;
                    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    SmtpServer.UseDefaultCredentials = false;

                    // Agrega tu correo y tu contraseña, hemos usado el servidor de Outlook.
                    SmtpServer.Credentials = new System.Net.NetworkCredential("moises.mojica@crediexpress.com.ni", "Claroa2060");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }
                catch (Exception e)
                {
                    rm.setResponse(false, e.Message);
                    return Json(rm);
                    throw;
                }

                rm.setResponse(true);
                rm.function = "CerrarContacto();";
            }

            return Json(rm);


        }

        public ActionResult ExportarAPDF() {

            return new ActionAsPdf("PDF");


        }

        public ActionResult PDF() {


            return View(
                usuario.Obtener(FrontOfficeStartUp.UsuarioVisualizando(),true)
                );
        }


    }
}