using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaProcinco.BusinessLogic.Services;
using SistemaProcinco.Common.Models;
using SistemaProcinco.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProcinco.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadocivilController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;
        public EstadocivilController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _generalService.ListaEstadosCiviles();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }

        [HttpGet("ddl")]
        public IActionResult Lista()
        {
            var listado = _generalService.ListaEstadosCiviles();
            var drop = listado.Data as List<tbEstadosCiviles>;
            var esta = drop.Select(x => new SelectListItem
            {
                Text = x.Estc_Descripcion,
                Value = x.Estc_Id.ToString()

            }).ToList();

            esta.Insert(0, new SelectListItem { Text = "--SELECCIONE--", Value = "0" });

            return Ok(esta.ToList());
        }



        [HttpPost("EstadoCivilCrear")]
        public IActionResult Insert(EstadosCivilesViewModel item)
        {
            var model = _mapper.Map<tbEstadosCiviles>(item);
            var modelo = new tbEstadosCiviles()
            {
                Estc_Descripcion = item.Estc_Descripcion,
                Estc_UsuarioCreacion = 1,
                Estc_FechaCreacion = DateTime.Now


            };
            var list = _generalService.InsertarEstadosCiviles(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("EstadoCivilEditar")]
        public IActionResult Edit(EstadosCivilesViewModel item)
        {
            var model = _mapper.Map<tbEstadosCiviles>(item);
            var modelo = new tbEstadosCiviles()
            {
                Estc_Id = item.Estc_Id,
                Estc_Descripcion = item.Estc_Descripcion,
                Estc_UsuarioModificacion = 1,
                Estc_FechaModificacion = DateTime.Now
            };
            var list = _generalService.EditarEstadosCiviles(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("EstadoCivilEliminar")]
        public IActionResult Delete(int Estc_id)
        {
            var list = _generalService.EliminarEstadosCiviles(Estc_id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpGet("EstadosCivilesBuscar")]
        public IActionResult Details(int Estc_Id)
        {
            var list = _generalService.BuscarEstadosCiviles(Estc_Id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }
    }
}
