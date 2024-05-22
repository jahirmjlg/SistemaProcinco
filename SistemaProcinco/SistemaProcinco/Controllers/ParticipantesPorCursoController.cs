using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaProcinco.API.Clases;
using SistemaProcinco.BunisessLogic;
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
    public class ParticipantesPorCursoController : Controller
    {

        private readonly ProcincoService _procincoService;
        private readonly IMapper _mapper;

        public ParticipantesPorCursoController(ProcincoService procincoService, IMapper mapper)
        {
            _procincoService = procincoService;
            _mapper = mapper;
        }


        [HttpPost("Create")]
        public IActionResult Insert(FormDataParticipantes formData)
        {
            var msj = new ServicesResult();
            int txtCurso = formData.txtCurso;
            int txtempleado = formData.txtempleado;
            DateTime txtfechainicio = formData.txtfechainicio;
            DateTime txtfechafinal = formData.txtfechafinal;

            List<int> contenidosSeleccionados = formData.participantesSeleccionados;

            var modelo = new tbCursosImpartidos()
            {
                Curso_Id = txtCurso,
                Empl_Id = txtempleado,
                CurIm_FechaInicio = txtfechainicio,
                CurIm_FechaFin = txtfechafinal,
                CurIm_FechaCreacion = DateTime.Now
            };
            var list = _procincoService.InsertarCursoImparrtido(modelo);

            if (int.TryParse(list, out int idCurso))
            {
                foreach (var participante in contenidosSeleccionados)
                {
                    var modelo2 = new tbParticipantesPorCursoo()
                    {
                        Part_Id = participante,
                        Curso_Id = idCurso,
                    };

                    msj = _procincoService.InsertarParticipantesPorCurso(modelo2);
                }

                return Ok(new { success = true, message = msj.Message });
            }
            else
            {
                return BadRequest(new { success = false, message = "Error al insertar el curso." });
            }
        }




        [HttpGet("Fill/{id}")]
        public IActionResult Llenar(int id)
        {
            var list = _procincoService.obterContenidosCursos(id);
            if (list.Success)
            {
                return Ok(list.Data);
            }
            else
            {
                return BadRequest(list.Message);
            }
        }

        [HttpGet("FillDetalles/{id}")]
        public IActionResult FillDetalles(int id)
        {
            var list = _procincoService.ObtenerCursos(id);
            if (list.Success)
            {
                return Ok(list.Data);
            }
            else
            {
                return BadRequest(list.Message);
            }
        }



        [HttpGet("FillParticipantesPorCursoImpartido/{id}")]
        public IActionResult FillParticipantesPorCursoImpartido(int id)
        {
            var list = _procincoService.obterParticipantesCursosImpartidos(id);
            if (list.Success)
            {
                return Ok(list.Data);
            }
            else
            {
                return BadRequest(list.Message);
            }
        }

        [HttpPut("Edit")]
        public IActionResult Update(FormData formData)
        {
            var msj = new ServicesResult();
            List<int> contenidosSeleccionados = formData.contenidosSeleccionados;

            var modelo = new tbCursos()
            {
                Curso_Id = formData.Curso_Id,
                Curso_Descripcion = formData.txtCurso,
                Curso_DuracionHoras = formData.txtxHoras,
                Curso_Imagen = formData.txtImagen,
                Cate_Id = formData.txtCategoria,
                Empre_Id = formData.txtxEmpresa,
                Curso_UsuarioCreacion = 1,
                Curso_FechaCreacion = DateTime.Now
            };
            var list = _procincoService.EditarCurso(modelo);

            var idCurso = formData.Curso_Id;

            var res = _procincoService.EliminarContenidosCursos(idCurso.ToString());

            foreach (var contenido in contenidosSeleccionados)
            {
                var modelo2 = new tbContenidoPorCurso()
                {
                    Cont_Id = contenido,
                    Curso_Id = idCurso,
                };

                msj = _procincoService.InsertarContenidosCursos(modelo2);
            }

            return Ok(new { success = true, message = msj.Message });
        }








        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var list = _procincoService.EliminarParticipantesPorCurso(id);
            var list2 = _procincoService.EliminarCursosImpartidos(id);

            return Ok(new { success = true, message = list2.Message });
        }



        [HttpGet("ObtenerCursoConParticipantes/{cursoId}")]
        public IActionResult ObtenerCursoConParticipantes(int cursoId)
        {
            var result = _procincoService.ObtenerCursoConParticipantes(cursoId);
            return Ok(result);
        }


    
    }
}
