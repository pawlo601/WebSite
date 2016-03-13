using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Data.EntityFramework;

namespace WebSite.EntityFramework
{
    public class DbContextConfiguration : DbConfiguration
    {
        public DbContextConfiguration()
        {
            //SetDatabaseInitializer(new DropCreateDatabaseAlways<WebSiteDatabase>());// drop all table
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
}
