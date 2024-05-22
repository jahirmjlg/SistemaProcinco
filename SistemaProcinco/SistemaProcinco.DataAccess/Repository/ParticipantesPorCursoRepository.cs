using Dapper;
using Microsoft.Data.SqlClient;
using SistemaProcinco.Common.Models;
using SistemaProcinco.DataAcces.Repository;
using SistemaProcinco.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SistemaProcinco.Common.Models.ParticipantesPorCursoViewModel;

namespace SistemaProcinco.DataAccess.Repository
{
   public class ParticipantesPorCursoRepository
    {
        public RequestStatus Insert(tbParticipantesPorCursoo item)
        {
            const string sql = "Pro.ParticipantesPorCurso_Insertar";



            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Part_Id", item.Part_Id);
                parametro.Add("@Curso_Id", item.Curso_Id);
                parametro.Add("@PaCur_UsuarioCreacion", 1);
                parametro.Add("@PaCur_FechaCreacion", DateTime.Now);

                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public IEnumerable<tbParticipantesPorCursoo> List1()
        {
            const string sql = "[Pro].[SP_ParticipantesPorCurso_Seleccionar]";

            List<tbParticipantesPorCursoo> result = new List<tbParticipantesPorCursoo>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbParticipantesPorCursoo>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
        }

        public IEnumerable<tbParticipantesPorCursoo> Fill1(int id)
        {
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("ParCu_Id", id);
                return db.Query<tbParticipantesPorCursoo>(ScriptsDatabase.participantePorCursoBuscar, parameter, commandType: CommandType.StoredProcedure);
            }
        }



        public IEnumerable<tbParticipantesPorCursoo> FillBueno(int id)
        {
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("CurIm_Id", id);
                return db.Query<tbParticipantesPorCursoo>(ScriptsDatabase.participantePorCursoImpartidoBuscar, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<tbCursos> Fill2(int id)
        {
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Curso_Id", id);
                return db.Query<tbCursos>(ScriptsDatabase.CursosBuscar, parameter, commandType: CommandType.StoredProcedure);
            }
        }


        public RequestStatus Update1(tbParticipantesPorCursoo item)
        {
            string sql = ScriptsDatabase.participantePorCursoActualizado;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@PaCur_Id", item.PaCur_Id);
                parameter.Add("@Part_Id", item.Part_Id);
                parameter.Add("@Curso_Id", item.Curso_Id);
                parameter.Add("@PaCur_UsuarioModificacion", 1);
                parameter.Add("@PaCur_FechaModificacion", DateTime.Now);


                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }



        public RequestStatus Delete1(int Curso_Id)
        {
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Curso_Id", Curso_Id);

                var result = db.QueryFirst(ScriptsDatabase.participantePorCursoEliminado, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            }
        }



        public ParticipantesPorCursoViewModel1 ObtenerCursoConParticipantes(int cursoId)
        {
            const string sql = "[Pro].[SP_ParticipantesPorCurso_BuscarPorCurso]";

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                using (var multi = db.QueryMultiple(sql, new { Curso_Id = cursoId }, commandType: CommandType.StoredProcedure))
                {
                    var curso = multi.ReadSingle<Cursos>();
                    var participantes = multi.Read<Participante>().ToList();
                    var participantesAsociados = multi.Read<int>().ToList();

                    return new ParticipantesPorCursoViewModel1
                    {
                        Curso = curso,
                        Participantes = participantes,
                        ParticipantesAsociados = participantesAsociados
                    };
                }
            }
        }


    }
}
