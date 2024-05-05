using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class UsuariosViewModel
    {
        public int Usua_Id { get; set; }
        public string Usua_Usuario { get; set; }
        public string Usua_Contraseña { get; set; }
        public bool? Usua_EsAdmin { get; set; }
        public int Role_Id { get; set; }
        public int? Usua_UsuarioCreacion { get; set; }
        public DateTime Usua_FechaCreacion { get; set; }
        public int? Usua_UsuarioModificacion { get; set; }
        public DateTime? Usua_FechaModificacion { get; set; }
        public bool? Usua_Estado { get; set; }
        public int? Empl_Id { get; set; }
        [NotMapped]
        public string Usua_Admin1 { get; set; }
        public string Usua_VerificarCorreo { get; set; }
        [NotMapped]
        public string Role_Descripcion { get; set; }
        [NotMapped]
        public string correo { get; set; }
        [NotMapped]
        public string adminfalso { get; set; }
        [NotMapped]
        public string Empl_Nombre { get; set; }
        [NotMapped]
        public string UsuarioCreacion { get; set; }

        [NotMapped]
        public string UsuarioModificacion { get; set; }
    }
}
