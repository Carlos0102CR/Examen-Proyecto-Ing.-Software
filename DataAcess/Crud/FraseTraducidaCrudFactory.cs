using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class FraseTraducidaCrudFactory : CrudFactory
    {
        FraseTraducidaMapper mapper;

        public FraseTraducidaCrudFactory() : base()
        {
            mapper = new FraseTraducidaMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
                var fraseTraducida = (FraseTraducida)entity;
                var sqlOperation = mapper.GetCreateStatement(fraseTraducida);

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

        public override List<T> RetrieveAll<T>()
        {
            var lstFrasesTraducidas = new List<T>();
            
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstFrasesTraducidas.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
           
            return lstFrasesTraducidas;
        }

        public List<T> RetrieveAllByIdioma<T>(FraseTraducida fraseTraducida)
        {
            var lstFrasesTraducidas = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByIdiomaStatement(fraseTraducida));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstFrasesTraducidas.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstFrasesTraducidas;
        }

        public List<T> RetrieveAllByPalabra<T>(FraseTraducida fraseTraducida)
        {
            var lstFrasesTraducidas = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByPalabraStatement(fraseTraducida));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstFrasesTraducidas.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstFrasesTraducidas;
        }

        public override void Update(BaseEntity entity)
        {
            var fraseTraducida = (FraseTraducida)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(fraseTraducida));
        }

        public override void Delete(BaseEntity entity)
        {
            var fraseTraducida = (FraseTraducida)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(fraseTraducida));
        }
    }
}
