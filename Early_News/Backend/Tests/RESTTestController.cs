using Backend.Controllers;
using Backend.Dbo;
using Backend.Model;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class RESTTestController
    {

        AppDb db;
        TestController controller;

        [SetUp]
        public void Setup()
        {
            db = new AppDb("server=localhost;user=root;password=admin;database=Test");
            controller = new TestController(db, false);
        }

        [Test]
        public void RESTTestGetAllValues()
        {
            var data = controller.Get().Result.ToList();
            Assert.AreEqual(data.Count, 3);
        }


        [Test]
        public void RESTTestGetById()
        {
            var data = controller.Get(1).Result;
            Assert.AreEqual(data.ID, 1);
        }
    }
}