using AutoMapper;
using SistemaProcinco.Common.Models;
using SistemaProcinco.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProcinco.API.Extencions
{
    public class MappingProfileExtensions : Profile 
    {
        public MappingProfileExtensions()
        {
            CreateMap<CargosViewModel, tbCargos>().ReverseMap();
            CreateMap<CiudadesViewModel, tbCiudades>().ReverseMap();
            CreateMap<EmpleadosViewModel, tbEmpleados>().ReverseMap();
            CreateMap<EstadosViewModel, tbEstados>().ReverseMap();
            CreateMap<EstadosCivilesViewModel, tbEstadosCiviles>().ReverseMap();
            CreateMap<PantallasViewModel, tbPantallas>().ReverseMap();
            CreateMap<RolesViewModel, tbRoles>().ReverseMap();
            CreateMap<PantallasPorRolesViewModel, tbPantallasPorRoles>().ReverseMap();
            CreateMap<UsuariosViewModel, tbUsuarios>().ReverseMap();
            CreateMap<InformeEmpleadosViewModel, tbInformeEmpleados>().ReverseMap();
            CreateMap<TitulosViewModel, tbTitulos>().ReverseMap();
            CreateMap<TitulosPorEmpleadoViewModel, tbTitulosPorEmpleado>().ReverseMap();
            CreateMap<CategoriasViewModel, tbCategorias>().ReverseMap();
            CreateMap<ContenidoViewModel, tbContenido>().ReverseMap();
            CreateMap<ContenidoPorCursoViewModel, tbContenidoPorCurso>().ReverseMap();
            CreateMap<CursosImpartidosViewModel, tbCursosImpartidos>().ReverseMap();
            CreateMap<CursosViewModel, tbCursos>().ReverseMap();
            CreateMap<EmpresasViewModel, tbEmpresas>().ReverseMap();
            CreateMap<PantallasAndRolesViewModel, tbPantallas>().ReverseMap();
            CreateMap<ParticipanteViewModel, tbParticipantes>().ReverseMap();



        }
    }
}
