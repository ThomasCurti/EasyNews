using Backend.Dbo;
using MySql.Data.MySqlClient;

namespace Backend.DataAccess
{
    public class EventQuery
    {
        public static MySqlCommand GetData(AppDb db)
        {
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM event;";
            return cmd;
        }

        public static MySqlCommand GetData(AppDb db, int id)
        {
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM event " +
                              $"WHERE id = {id};";
            return cmd;
        }
    }
}
