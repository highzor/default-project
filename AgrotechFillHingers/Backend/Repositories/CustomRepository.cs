using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Repositories
{
    public class CustomRepository
    {
        protected IDbTransaction Transaction { get; private set; }
        protected IDbConnection Connection { get { return Transaction.Connection; } }

        public CustomRepository(IDbTransaction transaction)
        {
            Transaction = transaction;
        }

        public List<T> Query<T>(string queryText, object parameters = null)
        {
            return Connection.Query<T>(queryText, parameters, Transaction).AsList();
        }
    }
}
