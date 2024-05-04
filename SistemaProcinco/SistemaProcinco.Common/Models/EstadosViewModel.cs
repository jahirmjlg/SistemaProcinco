using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class EstadosViewModel
    {
        public string Esta_Id { get; set; }
        public string Esta_Descripcion { get; set; }
        public int Esta_UsuarioCreacion { get; set; }
        public DateTime Esta_FechaCreacion { get; set; }
        public int? Esta_UsuarioModificacion { get; set; }
        public DateTime? Esta_FechaModificacion { get; set; }

        [NotMapped]
        public string UsuarioCreacion { get; set; }

        [NotMapped]
        public string UsuarioModificacion { get; set; }
    }
}
