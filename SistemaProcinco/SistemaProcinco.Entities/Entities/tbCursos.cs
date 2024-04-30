﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaProcinco.Entities.Entities
{
    public partial class tbCursos
    {
        public tbCursos()
        {
            tbContenidoPorCurso = new HashSet<tbContenidoPorCurso>();
            tbCursosImpartidos = new HashSet<tbCursosImpartidos>();
        }

        public int Curso_Id { get; set; }
        public string Curso_Descripcion { get; set; }
        public int? Curso_DuracionHoras { get; set; }
        public string Curso_Imagen { get; set; }
        public int? Cate_Id { get; set; }
        public int Curso_UsuarioCreacion { get; set; }
        public DateTime Curso_FechaCreacion { get; set; }
        public int? Curso_UsuarioModificacion { get; set; }
        public DateTime? Curso_FechaModificacion { get; set; }
        public bool? Curso_Estado { get; set; }

        public virtual tbCategorias Cate { get; set; }
        public virtual tbUsuarios Curso_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Curso_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbContenidoPorCurso> tbContenidoPorCurso { get; set; }
        public virtual ICollection<tbCursosImpartidos> tbCursosImpartidos { get; set; }
    }
}