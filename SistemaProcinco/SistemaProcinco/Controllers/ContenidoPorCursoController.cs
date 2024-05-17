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
    public class ContenidoPorCursoController : Controller
    {
        private readonly ProcincoService _procincoService;
        private readonly IMapper _mapper;

        public ContenidoPorCursoController(ProcincoService procincoService, IMapper mapper)
        {
            _procincoService = procincoService;
            _mapper = mapper;
        }
        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _procincoService.ListaContenidoPorCursos();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPost("ContenidoPorCursoCrear")]
        public IActionResult Insert(ContenidoPorCursoViewModel item)
        {
            var model = _mapper.Map<tbContenidoPorCurso>(item);
            var modelo = new tbContenidoPorCurso()
            {
                Cont_Id = item.Cont_Id,
                Curso_Id = item.Curso_Id,
                ConPc_UsuarioCreacion = 1,
                ConPc_FechaCreacion = DateTime.Now
            };
            var list = _procincoService.InsertarContenidosPorCursos(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("ContenidoPorCursoEditar")]
        public IActionResult Edit(ContenidoPorCursoViewModel item)
        {
            var model = _mapper.Map<tbContenidoPorCurso>(item);
            var modelo = new tbContenidoPorCurso()
            {
                ConPc_Id = item.ConPc_Id,
                Cont_Id = item.Cont_Id,
                Curso_Id = item.Curso_Id,
                ConPc_UsuarioModificacion = 1,
                ConPc_FechaModificacion = DateTime.Now
            };
            var list = _procincoService.EditarContenidosPorCursos(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("ContenidoPorCursoEliminar/{ConPc_Id}")]
        public IActionResult Delete(int ConPc_Id)
        {
            var list = _procincoService.EliminarContenidosPorCursos(ConPc_Id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpGet("ContenidoPorCursoBuscar/{ConPc_Id}")]
        public IActionResult BuscarCurso(int ConPc_Id)
        {
            var list = _procincoService.BuscarContenidoPorCursos(ConPc_Id);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }

        [HttpGet("CPCCursoBuscar/{curso}")]
        public IActionResult BuscarContenido(string curso)
        {
            var list = _procincoService.CPCBuscarCurso(curso);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }

        [HttpGet("CPCContenidoBuscar/{contenido}")]
        public IActionResult Details(string contenido)
        {
            var list = _procincoService.CPCBuscarContenido(contenido);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }






        //TRIVIEWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW









        [HttpPost("Create")]
        public IActionResult Insert(FormData formData)
        {
            var msj = new ServicesResult();
            string txtCurso = formData.txtCurso;
            int txtxEmpresa = formData.txtxEmpresa;
            int txtxHoras = formData.txtxHoras;
            string txtImagen = formData.txtImagen;
            int txtCategoria = formData.txtCategoria;

            List<int> contenidosSeleccionados = formData.contenidosSeleccionados;

            var modelo = new tbCursos()
            {
                Curso_Descripcion = txtCurso,
                Curso_DuracionHoras = txtxHoras,
                Curso_Imagen = txtImagen,
                Cate_Id = txtCategoria,
                Empre_Id = txtxEmpresa,
                Curso_UsuarioCreacion = 1,
                Curso_FechaCreacion = DateTime.Now
            };
            var list = _procincoService.InsertarCurso(modelo);

            if (int.TryParse(list, out int idCurso))
            {
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
        public IActionResult Delete(string id)
        {
            var list = _procincoService.EliminarContenidosCursos(id);
            var list2 = _procincoService.EliminarCurso(id);

            return Ok(new { success = true, message = list2.Message });
        }



        [HttpGet("ObtenerCursoConContenidos/{cursoId}")]
        public IActionResult ObtenerCursoConContenidos(int cursoId)
        {
            var result = _procincoService.ObtenerCursoConContenidos(cursoId);
            return Ok(result);
        }


    }
}
