using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class AptitudesPorEmpleadosViewModel
    {
        public int AptPe_Id { get; set; }
        public int? Apti_Id { get; set; }
        public int? Empl_Id { get; set; }
        public int AptPe_UsuarioCreacion { get; set; }
        public DateTime AptPe_FechaCreacion { get; set; }
        public int? AptPe_UsuarioModificacion { get; set; }
        public DateTime? AptPe_FechaModificacion { get; set; }
        public bool? AptPe_Estado { get; set; }
    }
}
