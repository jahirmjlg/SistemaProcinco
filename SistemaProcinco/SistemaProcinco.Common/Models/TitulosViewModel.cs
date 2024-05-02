using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class TitulosViewModel
    {
        public int Titl_Id { get; set; }
        public string Titl_Descripcion { get; set; }
        public decimal? Titl_ValorMonetario { get; set; }
        public int Titl_UsuarioCreacion { get; set; }
        public DateTime Titl_FechaCreacion { get; set; }
        public int? Titl_UsuarioModificacion { get; set; }
        public DateTime? Titl_FechaModificacion { get; set; }
        [NotMapped]
        public string Creacion { get; set; }
        [NotMapped]
        public string Modificacion { get; set; }
    }
}
