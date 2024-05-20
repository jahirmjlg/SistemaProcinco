using Dapper;
using Microsoft.Data.SqlClient;
using SistemaProcinco.Common.Models;
using SistemaProcinco.DataAcces.Repository;
using SistemaProcinco.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SistemaProcinco.Common.Models.ContenidoPorCursoViewModel1;

namespace SistemaProcinco.DataAccess.Repository
{
    public class ContenidoPorCursoRepository : IRepository<tbContenidoPorCurso>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.ContenidoPorCursoEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("ConPc_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbContenidoPorCurso> Find(int? id)
        {
            string sql = ScriptsDatabase.ContenidoPorCursoBuscar;
            List<tbContenidoPorCurso> result = new List<tbContenidoPorCurso>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("ConPc_Id", id);
                result = db.Query<tbContenidoPorCurso>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Insert(tbContenidoPorCurso item)
        {
            string sql = ScriptsDatabase.ContenidoPorCursoCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Cont_Id", item.Cont_Id);
                parametro.Add("@Curso_Id", item.Curso_Id);
                parametro.Add("@ConPc_UsuarioCreacion", item.ConPc_UsuarioCreacion);
                parametro.Add("@ConPc_FechaCreacion", item.ConPc_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbContenidoPorCurso> List()
        {
            string sql = ScriptsDatabase.ContenidoPorCursoListar;

            List<tbContenidoPorCurso> result = new List<tbContenidoPorCurso>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbContenidoPorCurso>(sql, commandType: System.Data.CommandType.Text).ToList();

                return result;
            }
        }

        public RequestStatus Update(tbContenidoPorCurso item)
        {
            string sql = ScriptsDatabase.ContenidoPorCursoActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@ConPc_Id", item.ConPc_Id);
                parametro.Add("@Cont_Id", item.Cont_Id);
                parametro.Add("@Curso_Id", item.Curso_Id);
                parametro.Add("@ConPc_UsuarioModificacion", item.ConPc_UsuarioModificacion);
                parametro.Add("@ConPc_FechaModificacion", item.ConPc_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbContenidoPorCurso> BuscarCursos(string curso)
        {
            string sql = ScriptsDatabase.CPCCursoBuscar;
            List<tbContenidoPorCurso> result = new List<tbContenidoPorCurso>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Curso_Descripcion", curso);
                result = db.Query<tbContenidoPorCurso>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }

        }

        public IEnumerable<tbContenidoPorCurso> BuscarContenido(string cont_Descripcion)
        {
            string sql = ScriptsDatabase.CPCContenidosBuscar;
            List<tbContenidoPorCurso> result = new List<tbContenidoPorCurso>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Cont_Descripcion", cont_Descripcion);
                result = db.Query<tbContenidoPorCurso>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }






















        //TREVIEWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW

        public RequestStatus Insert1(tbContenidoPorCurso item)
        {
            const string sql = "[Pro].[SP_ContenidoPorCurso1_Insertar]";



            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Cont_Id", item.Cont_Id);
                parametro.Add("@Curso_Id", item.Curso_Id);
                parametro.Add("@ConPc_UsuarioCreacion", 1);
                parametro.Add("@ConPc_FechaCreacion", DateTime.Now);

                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public IEnumerable<tbContenidoPorCurso> List1()
        {
            const string sql = "[Pro].[SP_ContenidoPorCurso_Seleccionar]";

            List<tbContenidoPorCurso> result = new List<tbContenidoPorCurso>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbContenidoPorCurso>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
        }

        public IEnumerable<tbContenidoPorCurso> Fill1(int id)
        {
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("ConPc_Id", id);
                return db.Query<tbContenidoPorCurso>(ScriptsDatabase.ContenidoPorCursoBuscar, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<tbCursos> Fill2(int id)
        {
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Curso_Id", id);
                return db.Query<tbCursos>(ScriptsDatabase.CursosBuscar, parameter, commandType: CommandType.StoredProcedure);
            }
        }


        public RequestStatus Update1(tbContenidoPorCurso item)
        {
            string sql = ScriptsDatabase.ContenidoPorCursoActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@ConPc_Id", item.ConPc_Id);
                parameter.Add("@Cont_Id", item.Cont_Id);
                parameter.Add("@Curso_Id", item.Curso_Id);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }



        public RequestStatus Delete1(string Curso_Id)
        {
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Curso_Id", Curso_Id);

                var result = db.QueryFirst(ScriptsDatabase.ContenidoPorCursoEliminarEliminado, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            }
        }








        public ContenidoPorCursoViewModell ObtenerCursoConContenidos(int cursoId)
        {
            const string sql = "[Pro].[SP_CursoConContenidos_Buscar]";

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                using (var multi = db.QueryMultiple(sql, new { Curso_Id = cursoId }, commandType: CommandType.StoredProcedure))
                {
                    var curso = multi.ReadSingle<Curso>();
                    var contenidos = multi.Read<Contenido>().ToList();
                    var contenidosAsociados = multi.Read<int>().ToList();

                    return new ContenidoPorCursoViewModell
                    {
                        Curso = curso,
                        Contenidos = contenidos,
                        ContenidosAsociados = contenidosAsociados
                    };
                }
            }
        }

    }
}
