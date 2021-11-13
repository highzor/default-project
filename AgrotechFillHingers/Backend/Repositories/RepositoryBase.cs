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

        public List<T> GetList()
        {
            TableAttribute attribute = (TableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(TableAttribute));
            ModelHelper<T> helper = new ModelHelper<T>(Connection.Query<T>($"SELECT * FROM {attribute.Name}", Transaction).AsList());
            return helper.ListParseAttribyteFromDb();
        }

        public List<T> GetList (string conditions, object parameters = null)
        {
            TableAttribute attribute = (TableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(TableAttribute));
            ModelHelper<T> helper = new ModelHelper<T>(Connection.Query<T>($"SELECT * FROM {attribute.Name} {conditions}", parameters, Transaction).AsList());
            return helper.ListParseAttribyteFromDb();
        }

        public T GetFirst(string conditions, object parameters = null)
        {
            TableAttribute attribute = (TableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(TableAttribute));
            ModelHelper<T> helper = new ModelHelper<T>(Connection.Query<T>($"SELECT * FROM {attribute.Name} {conditions}", parameters, Transaction).AsList());
            return helper.ListParseAttribyteFromDb().FirstOrDefault();
        }

        public List<T> Query(string queryText, object parameters = null)
        {
            ModelHelper<T> helper = new ModelHelper<T>(Connection.Query<T>(queryText, parameters, Transaction).AsList());
            return helper.ListParseAttribyteFromDb();
        }
    }
}
