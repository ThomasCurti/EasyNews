using Backend.Dbo;
using MySql.Data.MySqlClient;

namespace Backend.DataAccess
{
    public class EventTypeQuery
    {
        public static MySqlCommand GetData(AppDb db)
        {
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM event_type;";
            return cmd;
        }

        public static MySqlCommand GetData(AppDb db, int id)
        {
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM event_type " +
                              $"WHERE id = {id};";
            return cmd;
        }
    }
}
