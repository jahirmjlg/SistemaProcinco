using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class EstadosCivilesViewModel
    {
        public int Estc_Id { get; set; }
        public string Estc_Descripcion { get; set; }
        public int Estc_UsuarioCreacion { get; set; }
        public DateTime Estc_FechaCreacion { get; set; }
        public int? Estc_UsuarioModificacion { get; set; }
        public DateTime? Estc_FechaModificacion { get; set; }
        public bool? Estc_Estado { get; set; }

        [NotMapped]
        public string Creacion { get; set; }

        [NotMapped]
        public string Modificacion { get; set; }
    }
}
