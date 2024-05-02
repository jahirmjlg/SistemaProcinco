using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class TitulosPorEmpleadoViewModel
    {
        public int TitPe_Id { get; set; }
        public int? Titl_Id { get; set; }
        [NotMapped]
        public string Titulo { get; set; }
        public int? Empl_Id { get; set; }
        [NotMapped]
        public string Empleado { get; set; }
        public int TitPe_UsuarioCreacion { get; set; }
        public DateTime TitPe_FechaCreacion { get; set; }
        public int? TitPe_UsuarioModificacion { get; set; }
        public DateTime? TitPe_FechaModificacion { get; set; }

        [NotMapped]
        public string Creacion { get; set; }
        [NotMapped]
        public string Modificacion { get; set; }
    }
}
