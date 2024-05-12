﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SistemaProcinco.Entities.Entities
{
    public partial class tbEstados
    {
        public tbEstados()
        {
            tbCiudades = new HashSet<tbCiudades>();
        }

        //NOTMAPPED
        [NotMapped]
        public string UsuarioCreacion { get; set; }

        [NotMapped]
        public string UsuarioModificacion { get; set; }

        public string Esta_Id { get; set; }
        public string Esta_Descripcion { get; set; }
        public int Esta_UsuarioCreacion { get; set; }
        public DateTime Esta_FechaCreacion { get; set; }
        public int? Esta_UsuarioModificacion { get; set; }
        public DateTime? Esta_FechaModificacion { get; set; }

        public virtual tbUsuarios Esta_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Esta_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbCiudades> tbCiudades { get; set; }
    }
}