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
    public class EmpleadosRepository : IRepository<tbEmpleados>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.EmpleadosEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Empl_id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };

            }
        }

        public IEnumerable<tbEmpleados> Find(int? id)
        {
            string sql = ScriptsDatabase.EmpleadosLlenarEditar;
            List<tbEmpleados> result = new List<tbEmpleados>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Empl_Id", id);
                result = db.Query<tbEmpleados>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Insert(tbEmpleados item)
        {
            string sql = ScriptsDatabase.EmpleadosCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Empl_DNI", item.Empl_DNI);
                parametro.Add("@Carg_Id", item.Carg_Id);
                parametro.Add("@Empl_Nombre", item.Empl_Nombre);
                parametro.Add("@Empl_Apellido", item.Empl_Apellido);
                parametro.Add("@Empl_Correo", item.Empl_Correo);
                parametro.Add("@Empl_FechaNacimiento", item.Empl_FechaNacimiento);
                parametro.Add("@Empl_Sexo", item.Empl_Sexo);
                parametro.Add("@Estc_Id", item.Estc_Id);
                parametro.Add("@Empl_Direccion", item.Empl_Direccion);
                parametro.Add("@Ciud_Id", item.Ciud_id);
                parametro.Add("@Empl_UsuarioCreacion", item.Empl_UsuarioCreacion);
                parametro.Add("@Empl_FechaCreacion", item.Empl_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbEmpleados> List()
        {
            string sql = ScriptsDatabase.EmpleadosListar;

            List<tbEmpleados> result = new List<tbEmpleados>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbEmpleados>(sql, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbEmpleados item)
        {
            string sql = ScriptsDatabase.EmpleadosActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Empl_Id", item.Empl_Id);
                parametro.Add("@Empl_DNI", item.Empl_DNI);
                parametro.Add("@Carg_Id", item.Carg_Id);
                parametro.Add("@Empl_Nombre", item.Empl_Nombre);
                parametro.Add("@Empl_Apellido", item.Empl_Apellido);
                parametro.Add("@Empl_Correo", item.Empl_Correo);
                parametro.Add("@Empl_FechaNacimiento", item.Empl_FechaNacimiento);
                parametro.Add("@Empl_Sexo", item.Empl_Sexo);
                parametro.Add("@Estc_Id", item.Estc_Id);
                parametro.Add("@Empl_Direccion", item.Empl_Direccion);
                parametro.Add("@Ciud_Id", item.Ciud_id);
                parametro.Add("@Empl_UsuarioModificacion", item.Empl_UsuarioModificacion);
                parametro.Add("@Empl_FechaModificacion", item.Empl_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }
    }
}
