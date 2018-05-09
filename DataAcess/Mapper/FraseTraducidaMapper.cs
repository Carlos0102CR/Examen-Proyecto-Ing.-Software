using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class FraseTraducidaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_PALABRA = "PALABRA";
        private const string DB_COL_IDIOMA = "IDIOMA";
        private const string DB_COL_FRASE_ORIGEN = "FRASE_ORIGEN";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "CRE_FRASE_TRADUCIDA_PR"};

            var f = (FraseTraducida) entity;            
            operation.AddVarcharParam(DB_COL_PALABRA, f.PalabraTraducida);
            operation.AddVarcharParam(DB_COL_IDIOMA, f.NombreIdioma);
            operation.AddVarcharParam(DB_COL_FRASE_ORIGEN, f.Palabra);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "RET_FRASE_TRADUCIDA_PR" };

            var f = (FraseTraducida)entity;
            operation.AddVarcharParam(DB_COL_FRASE_ORIGEN, f.Palabra);
            operation.AddVarcharParam(DB_COL_IDIOMA, f.NombreIdioma);

            return operation;
        }

        public SqlOperation GetRetriveByIdiomaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_FRASE_TRADUCIDA_BY_IDIOMA_PR" };

            var f = (FraseTraducida)entity;
            operation.AddVarcharParam(DB_COL_IDIOMA, f.NombreIdioma);

            return operation;
        }

        public SqlOperation GetRetriveByPalabraStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_FRASE_TRADUCIDA_BY_PALABRA_PR" };

            var f = (FraseTraducida)entity;
            operation.AddVarcharParam(DB_COL_FRASE_ORIGEN, f.Palabra);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_FRASE_TRADUCIDA_PR" };            
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
                var fraseTraducida = BuildObject(row);
                lstResults.Add(fraseTraducida);
            }

            return lstResults;            
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var frase = new FraseTraducida
            {
                Palabra = GetStringValue(row, DB_COL_FRASE_ORIGEN),
                NombreIdioma = GetStringValue(row, DB_COL_IDIOMA),
                PalabraTraducida = GetStringValue(row, DB_COL_PALABRA)
            };

            return frase;
        }       

    }
}
