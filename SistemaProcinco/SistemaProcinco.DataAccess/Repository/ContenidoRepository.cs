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
    public class ContenidoRepository : IRepository<tbContenido>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.ContenidoEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Cont_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbContenido> Find(int? id)
        {
            string sql = ScriptsDatabase.ContenidoBuscar;
            List<tbContenido> result = new List<tbContenido>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Cont_Id", id);
                result = db.Query<tbContenido>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }



        public IEnumerable<tbContenido> FindCategoria(int? id)
        {
            string sql = ScriptsDatabase.ContenidoPorCategoriaBuscar;
            List<tbContenido> result = new List<tbContenido>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Cate_Id", id);
                result = db.Query<tbContenido>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Insert(tbContenido item)
        {
            string sql = ScriptsDatabase.ContenidoCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Cont_Descripcion", item.Cont_Descripcion);
                parametro.Add("@Cont_DuracionHoras", item.Cont_DuracionHoras);
                parametro.Add("@Cont_UsuarioCreacion", item.Cont_UsuarioCreacion);
                parametro.Add("@Cont_FechaCreacion", item.Cont_FechaCreacion);
                parametro.Add("@Cate_Id", item.Cate_Id);

                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbContenido> List()
        {
            string sql = ScriptsDatabase.ContenidoListar;

            List<tbContenido> result = new List<tbContenido>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbContenido>(sql, commandType: System.Data.CommandType.Text).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbContenido item)
        {
            string sql = ScriptsDatabase.ContenidoActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Cont_Id", item.Cont_Id);
                parametro.Add("@Cont_Descripcion", item.Cont_Descripcion);
                parametro.Add("@Cont_DuracionHoras", item.Cont_DuracionHoras);
                parametro.Add("@Cont_UsuarioModificacion", item.Cont_UsuarioModificacion);
                parametro.Add("@Cont_FechaModificacion", item.Cont_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }





















    }
}
