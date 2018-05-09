using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class FraseCrudFactory : CrudFactory
    {
        FraseMapper mapper;

        public FraseCrudFactory() : base()
        {
            mapper = new FraseMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
                var frase = (Frase)entity;
                var sqlOperation = mapper.GetCreateStatement(frase);

                dao.ExecuteProcedure(sqlOperation);
        }

        public void AddPopularidad(BaseEntity entity)
        {
            var frase = (Frase)entity;
            var sqlOperation = mapper.GetAddPopularidadStatement(frase);

            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public List<T> RetrieveAllByPopularity<T>()
        {
            var lstFrases = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByPopularityStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstFrases.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstFrases;
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstFrases = new List<T>();
            
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstFrases.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
           
            return lstFrases;
        }

        public override void Update(BaseEntity entity)
        {
            var frase = (Frase)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(frase));
        }

        public override void Delete(BaseEntity entity)
        {
            var frase = (Frase)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(frase));
        }
    }
}
