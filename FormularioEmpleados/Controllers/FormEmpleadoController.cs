using FormularioEmpleados.Context;
using FormularioEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FormularioEmpleados.Controllers
{
    public class FormEmpleadoController : Controller
    {
        // GET: FormEmpleado
        TablaEmpleados ObjEmpleados = new TablaEmpleados();
        ListasFormulario oListas = new ListasFormulario();
        public ActionResult Index()
        {
            CargaListas();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(EmpleadoModel empleado, HttpPostedFileBase ine, HttpPostedFileBase actanacimiento,
                                 HttpPostedFileBase gradodeestudios, HttpPostedFileBase comprobantededomicilio, HttpPostedFileBase comprobantebancario, HttpPostedFileBase hojaderetencion)
        {
            
            if (!ModelState.IsValid)
            {
                ViewBag.Mensaje = "Verifica los errores marcados con Rojo.";
                ViewBag.TipoMensaje = "warning";
                CargaListas();
                return View(empleado);
            }
            if (!String.IsNullOrEmpty( empleado.RFC))
            {
                empleado.EmpleadoID = ObjEmpleados.Valida_Existencia_Empleado(empleado.Celular, empleado.NSS, empleado.RFC).EmpleadoID;
                if (empleado.EmpleadoID != 0)
                {
                    ViewBag.Mensaje = "El empleado ya cuenta con registro activo.";
                    ViewBag.TipoMensaje = "success";
                    CargaListas();
                    EmpleadoModel oEmpleado = new EmpleadoModel();
                    return View(oEmpleado);
                }
                //carga de documentos
                if (ine != null)
                {
                    empleado.URL_INE = await CargaArchivo(empleado.RFC, ine, "INE");
                }
                if (actanacimiento != null)
                {
                    empleado.URL_ACTA_NACIMIENTO = await CargaArchivo(empleado.RFC, actanacimiento, "Acta_Nacimiento");
                }
                if (ine != null)
                {
                    empleado.URL_Grado_Estudios = await CargaArchivo(empleado.RFC, gradodeestudios, "GradoEstudios");
                }
                if (ine != null)
                {
                    empleado.URL_Comprobante_Domicilio = await CargaArchivo(empleado.RFC, comprobantededomicilio, "ComprobanteDomicilio");
                }
                if (ine != null)
                {
                    empleado.URL_Comprobante_Bancario = await CargaArchivo(empleado.RFC, comprobantebancario, "ComprobanteBancario");
                }
                if (ine != null)
                {
                    empleado.URL_Hoja_Retencion = await CargaArchivo(empleado.RFC, hojaderetencion, "HojaDeRetencion");
                }
               
                ObjEmpleados.Alta_Empleados(empleado);
                ViewBag.Mensaje = $"Se dio de alta el nuevo Registro";
                ViewBag.TipoMensaje = "success";
                return View("Index");
            }
            else
            {
                ViewBag.Mensaje = "Verifica los errores marcados con Rojo.";
                ViewBag.TipoMensaje = "warning";
                CargaListas();
                return View(empleado);
            }
            
           
        }

        public async Task<string> CargaArchivo(string RFC, HttpPostedFileBase archivo, string nombreArchivo)
        {

            var arhivoByte = new byte[archivo.ContentLength];
            archivo.InputStream.Read(arhivoByte, 0, archivo.ContentLength);
            S3Service s3 = new S3Service();
            var rutaImagen = await s3.UploadFileToS3(arhivoByte, $"archivosEmpleados/{RFC}/{nombreArchivo}.pdf", "application/pdf");
            return rutaImagen;

        }

       public void CargaListas()
        {
            var ListaBancos = oListas.Muestra_Bancos().ToList();
            ViewBag.BancoID = new SelectList(ListaBancos, dataValueField: "BancoID", dataTextField: "Descripcion", null).ToList();
            var ListaAreas = oListas.Muestra_Areas().ToList();
            ViewBag.AreaID = new SelectList(ListaAreas, dataValueField: "AreaID", dataTextField: "Descripcion").ToList();
            var ListaPuestos = oListas.Muestra_Puestos().ToList();
            ViewBag.PuestoID = new SelectList(ListaPuestos, dataValueField: "PuestoID", dataTextField: "Descripcion").ToList();
            var ListaGradoEstudios = oListas.Muestra_Grado_Estudios().ToList();
            ViewBag.Grado_Estudios_Id = new SelectList(ListaGradoEstudios, dataValueField: "Id", dataTextField: "Description").ToList();
            var ListaTipoCredito = oListas.Muestra_TipoCredito().ToList();
            ViewBag.Tipo_De_Credito = new SelectList(ListaTipoCredito, dataValueField: "Id", dataTextField: "Description").ToList();
        }
    }
}
