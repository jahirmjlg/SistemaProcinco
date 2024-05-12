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
    public class CursosRepository : IRepository<tbCursos>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.CursosEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Curso_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbCursos> Find(int? id)
        {
            string sql = ScriptsDatabase.CursosBuscar;
            List<tbCursos> result = new List<tbCursos>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Curso_Id", id);
                result = db.Query<tbCursos>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }


        public IEnumerable<tbCursos> FindCattegoria(int? id)
        {
            string sql = ScriptsDatabase.CursosPorCategoriaBuscar;
            List<tbCursos> result = new List<tbCursos>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Cate_Id", id);
                result = db.Query<tbCursos>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Insert(tbCursos item)
        {
            string sql = ScriptsDatabase.CursosCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Curso_Descripcion", item.Curso_Descripcion);
                parametro.Add("@Curso_DuracionHoras", item.Curso_DuracionHoras);
                parametro.Add("@Curso_Imagen", item.Curso_Imagen);
                parametro.Add("@Cate_Id", item.Cate_Id);
                parametro.Add("@Empre_Id", item.Empre_Id);

                parametro.Add("@Curso_UsuarioCreacion", item.Curso_UsuarioCreacion);
                parametro.Add("@Curso_FechaCreacion", item.Curso_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }


        public (RequestStatus, int) InsertId(tbCursos item)
        {
            string sql = ScriptsDatabase.CursosCrearId;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Curso_Descripcion", item.Curso_Descripcion);
                parametro.Add("@Curso_DuracionHoras", item.Curso_DuracionHoras);
                parametro.Add("@Curso_Imagen", item.Curso_Imagen);
                parametro.Add("@Cate_Id", item.Cate_Id);
                parametro.Add("@Empre_Id", item.Empre_Id);

                parametro.Add("@Curso_UsuarioCreacion", item.Curso_UsuarioCreacion);
                parametro.Add("@Curso_FechaCreacion", item.Curso_FechaCreacion);
                parametro.Add("@Curso_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                int curso_Id = parametro.Get<int>("@Curso_Id");

                string mensaje = (result == 1) ? "exito" : "error";
                return (new RequestStatus { CodeStatus = result, MessageStatus = "" }, curso_Id);
            }
        }

        public IEnumerable<tbCursos> List()
        {
            string sql = ScriptsDatabase.CursosListar;

            List<tbCursos> result = new List<tbCursos>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbCursos>(sql, commandType: System.Data.CommandType.Text).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbCursos item)
        {
            string sql = ScriptsDatabase.CursosActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Curso_Id", item.Curso_Id);
                parametro.Add("@Curso_Descripcion", item.Curso_Descripcion);
                parametro.Add("@Curso_DuracionHoras", item.Curso_DuracionHoras);
                parametro.Add("@Curso_Imagen", item.Curso_Imagen);
                parametro.Add("@Cate_Id", item.Cate_Id);
                parametro.Add("@Curso_UsuarioModificacion", item.Curso_UsuarioModificacion);
                parametro.Add("@Curso_FechaModificacion", item.Curso_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }
    }
}
