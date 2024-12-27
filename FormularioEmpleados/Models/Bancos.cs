using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormularioEmpleados.Models
{
    public class Bancos
    {
        public int BancoID { get; set; }
        [Required(ErrorMessage = "Por favor agregue la Descripcion")]
        [Display(Name = "Descripcion:")]
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int ID_Temporal { get; set; }
    }
}