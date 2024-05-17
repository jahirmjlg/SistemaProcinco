using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class ContenidoPorCursoViewModel1
    {


        public class Curso
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





        public class Contenido
        {
            public int Cont_Id { get; set; }
            public string Cont_Descripcion { get; set; }
            public string Cont_DuracionHoras { get; set; }
            public int Cont_UsuarioCreacion { get; set; }
            public DateTime Cont_FechaCreacion { get; set; }
            public int Cont_UsuarioModificacion { get; set; }
            public DateTime Cont_FechaModificacion { get; set; }
            public bool Cont_Estado { get; set; }
            public int Cate_Id { get; set; }
        }



        public class ContenidoPorCursoViewModell
        {
            public Curso Curso { get; set; }
            public List<Contenido> Contenidos { get; set; }
            public List<int> ContenidosAsociados { get; set; }
        }


    }
}
