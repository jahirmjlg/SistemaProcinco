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
            throw new NotImplementedException();
        }

        public IEnumerable<tbEmpresas> Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbEmpresas item)
        {
            throw new NotImplementedException();
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

        public RequestStatus Update(tbEmpresas item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tbEmpresas> IRepository<tbEmpresas>.List()
        {
            throw new NotImplementedException();
        }
    }
}
