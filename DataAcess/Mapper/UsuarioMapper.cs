using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class UsuarioMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_CONTRASENNA = "CONTRASENNA";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "CRE_USUARIO_PR"};

            var u = (Usuario) entity;            
            operation.AddVarcharParam(DB_COL_NOMBRE, u.Nombre);
            operation.AddVarcharParam(DB_COL_CONTRASENNA, u.Contrasenna);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "RET_USUARIO_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, u.Nombre);

            return operation;
        }

        public SqlOperation GetRetriveByTraduccionStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_USUARIO_BY_TRADUCCION_PR" };
            return operation;
        }


        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USUARIO_PR" };            
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_USUARIO_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, u.Nombre);
            operation.AddVarcharParam(DB_COL_CONTRASENNA, u.Contrasenna);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_USUARIO_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, u.Nombre);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var customer = BuildObject(row);
                lstResults.Add(customer);
            }

            return lstResults;            
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var usuario = new Usuario
            {
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Contrasenna = GetStringValue(row, DB_COL_CONTRASENNA)
            };

            return usuario;
        }       

    }
}
