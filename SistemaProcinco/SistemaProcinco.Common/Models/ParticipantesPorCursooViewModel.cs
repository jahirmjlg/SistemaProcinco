using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class ParticipantesPorCursooViewModel
    {

        public int PaCur_Id { get; set; }
        public int Part_Id { get; set; }
        public int Curso_Id { get; set; }
        public bool PaCur_Estado { get; set; }
        public DateTime PaCur_FechaCreacion { get; set; }
        public int PaCur_UsuarioCreacion { get; set; }
        public DateTime? PaCur_FechaModificacion { get; set; }
        public int? PaCur_UsuarioModificacion { get; set; }
    }
}
