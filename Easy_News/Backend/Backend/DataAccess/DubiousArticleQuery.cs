using Backend.Dbo;
using MySql.Data.MySqlClient;

namespace Backend.DataAccess
{
    public class DubiousArticleQuery
    {
        public static MySqlCommand GetData(AppDb db)
        {
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM dubious_article;";
            return cmd;
        }
        
        public static MySqlCommand GetData(AppDb db, int id)
        {
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM dubious_article " +
                              $"WHERE id = {id};";
            return cmd;
        }

    }
}
