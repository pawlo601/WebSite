using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Data.Interfaces;

namespace WebSite.Data.EntityFramework
{
    public class EntityFrameworkService : IDataRepository, IDisposable
    {
        WebSiteDatabase _connection;

        public WebSiteDatabase dbConnection
        {
            get { return _connection; }
        }

        public void BeginTransaction()
        {
            
        }

        public void CloseSession()
        {
            
        }

        public void CommitTransaction(bool closeSession)
        {
            dbConnection.SaveChanges();
        }

        public void CreateSession()
        {
            _connection = new WebSiteDatabase();
        }

        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }

        public void RollbackTransaction(bool closeSession)
        {
            
        }
    }
}
