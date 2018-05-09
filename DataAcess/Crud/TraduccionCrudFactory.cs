using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class TraduccionCrudFactory : CrudFactory
    {
        TraduccionMapper mapper;

        public TraduccionCrudFactory() : base()
        {
            mapper = new TraduccionMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
                var traduccion = (Traduccion)entity;
                var sqlOperation = mapper.GetCreateStatement(traduccion);

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

        public List<T> RetrieveAllByPalabra<T>(BaseEntity entity)
        {
            var lstTraducciones = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByPalabraStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstTraducciones.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstTraducciones;
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstTraducciones = new List<T>();
            
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstTraducciones.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
           
            return lstTraducciones;
        }

        public override void Update(BaseEntity entity)
        {
            var traduccion = (Traduccion)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(traduccion));
        }

        public override void Delete(BaseEntity entity)
        {
            var traduccion = (Traduccion)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(traduccion));
        }
    }
}
