using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class FraseMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_PALABRA = "PALABRA";
        private const string DB_COL_POPULARIDAD = "POPULARIDAD";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "CRE_FRASE_PR"};

            var f = (Frase) entity;            
            operation.AddVarcharParam(DB_COL_PALABRA, f.Palabra);

            return operation;
        }
        
        public SqlOperation GetAddPopularidadStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "ADD_FRASE_POPULARIDAD_PR" };

            var f = (Frase)entity;
            operation.AddVarcharParam(DB_COL_PALABRA, f.Palabra);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "RET_FRASE_PR" };

            var f = (Frase)entity;
            operation.AddVarcharParam(DB_COL_PALABRA, f.Palabra);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_FRASE_PR" };            
            return operation;
        }

        public SqlOperation GetRetriveAllByPopularityStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_FRASE_BY_POPULARITY_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
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
            var frase = new Frase
            {
                Palabra = GetStringValue(row, DB_COL_PALABRA),
                Popularidad = GetIntValue(row, DB_COL_POPULARIDAD)
            };

            return frase;
        }       

    }
}
