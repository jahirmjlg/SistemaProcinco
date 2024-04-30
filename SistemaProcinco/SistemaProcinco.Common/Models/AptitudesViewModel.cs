using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class AptitudesViewModel
    {
        public int Apti_Id { get; set; }
        public string Apti_Descripcion { get; set; }
        public decimal? Apti_ValorMonetario { get; set; }
        public int Apti_UsuarioCreacion { get; set; }
        public DateTime Apti_FechaCreacion { get; set; }
        public int? Apti_UsuarioModificacion { get; set; }
        public DateTime? Apti_FechaModificacion { get; set; }
        public bool? Apti_Estado { get; set; }
    }
}
