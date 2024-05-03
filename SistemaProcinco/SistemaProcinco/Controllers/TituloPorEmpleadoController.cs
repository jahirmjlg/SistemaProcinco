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
    public class TituloPorEmpleadoController : Controller
    {
        private readonly ProcincoService _procincoService;
        private readonly IMapper _mapper;

        public TituloPorEmpleadoController(ProcincoService procincoService, IMapper mapper)
        {
            _procincoService = procincoService;
            _mapper = mapper;
        }
        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _procincoService.ListaTitulosPorEmpleados();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPost("TitulosPorEmpleadosCrear")]
        public IActionResult Insert(TitulosPorEmpleadoViewModel item)
        {
            var model = _mapper.Map<tbTitulosPorEmpleado>(item);
            var modelo = new tbTitulosPorEmpleado()
            {
                Titl_Id = item.Titl_Id,
                Empl_Id = item.Empl_Id,
                TitPe_UsuarioCreacion = 1,
                TitPe_FechaCreacion = DateTime.Now
            };
            var list = _procincoService.InsertarTitulosPorEmpleados(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("TituloPorEmpladoEditar")]
        public IActionResult Edit(TitulosPorEmpleadoViewModel item)
        {
            var model = _mapper.Map<tbTitulosPorEmpleado>(item);
            var modelo = new tbTitulosPorEmpleado()
            {
                TitPe_Id = item.TitPe_Id,
                Titl_Id = item.Titl_Id,
                Empl_Id = item.Empl_Id,
                TitPe_UsuarioModificacion = 1,
                TitPe_FechaModificacion = DateTime.Now
            };
            var list = _procincoService.EditarTitulosPorEmpleados(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("TituloPorEmpleadoEliminar/{titPe_Id")]
        public IActionResult Delete(int titPe_Id)
        {
            var list = _procincoService.EliminarTitulosPorEmpleados(titPe_Id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpGet("TituloPorEmpleadoBuscar/{titPe_Id}")]
        public IActionResult Details(int titPe_Id)
        {
            var list = _procincoService.BuscarTitulosEmpleados(titPe_Id);
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
