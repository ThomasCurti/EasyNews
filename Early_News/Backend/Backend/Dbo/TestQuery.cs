﻿using MySql.Data.MySqlClient;

namespace Backend.Dbo
{
    public static class TestQuery
    {
        public static MySqlCommand GetData(AppDb db)
        {
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Test_values;";
            return cmd;
        }

        public static MySqlCommand GetData(uint id, AppDb db)
        {
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Test_values " +
                              $"WHERE ID = {id};";
            return cmd;
        }

    }
}