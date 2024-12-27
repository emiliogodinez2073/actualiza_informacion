using FormularioEmpleados.Context;
using FormularioEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace FormularioEmpleados.Controllers
{
    public class HomeController : Controller
    {
        TablaEmpleados ObjEmpleados=new TablaEmpleados();   
        public ActionResult Index()
        {
            return View();
        }
    }
}