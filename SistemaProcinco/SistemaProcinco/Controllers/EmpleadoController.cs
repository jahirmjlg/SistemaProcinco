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
    public class EmpleadoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly GeneralService _generalService;
        public EmpleadoController(IMapper mapper, GeneralService generalService)
        {
            _mapper = mapper;
            _generalService = generalService;
        }

        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _generalService.ListaEmpleados();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPost("EmpleadoCrear")]
        public IActionResult Insert(EmpleadosViewModel item)
        {
            var model = _mapper.Map<tbEmpleados>(item);
            var modelo = new tbEmpleados()
            {
                Empl_DNI = item.Empl_DNI,
                Carg_Id = item.Carg_Id,
                Empl_Nombre = item.Empl_Nombre,
                Empl_Apellido = item.Empl_Apellido,
                Empl_Correo = item.Empl_Correo,
                Empl_FechaNacimiento = item.Empl_FechaNacimiento,
                Empl_Sexo = item.Empl_Sexo,
                Estc_Id = item.Estc_Id,
                Empl_Direccion = item.Empl_Direccion,
                Ciud_Id = item.Ciud_Id,
                Empl_UsuarioCreacion = 1,
                Empl_FechaCreacion = DateTime.Now


            };
            var list = _generalService.InsertarEmpleados(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("EmpleadoEditar")]
        public IActionResult Edit(EmpleadosViewModel item)
        {
            var model = _mapper.Map<tbEmpleados>(item);
            var modelo = new tbEmpleados()
            {
                Empl_Id = item.Empl_Id,
                Empl_DNI = item.Empl_DNI,
                Carg_Id = item.Carg_Id,
                Empl_Nombre = item.Empl_Nombre,
                Empl_Apellido = item.Empl_Apellido,
                Empl_Correo = item.Empl_Correo,
                Empl_FechaNacimiento = item.Empl_FechaNacimiento,
                Empl_Sexo = item.Empl_Sexo,
                Estc_Id = item.Estc_Id,
                Empl_Direccion = item.Empl_Direccion,
                Ciud_Id = item.Ciud_Id,
                Empl_UsuarioModificacion = 1,
                Empl_FechaModificacion = DateTime.Now


            };
            var list = _generalService.EditarEmpleados(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("EmpleadoEliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var list = _generalService.EliminarEmpleados(id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpGet("EmpleadoBuscar/{id}")]
        public IActionResult Details(int id)
        {
            var list = _generalService.BuscarEmpleados(id);
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
