using Amazon.S3;
using Amazon.S3.Transfer;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SistemaProcinco.BusinessLogic.Services;
using SistemaProcinco.Common.Models;
using SistemaProcinco.Entities.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProcinco.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursosController : Controller
    {
        private readonly ProcincoService _procincoService;
        private readonly IMapper _mapper;


        private readonly IAmazonS3 _s3Client;

        private readonly string _bucketName;

        public CursosController(IConfiguration configuration, ProcincoService procincoService, IMapper mapper, IAmazonS3 s3Client)
        {
            _procincoService = procincoService;
            _mapper = mapper;
            _s3Client = s3Client;
            _bucketName = configuration.GetValue<string>("AWS:BucketName");

            var awsOptions = configuration.GetSection("AWS");
            _s3Client = new AmazonS3Client(
                awsOptions["AccessKey"],
                awsOptions["SecretKey"],
               Amazon.RegionEndpoint.USEast2
            );

        }

        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _procincoService.ListaCursos();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPost("CursosCrear")]
        public IActionResult Insert(CursosViewModel item)
        {



            var model = _mapper.Map<tbCursos>(item);
            var modelo = new tbCursos()
            {
                Curso_Descripcion = item.Curso_Descripcion,
                Curso_DuracionHoras = item.Curso_DuracionHoras,
                Curso_Imagen = item.Curso_Imagen,
                Cate_Id = item.Cate_Id,
                Empre_Id = item.Empre_Id,

                Curso_UsuarioCreacion = 1,
                Curso_FechaCreacion = DateTime.Now
            };
            var list = _procincoService.InsertarCursos(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }




        [HttpPost("CursosCrearId")]
        public IActionResult InsertId(CursosViewModel item)
        {
            var model = _mapper.Map<tbCursos>(item);
            var modelo = new tbCursos()
            {
                Curso_Descripcion = item.Curso_Descripcion,
                Curso_DuracionHoras = item.Curso_DuracionHoras,
                Curso_Imagen = item.Curso_Imagen,
                Cate_Id = item.Cate_Id,
                Empre_Id = item.Empre_Id,

                Curso_UsuarioCreacion = 1,
                Curso_FechaCreacion = DateTime.Now
            };
            (var list, int CursoId) = _procincoService.InsertarCursosId(modelo);
            list.Message = CursoId.ToString();

            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }









        [HttpPut("CursosEditar")]
        public IActionResult Edit(CursosViewModel item)
        {
            var model = _mapper.Map<tbCursos>(item);
            var modelo = new tbCursos()
            {
                Curso_Id = item.Curso_Id,
                Curso_Descripcion = item.Curso_Descripcion,
                Curso_DuracionHoras = item.Curso_DuracionHoras,
                Curso_Imagen = item.Curso_Imagen,
                Cate_Id = item.Cate_Id,
                Curso_UsuarioModificacion = 1,
                Curso_FechaModificacion = DateTime.Now
            };
            var list = _procincoService.EditarCursos(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }


        [HttpDelete("CursoEliminar")]
        public IActionResult Delete(int Curso_Id)
        {
            var list = _procincoService.EliminarCursos(Curso_Id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpGet("CursosBuscar/{id}")]
        public IActionResult Details(int id)
        {
            var list = _procincoService.BuscarCursos(id);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }

        [HttpGet("CursosPorCategoriaBuscar/{id}")]
        public IActionResult DetailsCurso(int id)
        {
            var list = _procincoService.BuscarCursosPorCategoria(id);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }


        [HttpPost("cargarImagen")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            var allowedExtensions = new HashSet<string> { ".png", ".jpeg", ".svg", ".jpg", ".gif" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension))
            {
                return Ok(new { message = "Error" });
            }

            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var fileName = Path.GetFileName(file.FileName);
            using var fileStream = file.OpenReadStream();

            try
            {
                using (var stream = file.OpenReadStream())
                {
                    var transferUtility = new TransferUtility(_s3Client);
                    await transferUtility.UploadAsync(fileStream, _bucketName, fileName);

                    return Ok(new { message = $"Success" });
                }
            }
            catch (AmazonS3Exception e)
            {
                return StatusCode(500, $"AWS error: {e.ToString()}");
            }

        }


        [HttpGet("ddl")]
        public IActionResult Lista()
        {
            var listado = _procincoService.ListaCursos();
            var drop = listado.Data as List<tbCursos>;
            var esta = drop.Select(x => new SelectListItem
            {
                Text = x.Curso_Descripcion,
                Value = x.Curso_Id.ToString()

            }).ToList();

            esta.Insert(0, new SelectListItem { Text = "--SELECCIONE--", Value = "0" });

            return Ok(esta.ToList());
        }






        //TREVIEWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW





    }
}
