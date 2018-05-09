using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class TraduccionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_NOMBRE_USUARIO = "NOMBRE_USUARIO";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_IDIOMA = "IDIOMA";
        private const string DB_COL_FRASE_ORIGEN= "FRASE_ORIGEN";
        private const string DB_COL_FRASE_TRADUCIDA = "FRASE_TRADUCIDA";
        private const string DB_COL_POPULARIDAD = "POPULARIDAD";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "CRE_TRADUCCION_PR"};

            var t = (Traduccion) entity;            
            operation.AddVarcharParam(DB_COL_NOMBRE_USUARIO, t.Usuario);
            operation.AddDateParam(DB_COL_FECHA, t.Fecha);
            operation.AddVarcharParam(DB_COL_IDIOMA, t.Idioma);
            operation.AddVarcharParam(DB_COL_FRASE_ORIGEN, t.FraseEspannol);
            operation.AddVarcharParam(DB_COL_FRASE_TRADUCIDA, t.FraseIdioma);
            operation.AddIntParam(DB_COL_POPULARIDAD, t.Popularidad);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveByPalabraStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TRADUCCION_BY_PALABRA_PR" };

            var t = (Traduccion)entity;
            operation.AddVarcharParam(DB_COL_FRASE_ORIGEN, t.FraseEspannol);
            return operation; 
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TRADUCCION_PR" };
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
            var traduccion = new Traduccion
            {
                Usuario = GetStringValue(row, DB_COL_NOMBRE_USUARIO),
                Fecha = GetDateValue(row, DB_COL_FECHA),
                Idioma = GetStringValue(row, DB_COL_IDIOMA),
                FraseEspannol = GetStringValue(row, DB_COL_FRASE_ORIGEN),
                FraseIdioma = GetStringValue(row, DB_COL_FRASE_TRADUCIDA),
                Popularidad = GetIntValue(row, DB_COL_POPULARIDAD),
            };

            return traduccion;
        }
    }
}
