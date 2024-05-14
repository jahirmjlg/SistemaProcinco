using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace SistemaProcinco.Common.Models
{
   public class EmpresasViewModel
    {
        public int Empre_Id { get; set; }
        public string Empre_Descripcion { get; set; }
        public string Empre_Direccion { get; set; }
        public string Ciud_Id { get; set; }
        public int Empre_UsuarioCreacion { get; set; }
        public DateTime Empre_FechaCreacion { get; set; }
        public int? Empre_UsuarioModificacion { get; set; }
        public DateTime? Empre_FechaModificacion { get; set; }
        public bool? Empre_Estado { get; set; }
        [NotMapped]
        public string UsuarioCreacion { get; set; }
        [NotMapped]
        public string UsuarioModificacion { get; set; }

        [NotMapped]
        public string Ciud_Descripcion { get; set; }
    }
}
