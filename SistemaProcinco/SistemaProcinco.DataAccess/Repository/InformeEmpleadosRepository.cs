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
    public class InformeEmpleadosRepository : IRepository<tbInformeEmpleados>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.InformeEmpleadosEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("InforE_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbInformeEmpleados> Find(int? id)
        {
            string sql = ScriptsDatabase.InformeEmpleadosBuscar;
            List<tbInformeEmpleados> result = new List<tbInformeEmpleados>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("InforE_Id", id);
                result = db.Query<tbInformeEmpleados>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Insert(tbInformeEmpleados item)
        {
            string sql = ScriptsDatabase.InformeEmpleadosCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@InfoE_Calificacion", item.InfoE_Calificacion);
                parametro.Add("@Empl_Id", item.Empl_Id);
                parametro.Add("@Curso_Id", item.Curso_Id);
                parametro.Add("@InfoE_Observaciones", item.InfoE_Observaciones);
                parametro.Add("@InfoE_UsuarioCreacion", item.InfoE_UsuarioCreacion);
                parametro.Add("@InfoE_FechaCreacion", item.InfoE_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbInformeEmpleados> List()
        {
            string sql = ScriptsDatabase.InformeEmpleadosListar;

            List<tbInformeEmpleados> result = new List<tbInformeEmpleados>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbInformeEmpleados>(sql, commandType: System.Data.CommandType.Text).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbInformeEmpleados item)
        {
            string sql = ScriptsDatabase.InformeEmpleadosActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@InfoE_Id", item.InfoE_Id);
                parametro.Add("@InfoE_Calificacion", item.InfoE_Calificacion);
                parametro.Add("@Empl_Id", item.Empl_Id);
                parametro.Add("@Curso_Id", item.Curso_Id);
                parametro.Add("@InfoE_Observaciones", item.InfoE_Observaciones);
                parametro.Add("@InfoE_UsuarioModificacion", item.InfoE_UsuarioModificacion);
                parametro.Add("@InfoE_FechaModificacion", item.InfoE_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }
    }
}
