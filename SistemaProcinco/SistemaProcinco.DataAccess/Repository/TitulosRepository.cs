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
    public class TitulosRepository : IRepository<tbTitulos>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.TitulosEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Titl_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbTitulos> Find(int? id)
        {
            string sql = ScriptsDatabase.TitulosBuscar;
            List<tbTitulos> result = new List<tbTitulos>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Titl_Id", id);
                result = db.Query<tbTitulos>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Insert(tbTitulos item)
        {
            string sql = ScriptsDatabase.CargosCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Titl_Descripcion", item.Titl_Descripcion);
                parametro.Add("@Titl_ValorMonetario", item.Titl_ValorMonetario);
                parametro.Add("@Titl_UsuarioCreacion", item.Titl_UsuarioCreacion);
                parametro.Add("@Titl_FechaCreacion", item.Titl_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbTitulos> List()
        {
            string sql = ScriptsDatabase.TitulosListar;

            List<tbTitulos> result = new List<tbTitulos>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbTitulos>(sql, commandType: System.Data.CommandType.Text).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbTitulos item)
        {
            string sql = ScriptsDatabase.TitulosActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Titl_Id", item.Titl_Id);
                parametro.Add("@Titl_Descripcion", item.Titl_Descripcion);
                parametro.Add("@Titl_ValorMonetario", item.Titl_ValorMonetario);
                parametro.Add("@Titl_UsuarioModificacion", item.Titl_UsuarioModificacion);
                parametro.Add("@Titl_FechaModificacion", item.Titl_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }
    }
}
