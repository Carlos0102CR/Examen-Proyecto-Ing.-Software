using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class IdiomaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_POPULARIDAD = "POPULARIDAD";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "CRE_IDIOMA_PR"};

            var i = (Idioma) entity;            
            operation.AddVarcharParam(DB_COL_NOMBRE, i.Nombre);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "RET_IDIOMA_PR" };

            var i = (Idioma)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, i.Nombre);

            return operation;
        }


        public SqlOperation GetRetriveMostPopularStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_IDIOMA_MOST_POPULAR_PR" };
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_IDIOMA_PR" };            
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
            var idioma = new Idioma
            {
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Popularidad = GetIntValue(row, DB_COL_POPULARIDAD)
            };

            return idioma;
        }       

    }
}
