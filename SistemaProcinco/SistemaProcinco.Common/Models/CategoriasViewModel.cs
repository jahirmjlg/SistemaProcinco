using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class CategoriasViewModel
    {

        public int Cate_Id { get; set; }
        public string Cate_Descripcion { get; set; }
        public string Cate_Imagen { get; set; }
        public int Cate_UsuarioCreacion { get; set; }
        public DateTime Cate_FechaCreacion { get; set; }
        public int? Cate_UsuarioModificacion { get; set; }
        public DateTime? Cate_FechaModificacion { get; set; }
        public bool? Cate_Estado { get; set; }
    }
}
