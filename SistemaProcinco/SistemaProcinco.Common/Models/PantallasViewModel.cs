using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class PantallasViewModel
    {
        public int Pant_Id { get; set; }
        public string Pant_Descripcion { get; set; }
        public int Pant_UsuarioCreacion { get; set; }
        public DateTime Pant_FechaCreacion { get; set; }
        public int? Pant_UsuarioModificacion { get; set; }
        public DateTime? Pant_FechaModificacion { get; set; }
        public bool? Pant_Estado { get; set; }
        [NotMapped]
        public string Creacion { get; set; }

        [NotMapped]
        public string Modificacion { get; set; }
    }
}
