﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaProcinco.Entities.Entities
{
    public partial class tbParticipantes
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
        public string Ciud_id { get; set; }
        public int? Part_UsuarioCreacion { get; set; }
        public DateTime? Part_FechaCreacion { get; set; }
        public int? Part_UsuarioModificacion { get; set; }
        public DateTime? Part_FechaModificacion { get; set; }
        public bool? Part_Estado { get; set; }

        public virtual tbCiudades Ciud { get; set; }
        public virtual tbEmpresas Empre { get; set; }
        public virtual tbEstadosCiviles Estc { get; set; }
        public virtual tbUsuarios Part_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Part_UsuarioModificacionNavigation { get; set; }
    }
}