using Dapper;
using Microsoft.Data.SqlClient;
using SistemaProcinco.DataAcces.Repository;
using SistemaProcinco.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.DataAccess.Repository
{
    public class CursosImpartidosRepository : IRepository<tbCursosImpartidos>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.CursosImpartidosEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("CurIm_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbCursosImpartidos> Find(int? id)
        {
            string sql = ScriptsDatabase.CursosImpartidosBuscar;
            List<tbCursosImpartidos> result = new List<tbCursosImpartidos>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("CurIm_Id", id);
                result = db.Query<tbCursosImpartidos>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Insert(tbCursosImpartidos item)
        {
            string sql = ScriptsDatabase.CursosImpartidosCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Curso_Id", item.Curso_Id);
                parametro.Add("@Empl_Id", item.Empl_Id);
                parametro.Add("@CurIm_FechaInicio", item.CurIm_FechaInicio);
                parametro.Add("@CurIm_FechaFin", item.CurIm_FechaFin);
                parametro.Add("@CurIm_UsuarioCreacion", item.CurIm_UsuarioCreacion);
                parametro.Add("@CurIm_FechaCreacion", DateTime.Now);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbCursosImpartidos> List()
        {
            string sql = ScriptsDatabase.CursosImpartidosListar;

            List<tbCursosImpartidos> result = new List<tbCursosImpartidos>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbCursosImpartidos>(sql, commandType: System.Data.CommandType.Text).ToList();
                return result;
            }
        }



        public IEnumerable<tbCursosImpartidos> CursosMes()
        {
            string sql = ScriptsDatabase.CursosImpartidosMES;

            List<tbCursosImpartidos> result = new List<tbCursosImpartidos>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbCursosImpartidos>(sql, commandType: System.Data.CommandType.Text).ToList();
                return result;
            }
        }




        public RequestStatus Update(tbCursosImpartidos item)
        {
            string sql = ScriptsDatabase.CursosImpartidosActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@CurIm_Id", item.CurIm_Id);
                parametro.Add("@Curso_Id", item.Curso_Id);
                parametro.Add("@Empl_Id", item.Empl_Id);
                parametro.Add("@CurIm_FechaInicio", item.CurIm_FechaInicio);
                parametro.Add("@CurIm_FechaFin", item.CurIm_FechaFin);
                parametro.Add("@CurIm_UsuarioModificacion", item.CurIm_UsuarioModificacion);
                parametro.Add("@CurIm_FechaModificacion", item.CurIm_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public RequestStatus Finalizar(tbCursosImpartidos item)
        {
            string sql = ScriptsDatabase.CursosImpartidosFinalizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@CurIm_Id", item.CurIm_Id);
                parametro.Add("@CurIm_UsuarioFinalizacion", item.CurIm_UsuarioFinalizacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }



        public IEnumerable<tbCursosImpartidos> BuscarEmpleado(string Empl_DNI)
        {
            string sql = ScriptsDatabase.CursosImpartidosBuscarEmpleado;
            List<tbCursosImpartidos> result = new List<tbCursosImpartidos>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Empl_DNI", Empl_DNI);
                result = db.Query<tbCursosImpartidos>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }


        public IEnumerable<tbCursosImpartidos> BuscarCurso(string Curso_Descripcion)
        {
            string sql = ScriptsDatabase.CursosImpartidosBuscarCurso;
            List<tbCursosImpartidos> result = new List<tbCursosImpartidos>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Curso_Descripcion", Curso_Descripcion);
                result = db.Query<tbCursosImpartidos>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbCursosImpartidos> BuscarParticipante(string Curso_Descripcion)
        {
            string sql = ScriptsDatabase.CursosImpartidosParticipantes;
            List<tbCursosImpartidos> result = new List<tbCursosImpartidos>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Curso_Descripcion", Curso_Descripcion);
                result = db.Query<tbCursosImpartidos>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }


        public IEnumerable<tbCursosImpartidos> BuscarCursosFecha(DateTime FechaInicio, DateTime FechaFin)
        {
            string sql = ScriptsDatabase.CursosImpartidosEntreMeses;
            List<tbCursosImpartidos> result = new List<tbCursosImpartidos>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@FechaInicio", FechaInicio);
                parametro.Add("@FechaFin", FechaFin);
                result = db.Query<tbCursosImpartidos>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }


    }
}
