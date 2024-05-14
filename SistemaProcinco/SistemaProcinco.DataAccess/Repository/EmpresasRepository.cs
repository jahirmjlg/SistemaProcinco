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
    public class EmpresasRepository : IRepository<tbEmpresas>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.EmpresaEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Empre_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };

            }
        }


        public IEnumerable<tbEmpresas> Find1(int id)
        {
            string sql = ScriptsDatabase.EmpresaLlenar;
            List<tbEmpresas> result = new List<tbEmpresas>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Empre_Id ", id);
                result = db.Query<tbEmpresas>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }
        public RequestStatus Insert(tbEmpresas item)
        {
            string sql = ScriptsDatabase.EmpresaInsertar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Empre_Descripcion", item.Empre_Descripcion);
                parametro.Add("@Empre_Direccion", item.Empre_Direccion);
                parametro.Add("@Ciud_Id", item.Ciud_Id);

                parametro.Add("@Empre_UsuarioCreacion", item.Empre_UsuarioCreacion);
                parametro.Add("@Empre_FechaCreacion", item.Empre_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public RequestStatus Update(tbEmpresas item)
        {
            string sql = ScriptsDatabase.EmpresaActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Empre_Id", item.Empre_Id);
                parametro.Add("@Empre_Descripcion", item.Empre_Descripcion);
                parametro.Add("@Empre_Direccion", item.Empre_Direccion);
                parametro.Add("@Ciud_Id", item.Ciud_Id);

                parametro.Add("@Empre_UsuarioModificacion", item.Empre_UsuarioCreacion);
                parametro.Add("@Empre_FechaModificacion", item.Empre_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbEmpresas> List()
        {
            string sql = ScriptsDatabase.EmpresaListar;

            List<tbEmpresas> result = new List<tbEmpresas>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbEmpresas>(sql, commandType: System.Data.CommandType.Text).ToList();
                return result;
            }
        }

        public IEnumerable<tbEmpresas> Find(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
