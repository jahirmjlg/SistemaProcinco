﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SistemaProcinco.Entities.Entities
{
    public partial class tbContenido
    {
        public tbContenido()
        {
            tbContenidoPorCurso = new HashSet<tbContenidoPorCurso>();
        }

        //NOTMAPPED
        [NotMapped]
        public string UsuarioCreacion { get; set; }
        [NotMapped]
        public string UsuarioModificacion { get; set; }

        public int Cont_Id { get; set; }
        public string Cont_Descripcion { get; set; }
        public int? Cont_DuracionHoras { get; set; }
        public int Cont_UsuarioCreacion { get; set; }
        public DateTime Cont_FechaCreacion { get; set; }
        public int? Cont_UsuarioModificacion { get; set; }
        public DateTime? Cont_FechaModificacion { get; set; }
        public bool? Cont_Estado { get; set; }
        public int? Cate_Id { get; set; }

        public virtual tbCategorias Cate { get; set; }
        public virtual tbUsuarios Cont_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Cont_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbContenidoPorCurso> tbContenidoPorCurso { get; set; }
    }
}