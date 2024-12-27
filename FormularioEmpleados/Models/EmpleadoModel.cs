using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormularioEmpleados.Models
{
    public class EmpleadoModel
    {
        public int EmpleadoID { get; set; }
        [Required(ErrorMessage = "Por favor introduzca el Nombre")]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Por favor introduzca el Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "Por favor introduzca el Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[Required]
        [RegularExpression(@"^(\d{7,10}|\d{10,10})$", ErrorMessage = "Telefono Inválido")]
        [DataType(DataType.PhoneNumber)]
        [Display]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Por favor introduzca el Numero de Celular")]
        [RegularExpression(@"^(\d{7,10}|\d{10,10})$", ErrorMessage = "Celular Inválido")]
        [DataType(DataType.PhoneNumber)]
        [Display]
        public string Celular { get; set; }
        public string Curp { get; set; }

        [Required(ErrorMessage = "Por favor introduzca el RFC")]
        public string RFC { get; set; }
        public string NSS { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Por favor selecciona la Fecha de Nacimiento")]
        public DateTime? FechaDeNacimiento { get; set; }

        [Required(ErrorMessage = "Por favor ingresa la Calle")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el Numero exterior")]
        public string NumeroExterior { get; set; }

        public string NumeroInterior { get; set; }
        [Required(ErrorMessage = "Por favor ingresa el Codigo Postal")]
        public string CodigoPostal { get; set; }
        [Required(ErrorMessage = "Por favor ingresa la Colonia")]
        public string Colonia { get; set; }
        public string NombreReferenciaUno { get; set; }
        public string ApellidoPaternoReferenciaUno { get; set; }
        public string ApellidoMaternoReferenciaUno { get; set; }
        public string TelefonoReferenciaUno { get; set; }
        public string ParentescoReferenciaUno { get; set; }
        public string NombreReferenciaDos { get; set; }
        public string ApellidoPaternoReferenciaDos { get; set; }
        public string ApellidoMaternoReferenciaDos { get; set; }
        public string TelefonoReferenciaDos { get; set; }
        public string ParentescoReferenciaDos { get; set; }
        public int? BancoID { get; set; }
        public string ClaveInterbancaria { get; set; }
        public string NumeroDeCuenta { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Expediente { get; set; }

        [Required(ErrorMessage = "Por favor selecciona el Area")]
        public int AreaID { get; set; }

        [Required(ErrorMessage = "Por favor selecciona el Puesto")]
        public int PuestoID { get; set; }
        public string BancoDescripcion { get; set; }
        public string AreaDescripcion { get; set; }
        public string PuestoDescripcion { get; set; }
        public int ID_Temporal { get; set; }
        public int Usuario_ID { get; set; }
        public string NombreCompleto { get; set; }
        public int UsuarioActivo { get; set; }
        public int OperadorId { get; set; }
        public int OperadorActivo { get; set; }
        public string URL_INE { get; set; }
        public string URL_ACTA_NACIMIENTO { get; set;}
        public string URL_Grado_Estudios { get; set;}
        public string URL_Comprobante_Domicilio { get; set;}
        public string URL_Comprobante_Bancario { get; set;}
        public string URL_Hoja_Retencion { get; set;}
        public string URL_RFC { get; set;}

        [Display(Name = "Numero de Hijos:")]
        public int Numero_Hijos { get; set; }
        public bool Credito_Bancario { get; set;}
        public int Tipo_De_Credito { get; set;}
        [Display(Name = "Grado de Estudios:")]
        public int Grado_Estudios_Id { get; set;}
    }
}