using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Data.Interfaces;

namespace WebSite.Data.EntityFramework
{
    public abstract class EntityFrameworkService : IDataRepository, IDisposable
    {
        WebSiteDatabase _connection;

        public WebSiteDatabase dbConnection
        {
            get { return _connection; }
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CloseSession()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction(bool closeSession)
        {
            throw new NotImplementedException();
        }

        public void CreateSession()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction(bool closeSession)
        {
            throw new NotImplementedException();
        }
    }
}
