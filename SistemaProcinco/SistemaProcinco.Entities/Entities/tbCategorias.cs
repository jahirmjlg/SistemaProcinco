﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SistemaProcinco.Entities.Entities
{
    public partial class tbCategorias
    {
        public tbCategorias()
        {
            tbContenido = new HashSet<tbContenido>();
            tbCursos = new HashSet<tbCursos>();
        }

        //NOTMAPPED
        [NotMapped]
        public string Creacion { get; set; }
        [NotMapped]
        public string Modificacion { get; set; }


        public int Cate_Id { get; set; }
        public string Cate_Descripcion { get; set; }
        public string Cate_Imagen { get; set; }
        public int Cate_UsuarioCreacion { get; set; }
        public DateTime Cate_FechaCreacion { get; set; }
        public int? Cate_UsuarioModificacion { get; set; }
        public DateTime? Cate_FechaModificacion { get; set; }
        public bool? Cate_Estado { get; set; }

        public virtual tbUsuarios Cate_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Cate_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbContenido> tbContenido { get; set; }
        public virtual ICollection<tbCursos> tbCursos { get; set; }
    }
}