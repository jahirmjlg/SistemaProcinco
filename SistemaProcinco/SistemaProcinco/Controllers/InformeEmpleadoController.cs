using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class InformeEmpleadoController : Controller
    {
        private readonly ProcincoService _procincoService;
        private readonly IMapper _mapper;

        public InformeEmpleadoController(ProcincoService procincoService, IMapper mapper)
        {
            _procincoService = procincoService;
            _mapper = mapper;
        }
        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _procincoService.ListaInformesEmpleados();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPost("ImformeEmpleadoCrear")]
        public IActionResult Insert(InformeEmpleadosViewModel item)
        {
            var model = _mapper.Map<tbInformeEmpleados>(item);
            var modelo = new tbInformeEmpleados()
            {
                InfoE_Calificacion = item.InfoE_Calificacion,
                Empl_Id = item.Empl_Id,
                Curso_Id = item.Curso_Id,
                InfoE_Observaciones = item.InfoE_Observaciones,
                InfoE_UsuarioCreacion = 1,
                InfoE_FechaCreacion = DateTime.Now
            };
            var list = _procincoService.InsertarInformeEmpleados(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("InformeEmpladoEditar")]
        public IActionResult Edit(InformeEmpleadosViewModel item)
        {
            var model = _mapper.Map<tbInformeEmpleados>(item);
            var modelo = new tbInformeEmpleados()
            {
                InfoE_Id = item.InfoE_Id,
                InfoE_Calificacion = item.InfoE_Calificacion,
                Empl_Id = item.Empl_Id,
                Curso_Id = item.Curso_Id,
                InfoE_Observaciones = item.InfoE_Observaciones,
                InfoE_UsuarioModificacion = 1,
                InfoE_FechaModificacion = DateTime.Now
            };
            var list = _procincoService.EditarInformeEmpleados(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("InfomeEmpleadoEliminar/{InfoE_Id}")]
        public IActionResult Delete(int InfoE_Id)
        {
            var list = _procincoService.EliminarInformeEmpleados(InfoE_Id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }


        [HttpGet("InformeEmpleadoBuscar/{InfoE_Id}")]
        public IActionResult Details(int InfoE_Id)
        {
            var list = _procincoService.BuscarInformeEmpleados(InfoE_Id);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }

    }
}
