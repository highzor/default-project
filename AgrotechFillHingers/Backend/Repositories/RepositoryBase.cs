using AgrotechFillHingers.Backend.Helpers;
using AgrotechFillHingers.Backend.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AgrotechFillHingers.Backend.Repositories
{
    public class RepositoryBase<T> where T:IModel
    {
        protected IDbTransaction Transaction { get; private set; }
        protected IDbConnection Connection { get { return Transaction.Connection; } }

        public RepositoryBase(IDbTransaction transaction)
        {
            Transaction = transaction;
        }

        public List<T> GetList ()
        {
            ModelHelper<T> helper = new ModelHelper<T>(Connection.GetList<T>().AsList());
            return helper.ListParseAttribyteFromDb();
        }

        public List<T> GetList(string conditions, object parameters = null)
        {
            ModelHelper<T> helper = new ModelHelper<T>(Connection.GetList<T>(conditions, parameters, Transaction, null).AsList());
            return helper.ListParseAttribyteFromDb();
        }

        public T GetByID(int? id)
        {
            if (id > 0)
            {
                ModelHelper<T> helper = new ModelHelper<T>(Connection.GetList<T>(new { ID = id}, Transaction).FirstOrDefault());
                return helper.SingleParseAttribyteFromDb();
            }
            else
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }

        public int? Insert(T entity)
        {
            ModelHelper<T> helper = new ModelHelper<T>(entity);
            return Connection.Insert(helper.SingleParseAttribyteToDb(), Transaction);
        }

        public int? Update(T entity)
        {
            ModelHelper<T> helper = new ModelHelper<T>(entity);
            return Connection.Update(helper.SingleParseAttribyteToDb(), Transaction);
        }

        public int? Delete(T entity)
        {
            ModelHelper<T> helper = new ModelHelper<T>(entity);
            return Connection.Delete(helper.SingleParseAttribyteToDb(), Transaction);
        }
    }
}
