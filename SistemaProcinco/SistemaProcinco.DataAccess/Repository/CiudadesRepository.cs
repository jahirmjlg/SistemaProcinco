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
    public class CiudadesRepository : IRepository<tbCiudades>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Eliminar(string? id)
        {

            string sql = ScriptsDatabase.CiudadesEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };

            }
        }

        public IEnumerable<tbCiudades> Find(int? id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<tbCiudades> FindDetalle(string? id)
        {
            string sql = ScriptsDatabase.CiudadesLlenarEditar;
            List<tbCiudades> result = new List<tbCiudades>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Ciud_Id", id);
                result = db.Query<tbCiudades>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Insert(tbCiudades item)
        {
            string sql = ScriptsDatabase.CiudadesCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Ciud_Id", item.Ciud_Id);
                parametro.Add("@Ciud_Descripcion", item.Ciud_Descripcion);
                parametro.Add("@Esta_Id", item.Esta_Id);
                parametro.Add("@Ciud_UsuarioCreacion", item.Ciud_UsuarioCreacion);
                parametro.Add("@Ciud_FechaCreacion", item.Ciud_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };

            }
        }

        public IEnumerable<tbCiudades> List()
        {
            string sql = ScriptsDatabase.CiudadesListar;

            List<tbCiudades> result = new List<tbCiudades>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbCiudades>(sql, commandType: System.Data.CommandType.Text).ToList();

                return result;
            }
        }

        public RequestStatus Update(tbCiudades item)
        {
            string sql = ScriptsDatabase.CiudadesActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Ciud_Id", item.Ciud_Id);
                parametro.Add("@Ciud_Descripcion", item.Ciud_Descripcion);
                parametro.Add("@Esta_Id", item.Esta_Id);
                parametro.Add("@Ciud_UsuarioCreacion", item.Ciud_UsuarioCreacion);
                parametro.Add("@Ciud_FechaCreacion", item.Ciud_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }
    }
}
