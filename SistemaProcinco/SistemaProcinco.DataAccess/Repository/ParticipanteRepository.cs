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
    public class ParticipanteRepository : IRepository<tbParticipantes>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.ParticipanteEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Part_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };

            }
        }

        public IEnumerable<tbParticipantes> Find(int? id)
        {
            string sql = ScriptsDatabase.ParticipanteLlenar;
            List<tbParticipantes> result = new List<tbParticipantes>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Part_Id", id);
                result = db.Query<tbParticipantes>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Insert(tbParticipantes item)
        {
            string sql = ScriptsDatabase.ParticipanteInsertar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Part_DNI", item.Part_DNI);
                parametro.Add("@Empre_Id", item.Empre_Id);
                parametro.Add("@Part_Nombre", item.Part_Nombre);
                parametro.Add("@Part_Apellido", item.Part_Apellido);
                parametro.Add("@Part_Correo", item.Part_Correo);
                parametro.Add("@Part_FechaNacimiento", item.Part_FechaNacimiento);
                parametro.Add("@Part_Sexo", item.Part_Sexo);
                parametro.Add("@Estc_Id", item.Estc_Id);
                parametro.Add("@Part_Direccion", item.Part_Direccion);
                parametro.Add("@Ciud_Id", item.Ciud_Id);
                parametro.Add("@Part_UsuarioCreacion", item.Part_UsuarioCreacion);
                parametro.Add("@Part_FechaCreacion", item.Part_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbParticipantes> List()
        {
            string sql = ScriptsDatabase.ParticipanteListar;

            List<tbParticipantes> result = new List<tbParticipantes>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbParticipantes>(sql, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbParticipantes item)
        {
            string sql = ScriptsDatabase.ParticipanteActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Part_Id", item.Part_Id);
                parametro.Add("@Part_DNI", item.Part_DNI);
                parametro.Add("@Empre_Id", item.Empre_Id);
                parametro.Add("@Part_Nombre", item.Part_Nombre);
                parametro.Add("@Part_Apellido", item.Part_Apellido);
                parametro.Add("@Part_Correo", item.Part_Correo);
                parametro.Add("@Part_FechaNacimiento", item.Part_FechaNacimiento);
                parametro.Add("@Part_Sexo", item.Part_Sexo);
                parametro.Add("@Estc_Id", item.Estc_Id);
                parametro.Add("@Part_Direccion", item.Part_Direccion);
                parametro.Add("@Ciud_Id", item.Ciud_Id);
                parametro.Add("@Part_UsuarioModificacion", item.Part_UsuarioCreacion);
                parametro.Add("@Part_FechaModificacion", item.Part_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };

            }
        }
    }
}
