using System.Data;
using ServiceStack.OrmLite;

namespace Common.Database
{
    public class DbSet
    {
        public static IDbConnection GetDb()
        {
            var dbFactory = new OrmLiteConnectionFactory(
                "qihuofupan.sqlite",
                SqliteDialect.Provider);
            return dbFactory.Open();
        }
    }
}