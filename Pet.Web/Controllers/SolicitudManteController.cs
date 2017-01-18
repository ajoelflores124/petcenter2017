using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet.Web.Controllers
{
    public class SolicitudManteController : Controller
    {
        //
        // GET: /Solicitud/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Adicionar() {

            return View();
        }

    }
}
