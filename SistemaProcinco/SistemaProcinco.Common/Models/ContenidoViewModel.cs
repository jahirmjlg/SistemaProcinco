using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class ContenidoViewModel
    {
        public int Cont_Id { get; set; }
        public string Cont_Descripcion { get; set; }
        public int? Cont_DuracionHoras { get; set; }
        public int Cont_UsuarioCreacion { get; set; }
        public DateTime Cont_FechaCreacion { get; set; }
        public int? Cont_UsuarioModificacion { get; set; }
        public DateTime? Cont_FechaModificacion { get; set; }
        [NotMapped]
        public string UsuarioCreacion { get; set; }
        [NotMapped]
        public string UsuarioModificacion { get; set; }
    }
}
