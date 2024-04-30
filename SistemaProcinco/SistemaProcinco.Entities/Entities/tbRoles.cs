﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaProcinco.Entities.Entities
{
    public partial class tbRoles
    {
        public tbRoles()
        {
            tbPantallasPorRoles = new HashSet<tbPantallasPorRoles>();
            tbUsuarios = new HashSet<tbUsuarios>();
        }

        public int Role_Id { get; set; }
        public string Role_Descripcion { get; set; }
        public int? Role_UsuarioCreacion { get; set; }
        public DateTime? Role_FechaCreacion { get; set; }
        public int? Role_UsuarioModificacion { get; set; }
        public DateTime? Role_FechaModificacion { get; set; }
        public bool? Role_Estado { get; set; }

        public virtual tbUsuarios Role_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Role_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbPantallasPorRoles> tbPantallasPorRoles { get; set; }
        public virtual ICollection<tbUsuarios> tbUsuarios { get; set; }
    }
}