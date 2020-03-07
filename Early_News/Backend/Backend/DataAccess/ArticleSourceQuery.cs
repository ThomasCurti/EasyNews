using Backend.Dbo;
using MySql.Data.MySqlClient;

namespace Backend.DataAccess
{
    public class ArticleSourceQuery
    {
        public static MySqlCommand GetData(AppDb db)
        {
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM article_source;";
            return cmd;
        }

        public static MySqlCommand GetData(AppDb db, int id)
        {
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM article_source " +
                              $"WHERE id = {id};";
            return cmd;
        }
    }
}
