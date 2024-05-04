using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class CiudadesViewModel
    {
        public string Ciud_Id { get; set; }
        public string Ciud_Descripcion { get; set; }
        public string Esta_Id { get; set; }
        [NotMapped]
        public string Esta_Descripcion { get; set; }
        public int Ciud_UsuarioCreacion { get; set; }
        public DateTime Ciud_FechaCreacion { get; set; }
        public int? Ciud_UsuarioModificacion { get; set; }
        public DateTime? Ciud_FechaModificacion { get; set; }
        [NotMapped]
        public string UsuarioCreacion { get; set; }
        [NotMapped]
        public string UsuarioModificacion { get; set; }


    }
}
