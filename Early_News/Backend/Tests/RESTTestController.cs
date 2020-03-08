using Backend.Controllers;
using Backend.Dbo;
using Backend.Model;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

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

                MySqlCommand comm = db.Connection.CreateCommand();
                path = Path.Combine(dir.Parent.Parent.Parent.FullName, "dummydata.sql");
                comm.CommandText = File.ReadAllText(path);
                comm.ExecuteNonQuery();

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
        public void RESTArticleGetById()
        {
            var controller = new ArticleController(db, false);

            var data = controller.Get(1).Result;
            Assert.AreEqual(data.id, 1);
        }

        [Test]
        public void RESTArticleSourceGetAllValues()
        {
            var controller = new ArticleSourceController(db, false);

            var data = controller.Get();
            var test = data.Result.ToList();
            Assert.AreEqual(test.Count, 1);
        }

        [Test]
        public void RESTArticleSourceGetById()
        {
            var controller = new ArticleSourceController(db, false);

            var data = controller.Get(1).Result;
            Assert.AreEqual(data.id, 1);
        }

        [Test]
        public void RESTDubiousArticleGetAllValues()
        {
            var controller = new DubiousArticleController(db, false);

            var data = controller.Get();
            var test = data.Result.ToList();
            Assert.AreEqual(test.Count, 0);
        }

        [Test]
        public void RESTDubiousArticleGetById()
        {
            var controller = new DubiousArticleController(db, false);

            var data = controller.Get(1).Result;
            Assert.AreEqual(data, null);
        }

        [Test]
        public void RESTEventGetAllValues()
        {
            var controller = new EventController(db, false);

            var data = controller.Get();
            var test = data.Result.ToList();
            Assert.AreEqual(test.Count, 1);
        }

        [Test]
        public void RESTEventGetById()
        {
            var controller = new EventController(db, false);

            var data = controller.Get(1).Result;
            Assert.AreEqual(data.id, 1);
        }

        [Test]
        public void RESTEventTypeGetAllValues()
        {
            var controller = new EventTypeController(db, false);

            var data = controller.Get();
            var test = data.Result.ToList();
            Assert.AreEqual(test.Count, 1);
        }

        [Test]
        public void RESTEventTypeGetById()
        {
            var controller = new EventTypeController(db, false);

            var data = controller.Get(1).Result;
            Assert.AreEqual(data.id, 1);
        }

    }
}