using Backend.Controllers;
using Backend.Dbo;
using Backend.Model;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class RESTTestController
    {

        AppDb db;
        TestController controller;
        bool isSetup = false;

        [SetUp]
        public void Setup()
        {
            db = new AppDb("server=mariadb;user=root;port=3306;password=admin;database=Test");
            controller = new TestController(db, false);

            if (!isSetup)
            {
                isSetup = true;
                db.Connection.Open();
                
                var cmd = db.Connection.CreateCommand();
                cmd.CommandText = "CREATE TABLE `Test_values` (" +
	                "`ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT," +
	                "`Value` INT(11) NULL DEFAULT NULL," +
                    "`Text` LONGTEXT NULL," +
                    "`Boolean` TINYINT(1) NOT NULL DEFAULT '0'," +
                    "PRIMARY KEY(`ID`)" +
                    ");";
                cmd.ExecuteNonQuery();
                
                    
                MySqlCommand comm = db.Connection.CreateCommand();
                comm.CommandText = "INSERT INTO Test_values(ID,Value,Text,Boolean) VALUES(@ID, @Value, @Text, @Boolean)";
                comm.Parameters.AddWithValue("@ID", 1);
                comm.Parameters.AddWithValue("@Value", 1);
                comm.Parameters.AddWithValue("@Text", "TestText");
                comm.Parameters.AddWithValue("@Boolean", 0);
                comm.ExecuteNonQuery();
                db.Connection.Close();
            }
        }

        [Test]
        public void RESTTestGetAllValues()
        {
            var data = controller.Get();
            var test = data.Result.ToList();
            Assert.AreEqual(test.Count, 1);
        }


        [Test]
        public void RESTTestGetById()
        {
            var data = controller.Get(1).Result;
            Assert.AreEqual(data.ID, 1);
        }
    }
}