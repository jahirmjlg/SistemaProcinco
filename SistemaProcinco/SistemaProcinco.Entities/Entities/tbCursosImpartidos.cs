﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SistemaProcinco.Entities.Entities
{
    public partial class tbCursosImpartidos
    {
        public int CurIm_Id { get; set; }
        public int? Curso_Id { get; set; }
        [NotMapped]
        public string Cursos { get; set; }
        [NotMapped]
        public string Nombre { get; set; }
        public int? Empl_Id { get; set; }
        public DateTime? CurIm_FechaInicio { get; set; }
        public DateTime? CurIm_FechaFin { get; set; }
        public int CurIm_UsuarioFinalizacion { get; set; }
        public bool? CurIm_Finalizar { get; set; }
        public int CurIm_UsuarioCreacion { get; set; }
        public DateTime CurIm_FechaCreacion { get; set; }
        public int? CurIm_UsuarioModificacion { get; set; }
        public DateTime? CurIm_FechaModificacion { get; set; }
        public bool? CurIm_Estado { get; set; }
        [NotMapped]
        public string Creacion { get; set; }
        [NotMapped]
        public string Modificacion { get; set; }
        public virtual tbUsuarios CurIm_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios CurIm_UsuarioModificacionNavigation { get; set; }
        public virtual tbCursos Curso { get; set; }


        [NotMapped]
        public int Year { get; set; }
        [NotMapped]
        public int Month { get; set; }
        [NotMapped]
        public int TotalCursos { get; set; }
    }
}