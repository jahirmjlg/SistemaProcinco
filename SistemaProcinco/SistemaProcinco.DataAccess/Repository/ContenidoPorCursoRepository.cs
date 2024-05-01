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
    }
}
