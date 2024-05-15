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
    public class ParticipanteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly GeneralService _generalService;

        private readonly ProcincoService _procincoService;


        public ParticipanteController(IMapper mapper, GeneralService generalService, ProcincoService procincoService)
        {
            _mapper = mapper;
            _generalService = generalService;
            _procincoService = procincoService;
        }

        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _generalService.ListaParticipantes();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }


        [HttpPost("ParticipanteCrear")]
        public IActionResult Insert(ParticipanteViewModel item)
        {
            var model = _mapper.Map<tbParticipantes>(item);
            var modelo = new tbParticipantes()
            {
                Part_DNI = item.Part_DNI,
                Empre_Id = item.Empre_Id,
                Part_Nombre = item.Part_Nombre,
                Part_Apellido = item.Part_Apellido,
                Part_Correo = item.Part_Correo,
                Part_FechaNacimiento = item.Part_FechaNacimiento,
                Part_Sexo = item.Part_Sexo,
                Estc_Id = item.Estc_Id,
                Part_Direccion = item.Part_Direccion,
                Ciud_Id = item.Ciud_Id,
                Part_UsuarioCreacion = 1,
                Part_FechaCreacion = DateTime.Now
            };

            var list = _generalService.InsertarParticipantes(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("ParticipanteEditar")]
        public IActionResult Edit(ParticipanteViewModel item)
        {
            var model = _mapper.Map<tbParticipantes>(item);
            var modelo = new tbParticipantes()
            {
                Part_Id = item.Part_Id,
                Part_DNI = item.Part_DNI,
                Empre_Id = item.Empre_Id,
                Part_Nombre = item.Part_Nombre,
                Part_Apellido = item.Part_Apellido,
                Part_Correo = item.Part_Correo,
                Part_FechaNacimiento = item.Part_FechaNacimiento,
                Part_Sexo = item.Part_Sexo,
                Estc_Id = item.Estc_Id,
                Part_Direccion = item.Part_Direccion,
                Ciud_Id = item.Ciud_Id,
                Part_UsuarioCreacion = 1,
                Part_FechaCreacion = DateTime.Now


            };
            var list = _generalService.EditarParticipantes(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("ParticipanteEliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var list = _generalService.EliminarParticipantes(id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }


        [HttpGet("ParticipanteBuscar/{id}")]
        public IActionResult Details(int id)
        {
            var list = _generalService.BuscarParticipantes(id);
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
