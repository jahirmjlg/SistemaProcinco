using SistemaProcinco.BunisessLogic;
using SistemaProcinco.Common.Models;
using SistemaProcinco.DataAccess.Repository;
using SistemaProcinco.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SistemaProcinco.Common.Models.ContenidoPorCursoViewModel1;
using static SistemaProcinco.Common.Models.ParticipantesPorCursoViewModel;

namespace SistemaProcinco.BusinessLogic.Services
{
    public class ProcincoService
    {
        public readonly CargosRepository _cargosRepository;
        public readonly CategoriasRepository _categoriasRepository;
        public readonly ContenidoRepository _contenidoRepository;
        public readonly ContenidoPorCursoRepository _contenidoPorCursoRepository;
        public readonly CursosRepository _cursosRepository;
        public readonly CursosImpartidosRepository _cursosImpartidosRepository;
        public readonly InformeEmpleadosRepository _informeEmpleadosRepository;
        public readonly TitulosRepository _titulosRepository;
        public readonly TitulosPorEmpleadosRepository _titulosPorEmpleadosRepository;
        public readonly ParticipanteRepository _participanteRepository;
        public readonly ParticipantesPorCursoRepository _participantesPorCurso;


        public ProcincoService(
              ParticipanteRepository participanteRepository, ParticipantesPorCursoRepository participantesPorCursorepository,
            CargosRepository cargosRepository, CategoriasRepository categoriasRepository, ContenidoRepository contenidoRepository,
            ContenidoPorCursoRepository contenidoPorCursoRepository, CursosRepository cursosRepository, CursosImpartidosRepository cursosImpartidosRepository,
            InformeEmpleadosRepository informeEmpleadosRepository, TitulosRepository titulosRepository, TitulosPorEmpleadosRepository titulosPorEmpleadosRepository)
        {
            _cargosRepository = cargosRepository;
            _categoriasRepository = categoriasRepository;
            _contenidoRepository = contenidoRepository;
            _contenidoPorCursoRepository = contenidoPorCursoRepository;
            _cursosRepository = cursosRepository;
            _cursosImpartidosRepository = cursosImpartidosRepository;
            _informeEmpleadosRepository = informeEmpleadosRepository;
            _titulosRepository = titulosRepository;
            _titulosPorEmpleadosRepository = titulosPorEmpleadosRepository;
            _participanteRepository = participanteRepository;
            _participantesPorCurso = participantesPorCursorepository;
        }

        #region Cargos 
        public ServicesResult ListaCargos()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cargosRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        public ServicesResult InsertarCargos(tbCargos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cargosRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EditarCargos(tbCargos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cargosRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarCargos(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cargosRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult BuscarCargos(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _cargosRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        #endregion

        #region Categorias
        public ServicesResult ListaCategorias()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _categoriasRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }

        public ServicesResult BuscarCatergorias(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _categoriasRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult InsertarCategorias(tbCategorias item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _categoriasRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServicesResult EditarCategorias(tbCategorias item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _categoriasRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarCategorias(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _categoriasRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Contenido
        public ServicesResult ListaContenido()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _contenidoRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }

        public ServicesResult BuscarContenido(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _contenidoRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult InsertarContenido(tbContenido item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _contenidoRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServicesResult EditarContenido(tbContenido item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _contenidoRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServicesResult EliminarContenido(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _contenidoRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region ContenidoPorCursos
        public ServicesResult ListaContenidoPorCursos()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _contenidoPorCursoRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        public ServicesResult BuscarContenidoPorCursos(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _contenidoPorCursoRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult InsertarContenidosPorCursos(tbContenidoPorCurso item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _contenidoPorCursoRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EditarContenidosPorCursos(tbContenidoPorCurso item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _contenidoPorCursoRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarContenidosPorCursos(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _contenidoPorCursoRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult CPCBuscarCurso(string Curso_Descripcion)
        {
            var result = new ServicesResult();
            try
            {
                var list = _contenidoPorCursoRepository.BuscarCursos(Curso_Descripcion);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult CPCBuscarContenido(string Contenido_Descripcion)
        {
            var result = new ServicesResult();
            try
            {
                var list = _contenidoPorCursoRepository.BuscarContenido(Contenido_Descripcion);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }


        public ServicesResult BuscarContenidoPorCategoria(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _contenidoRepository.FindCategoria(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        #endregion

        #region Cursos
        public ServicesResult ListaCursos()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }

        public ServicesResult BuscarCursos(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _cursosRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }


        public ServicesResult BuscarCursosPorCategoria(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _cursosRepository.FindCattegoria(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult InsertarCursos(tbCursos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }



        public (ServicesResult, int) InsertarCursosId(tbCursos item)
        {
            var result = new ServicesResult();
            int cursoId = 0;
            try
            {
                var lost = _cursosRepository.InsertId(item);
                cursoId = lost.Item2;
                if (lost.Item1.CodeStatus > 0)
                {
                    return (result.Ok(lost), cursoId);

                }
                else
                {
                    return (result.Error(lost), cursoId);
                }
            }
            catch (Exception ex)
            {
                return (result.Error(ex.Message), cursoId);
            }
        }

        public ServicesResult EditarCursos(tbCursos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarCursos(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion


        #region Cursos Impartidos
        public ServicesResult ListaCursosImpartidos()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }


        public ServicesResult ListaCategoriasFechas(DateTime FechaInicio, DateTime FechaFin)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.BuscarCategoriasFecha(FechaInicio, FechaFin);

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }



        public ServicesResult ListaCursosFechas(DateTime FechaInicio, DateTime FechaFin)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.BuscarCursosFecha(FechaInicio, FechaFin);

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }


        public ServicesResult ListaCursosEmpleados(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.BuscarCursosEmpleado(id);

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }

        //DASH
        public ServicesResult CursosImpartidosMes()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.CursosMes();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }



        public ServicesResult BuscarFactura(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _cursosImpartidosRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }



        public ServicesResult BuscarCursosImpartidos(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _cursosImpartidosRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult InsertarCursosImpartidos(tbCursosImpartidos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EditarCursosImpartidos(tbCursosImpartidos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarCursosImpartidos(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        public ServicesResult FinalizarCursosImpartidos(tbCursosImpartidos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.Finalizar(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }



        public ServicesResult BuscarEmpleado(string Empl_DNI)
        {
            var result = new ServicesResult();
            try
            {
                var list = _cursosImpartidosRepository.BuscarEmpleado(Empl_DNI);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }



        public ServicesResult BuscarCurso(string Curso_Descripcion)
        {
            var result = new ServicesResult();
            try
            {
                var list = _cursosImpartidosRepository.BuscarCurso(Curso_Descripcion);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }


        public ServicesResult BuscarParticipante(string Curso_Descripcion)
        {
            var result = new ServicesResult();
            try
            {
                var list = _cursosImpartidosRepository.BuscarParticipante(Curso_Descripcion);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }




        public ServicesResult ParticipantesFiltro(int curso, DateTime Fecha)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.ParticipantesCurso(curso, Fecha);

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }


        public ServicesResult FechasDDL(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.DDLFechas(id);

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }

        #endregion

        #region Informes Empleados
        public ServicesResult ListaInformesEmpleados()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _informeEmpleadosRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }

        public ServicesResult BuscarInformeEmpleados(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _informeEmpleadosRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult InsertarInformeEmpleados(tbInformeEmpleados item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _informeEmpleadosRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EditarInformeEmpleados(tbInformeEmpleados item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _informeEmpleadosRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarInformeEmpleados(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _informeEmpleadosRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        #endregion


        #region Titulos
        public ServicesResult ListaTitulos()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        public ServicesResult BuscarTitulos(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _titulosRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult InsertarTitulos(tbTitulos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EditarTitulos(tbTitulos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarTitulos(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion

        #region Titulos Por Empleados
        public ServicesResult ListaTitulosPorEmpleados()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosPorEmpleadosRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }

        public ServicesResult BuscarTitulosEmpleados(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _titulosPorEmpleadosRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        public ServicesResult InsertarTitulosPorEmpleados(tbTitulosPorEmpleado item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosPorEmpleadosRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EditarTitulosPorEmpleados(tbTitulosPorEmpleado item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosPorEmpleadosRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarTitulosPorEmpleados(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosPorEmpleadosRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion



        #region DASHBOARDS

        //DASH
        public ServicesResult CursosImpartidosTop5Mes()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.CursosImpartidosTop5Mes();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }


        public ServicesResult CursosImpartidosTop5PorMeses(int mes)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.CursosImpartidosTop5PorMeses(mes);

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }



        public ServicesResult CursosImpartidosCategorias()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.CursosImpartidosCategorias();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }



        public ServicesResult CursosImpartidosCategoriasMES(int mes)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.CursosImpartidosCategoriasMES(mes);

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }


        //
        /// ///////////////////////////
        /// 

        public ServicesResult EmpleadosMejorPagados()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.EmpleadosMejorPagados();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }


        public ServicesResult EmpleadosMejorPagadosFiltro(int mes)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.EmpleadosMejorPagadosFiltro(mes);

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }



        public ServicesResult HorasImpartidasPorCategoria()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.HorasImpartidasPorCategoria();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }



        public ServicesResult HorasImpartidasPorCategoriaFiltrado(int mes)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.HorasImpartidasPorCategoriaFiltrado(mes);

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }


        #endregion




        #region DRAGANDDROG EMPLEATOS TITULOS
        public ServicesResult ListaTituloss()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosRepository.List1();
                if (lost.Count() > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error();
                }

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }




        public ServicesResult ListaTitulosFiltro(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosRepository.List2(id);
                if (lost.Count() > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error();
                }

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }




        public ServicesResult ListaTitulosEmpleado(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosRepository.ListTitulosPorEmpleaddo(id);
                if (lost.Count() > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error();
                }

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }




        #endregion




        #region TREEVIEW CONTENIDO POR CURSOS bueno CURSOS



        public ServicesResult ListadoCurso()
        {
            var result = new ServicesResult();
            try
            {
                var list = _cursosRepository.List();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }




        public ServicesResult EditarCurso(tbCursos item)
        {
            var result = new ServicesResult();
            try
            {
                var list = _cursosRepository.Update1(item);
                if (list.CodeStatus > 0)
                {
                    return result.Ok("okis", list);
                }
                else
                {
                    return result.Error("Y existe un registro con ese nombre");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }




        public ServicesResult EliminarCurso(string Curso_Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _cursosRepository.Delete1(Curso_Id);
                if (list.CodeStatus > 0)
                {
                    return result.Ok("La acción ha sido exitosa", list);
                }
                else
                {
                    return result.Error("No se pudo realizar la acción");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        public string InsertarCurso(tbCursos item)
        {
            string error = "";
            try
            {
                int result = _cursosRepository.Insert1(item);
                if (result == 0)
                    error = "El código no es válido";
                else
                    error = result.ToString();
            }
            catch (Exception ex)
            {
                error = $"Error: {ex.Message} | StackTrace: {ex.StackTrace}";
            }
            return error;
        }






        public ServicesResult obterCurso(int id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _cursosRepository.Fill1(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }







        public ServicesResult ListadoContenidos()
        {
            var result = new ServicesResult();
            try
            {
                var list = _cursosRepository.ListContenidos1();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }





        #endregion






        #region CONTENIDO POR CURSO BUENOOOOOOOOOO


        public ServicesResult ListadoContenidosCursos()
        {
            var result = new ServicesResult();
            try
            {
                var list = _contenidoPorCursoRepository.List1();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }




        public ServicesResult EditarContenidosCursos(tbContenidoPorCurso item)
        {
            var result = new ServicesResult();
            try
            {
                var list = _contenidoPorCursoRepository.Update1(item);
                if (list.CodeStatus > 0)
                {
                    return result.Ok("okis", list);
                }
                else
                {
                    return result.Error("Y existe un registro con ese nombre");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        public ServicesResult EliminarContenidosCursos(string Curso_Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _contenidoPorCursoRepository.Delete1(Curso_Id);
                if (list.CodeStatus > 0)
                {
                    return result.Ok($"La accion ha sido existosa", list);
                }
                else
                {
                    return result.Error("No se pudo realizar la accion");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }








        public ServicesResult InsertarContenidosCursos(tbContenidoPorCurso item)
        {
            var result = new ServicesResult();
            try
            {
                var list = _contenidoPorCursoRepository.Insert1(item);
                if (list.CodeStatus > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error(list);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }









        public ContenidoPorCursoViewModell ObtenerCursoConContenidos(int cursoId)
        {
            return _contenidoPorCursoRepository.ObtenerCursoConContenidos(cursoId);
        }



        public ServicesResult obterContenidosCursos(int id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _contenidoPorCursoRepository.Fill1(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }


        public ServicesResult ObtenerCursos(int id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _contenidoPorCursoRepository.Fill2(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }











        #endregion







        #region ParticipantesPorCurso
        public ServicesResult InsertarParticipantesPorCurso(tbParticipantesPorCursoo item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _participantesPorCurso.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EditarParticipantesPorCurso(tbParticipantesPorCursoo item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _participantesPorCurso.Update1(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarParticipantesPorCurso(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _participantesPorCurso.Delete1(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }




        public ServicesResult obterParticipantesCursos(int id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _participantesPorCurso.Fill1(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult obterParticipantesCursosImpartidos(int id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _participantesPorCurso.FillBueno(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }


        public string InsertarCursoImparrtido(tbCursosImpartidos item)
        {
            string error = "";
            try
            {
                int result = _cursosImpartidosRepository.Insert1(item);
                if (result == 0)
                    error = "El código no es válido";
                else
                    error = result.ToString();
            }
            catch (Exception ex)
            {
                error = $"Error: {ex.Message} | StackTrace: {ex.StackTrace}";
            }
            return error;
        }


        public ParticipantesPorCursoViewModel1 ObtenerCursoConParticipantes(int cursoId)
        {
            return _participantesPorCurso.ObtenerCursoConParticipantes(cursoId);
        }



        public ServicesResult BuscarFactura1(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _cursosImpartidosRepository.FindFactura(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }


        //public ServicesResult ParticipantesPorCursoBuscar(string Curso_Descripcion)
        //{
        //    var result = new ServicesResult();
        //    try
        //    {
        //        var list = _contenidoPorCursoRepository.BuscarCursos(Curso_Descripcion);
        //        if (list.Count() > 0)
        //        {
        //            return result.Ok(list);
        //        }
        //        else
        //        {
        //            return result.Error();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex);
        //    }
        //}


        #endregion



    }
}





















