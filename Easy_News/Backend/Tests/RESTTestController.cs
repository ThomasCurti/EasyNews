using AutoMapper;
using Backend.Controllers;
using Backend.DataAccess;
using Backend.DataAccess.EFModels;
using Backend.Dbo;
using Microsoft.EntityFrameworkCore;
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
        bool isLocal = true;

        private earlynews_testContext _context;
        private AutomapperProfiles _mapper;

        private ArticleRepository _articleRepository;
        private ArticleSourceRepository _articleSourceRepository;
        private DubiousArticleRepository _dubiousArticleRepository;
        private EventRepository _eventRepository;
        private EventTypeRepository _eventTypeRepository;

        private readonly string gitlabConnection = "server=mariadb;user=root;port=3306;password=admin;database=earlynews_test";
        private readonly string localConnection = "server=localhost;user=root;port=3306;password=admin;database=earlynews_test";

        [SetUp]
        public void Setup()
        {
            if (!isLocal)
            {
                db = new AppDb(gitlabConnection);
            }
            else
            {
                db = new AppDb(localConnection);
            }

            if (!isSetup)
            {
                _context = new earlynews_testContext();
                _mapper = new AutomapperProfiles();

                _articleRepository = new ArticleRepository(_context, _mapper as IMapper);
                _articleSourceRepository = new ArticleSourceRepository(_context, _mapper as IMapper);
                _dubiousArticleRepository = new DubiousArticleRepository(_context, _mapper as IMapper);
                _eventRepository = new EventRepository(_context, _mapper as IMapper);
                _eventTypeRepository = new EventTypeRepository(_context, _mapper as IMapper);
            }
            

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
            var controller = new ArticleController(_articleRepository, false);

            var data = controller.Get();
            var test = data.Result;
            var test2 = test.ToList();
            Assert.AreEqual(test2.Count, 1);
        }

        [Test]
        public void RESTArticleGetById()
        {
            var controller = new ArticleController(_articleRepository, false);

            var data = controller.Get(1).Result;
            Assert.AreEqual(data.id, 1);
        }

        [Test]
        public void RESTArticleSourceGetAllValues()
        {
            var controller = new ArticleSourceController(_articleSourceRepository, false);

            var data = controller.Get();
            var test = data.Result.ToList();
            Assert.AreEqual(test.Count, 1);
        }

        [Test]
        public void RESTArticleSourceGetById()
        {
            var controller = new ArticleSourceController(_articleSourceRepository, false);

            var data = controller.Get(1).Result;
            Assert.AreEqual(data.id, 1);
        }

        [Test]
        public void RESTDubiousArticleGetAllValues()
        {
            var controller = new DubiousArticleController(_dubiousArticleRepository, false);

            var data = controller.Get();
            var test = data.Result.ToList();
            Assert.AreEqual(test.Count, 0);
        }

        [Test]
        public void RESTDubiousArticleGetById()
        {
            var controller = new DubiousArticleController(_dubiousArticleRepository, false);

            var data = controller.Get(1).Result;
            Assert.AreEqual(data, null);
        }

        [Test]
        public void RESTEventGetAllValues()
        {
            var controller = new EventController(_eventRepository, false);

            var data = controller.Get();
            var test = data.Result.ToList();
            Assert.AreEqual(test.Count, 1);
        }

        [Test]
        public void RESTEventGetById()
        {
            var controller = new EventController(_eventRepository, false);

            var data = controller.Get(1).Result;
            Assert.AreEqual(data.id, 1);
        }

        [Test]
        public void RESTEventTypeGetAllValues()
        {
            var controller = new EventTypeController(_eventTypeRepository, false);

            var data = controller.Get();
            var test = data.Result.ToList();
            Assert.AreEqual(test.Count, 1);
        }

        [Test]
        public void RESTEventTypeGetById()
        {
            var controller = new EventTypeController(_eventTypeRepository, false);

            var data = controller.Get(1).Result;
            Assert.AreEqual(data.id, 1);
        }

    }
}