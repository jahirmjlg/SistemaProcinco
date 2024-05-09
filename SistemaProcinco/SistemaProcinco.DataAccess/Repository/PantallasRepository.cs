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
    public class PantallasRepository : IRepository<tbPantallas>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.PantallasEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Pant_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };

            }
        }

        public IEnumerable<tbPantallas> Find(int? id)
        {
            string sql = ScriptsDatabase.CiudadesLlenarEditar;
            List<tbPantallas> result = new List<tbPantallas>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Ciud_Id", id);
                result = db.Query<tbPantallas>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Insert(tbPantallas item)
        {
            string sql = ScriptsDatabase.PantallasCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Pant_Descripcion", item.Pant_Descripcion);
                parametro.Add("@Pant_UsuarioCreacion", item.Pant_UsuarioCreacion);
                parametro.Add("@Pant_FechaCreacion", item.Pant_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbPantallas> List()
        {
            string sql = ScriptsDatabase.PantallasListar;

            List<tbPantallas> result = new List<tbPantallas>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbPantallas>(sql,  commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public IEnumerable<tbPantallas> List1(int Role_Id)
        {
            string sql = ScriptsDatabase.PantallasFiltrar;

            List<tbPantallas> result = new List<tbPantallas>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Role_Id", Role_Id);
                result = db.Query<tbPantallas>(sql, parametro, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }


        public IEnumerable<tbPantallas> ListPantallasRol(int Role_Id)
        {
            string sql = ScriptsDatabase.PantallasRolFiltro;

            List<tbPantallas> result = new List<tbPantallas>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Role_Id", Role_Id);
                result = db.Query<tbPantallas>(sql, parametro, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public RequestStatus Update(tbPantallas item)
        {
            string sql = ScriptsDatabase.PantallasActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters(); 
                parametro.Add("@Pant_Id", item.Pant_Id);
                parametro.Add("@Pant_Descripcion", item.Pant_Descripcion);
                parametro.Add("@Pant_UsuarioModificacion", item.Pant_UsuarioModificacion);
                parametro.Add("@Pant_FechaModificacion", item.Pant_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }
    }
}
