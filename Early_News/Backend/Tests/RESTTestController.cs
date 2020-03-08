using Backend.Controllers;
using Backend.Dbo;
using Backend.Model;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Tests
{
    public class RESTTestController
    {

        AppDb db;
        bool isSetup = false;
        bool isLocal = false;

        [SetUp]
        public void Setup()
        {
            if (!isLocal)
                db = new AppDb("server=mariadb;user=root;port=3306;password=admin;database=earlynews_test");
            else
                db = new AppDb("server=localhost;user=root;port=3306;password=admin;database=earlynews_test");

            if (!isSetup && !isLocal)
            {
                isSetup = true;

                db.Connection.Open();
                
                var cmd = db.Connection.CreateCommand();
                DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory);
                string path = Path.Combine(dir.Parent.Parent.Parent.FullName, "dbschema.sql");
                cmd.CommandText = File.ReadAllText(path);
                cmd.ExecuteNonQuery();

                /*"CREATE TABLE `Test_values` (" +
                "`ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT," +
                "`Value` INT(11) NULL DEFAULT NULL," +
                "`Text` LONGTEXT NULL," +
                "`Boolean` TINYINT(1) NOT NULL DEFAULT '0'," +
                "PRIMARY KEY(`ID`)" +
                ");";*/

                MySqlCommand comm = db.Connection.CreateCommand();
                path = Path.Combine(dir.Parent.Parent.Parent.FullName, "dummydata.sql");
                cmd.CommandText = File.ReadAllText(path);
                comm.ExecuteNonQuery();

                /*comm.CommandText = "INSERT INTO Test_values(ID,Value,Text,Boolean) VALUES(@ID, @Value, @Text, @Boolean)";
                comm.Parameters.AddWithValue("@ID", 1);
                comm.Parameters.AddWithValue("@Value", 1);
                comm.Parameters.AddWithValue("@Text", "TestText");
                comm.Parameters.AddWithValue("@Boolean", 0);*/

                db.Connection.Close();
            }
        }

        [Test]
        public void RESTArticleGetAllValues()
        {
            var controller = new ArticleController(db, false);

            var data = controller.Get();
            var test = data.Result.ToList();
            Assert.AreEqual(test.Count, 1);
        }


        [Test]
        public void RESTTestGetById()
        {
            var controller = new ArticleController(db, false);

            var data = controller.Get(1).Result;
            Assert.AreEqual(data.id, 1);
        }
    }
}