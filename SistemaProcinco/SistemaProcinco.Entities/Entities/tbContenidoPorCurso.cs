﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SistemaProcinco.Entities.Entities
{
    public partial class tbContenidoPorCurso
    {

        //NOTMAPPED
        [NotMapped]
        public string Cont_Descripcion { get; set; }
        [NotMapped]
        public string Cont_DuracionHoras { get; set; }
        [NotMapped]
        public string Curso_Descripcion { get; set; }
        [NotMapped]
        public string Curso_DuracionHoras { get; set; }
        [NotMapped]
        public string Curso_Imagen { get; set; }
        [NotMapped]
        public string Cate_Descripcion { get; set; }
        [NotMapped]
        public string Creacion { get; set; }
        [NotMapped]
        public string Modificacion { get; set; }


        public int ConPc_Id { get; set; }
        public int? Cont_Id { get; set; }
        public int? Curso_Id { get; set; }
        public int ConPc_UsuarioCreacion { get; set; }
        public DateTime ConPc_FechaCreacion { get; set; }
        public int? ConPc_UsuarioModificacion { get; set; }
        public DateTime? ConPc_FechaModificacion { get; set; }
        public bool? ConPc_Estado { get; set; }

        public virtual tbUsuarios ConPc_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios ConPc_UsuarioModificacionNavigation { get; set; }
        public virtual tbContenido Cont { get; set; }
        public virtual tbCursos Curso { get; set; }
    }
}