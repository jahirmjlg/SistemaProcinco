using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
  public  class ParticipantesPorCursoViewModel
    {
        public class Cursos
        {
            public int Curso_Id { get; set; }
            public string Curso_Descripcion { get; set; }
            public string Curso_DuracionHoras { get; set; }
            public string Curso_Imagen { get; set; }
            public int Curso_UsuarioCreacion { get; set; }
            public DateTime Curso_FechaCreacion { get; set; }
            public int Curso_UsuarioModificacion { get; set; }
            public DateTime Curso_FechaModificacion { get; set; }
            public bool Curso_Estado { get; set; }
            public int Empre_Id { get; set; }
            public int Cate_Id { get; set; }
        }





        public class Participante
        {
            public int Part_Id { get; set; }
            public string Part_DNI { get; set; }
            public int? Empre_Id { get; set; }
            public string Part_Nombre { get; set; }
            public string Part_Apellido { get; set; }
            public string Part_Correo { get; set; }
            public DateTime? Part_FechaNacimiento { get; set; }
            public string Part_Sexo { get; set; }
            public int? Estc_Id { get; set; }
            public string Part_Direccion { get; set; }
            public string Ciud_Id { get; set; }
            public int? Part_UsuarioCreacion { get; set; }
            public DateTime? Part_FechaCreacion { get; set; }
            public int? Part_UsuarioModificacion { get; set; }
            public DateTime? Part_FechaModificacion { get; set; }
            public bool? Part_Estado { get; set; }

        }



        public class ParticipantesPorCursoViewModel1
        {
            public Cursos Curso { get; set; }
            public List<Participante> Participantes { get; set; }
            public List<int> ParticipantesAsociados { get; set; }
        }


    }
}
