using AutoMapper;
using Backend.Controllers;
using Backend.DataAccess;
using Backend.DataAccess.EFModels;
using Backend.Dbo;
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
        private IMapper _mapper;

        private ArticleRepository _articleRepository;
        private ArticleSourceRepository _articleSourceRepository;
        private DubiousArticleRepository _dubiousArticleRepository;
        private EventRepository _eventRepository;
        private EventTypeRepository _eventTypeRepository;

        private readonly string gitlabConnection = "server=mariadb;user=root;port=3306;password=admin;database=earlynews_test";
        private readonly string localConnection = "server=localhost;user=root;port=3306;password=admin;database=earlynews_test";

        private IMapper MappingData()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutomapperProfiles>();
            });
            IMapper mapper = new Mapper(config);
            return mapper;
        }

        [SetUp]
        public void Setup()
        {
            if (!isSetup)
            {
                _context = new earlynews_testContext();
                if (!isLocal)
                    _context.connectionString = gitlabConnection;
                _mapper = MappingData();

                _articleRepository = new ArticleRepository(_context, _mapper);
                _articleSourceRepository = new ArticleSourceRepository(_context, _mapper);
                _dubiousArticleRepository = new DubiousArticleRepository(_context, _mapper);
                _eventRepository = new EventRepository(_context, _mapper);
                _eventTypeRepository = new EventTypeRepository(_context, _mapper);
            }

            if (!isSetup && !isLocal)
            {

                if (!isLocal)
                {
                    db = new AppDb(gitlabConnection);
                }
                else
                {
                    db = new AppDb(localConnection);
                }

                isSetup = true;

                db.Connection.Open();
                
                var cmd = db.Connection.CreateCommand();
                DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory);
                string path = Path.Combine(dir.Parent.Parent.Parent.FullName, "dbschema.sql");
                cmd.CommandText = File.ReadAllText(path);
                Console.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();

                MySqlCommand comm = db.Connection.CreateCommand();
                path = Path.Combine(dir.Parent.Parent.Parent.FullName, "dummydata.sql");
                comm.CommandText = File.ReadAllText(path);
                Console.WriteLine(comm.CommandText);
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
            Assert.AreEqual(1, test2.Count);
        }

        [Test]
        public void RESTArticleGetById()
        {
            var controller = new ArticleController(_articleRepository, false);

            var data = controller.Get(1).Result;
            Assert.AreEqual(1, data.id);
        }

        [Test]
        public void RESTArticleSourceGetAllValues()
        {
            var controller = new ArticleSourceController(_articleSourceRepository, false);

            var data = controller.Get();
            var test = data.Result.ToList();
            Assert.AreEqual(1, test.Count);
        }

        [Test]
        public void RESTArticleSourceGetById()
        {
            var controller = new ArticleSourceController(_articleSourceRepository, false);

            var data = controller.Get(1).Result;
            Assert.AreEqual(1, data.id);
        }

        [Test]
        public void RESTDubiousArticleGetAllValues()
        {
            var controller = new DubiousArticleController(_dubiousArticleRepository, false);

            var data = controller.Get();
            var test = data.Result.ToList();
            Assert.AreEqual(0, test.Count);
        }

        [Test]
        public void RESTDubiousArticleGetById()
        {
            var controller = new DubiousArticleController(_dubiousArticleRepository, false);

            var data = controller.Get(1).Result;
            Assert.AreEqual(null, data);
        }

        [Test]
        public void RESTEventGetAllValues()
        {
            var controller = new EventController(_eventRepository, false);

            var data = controller.Get();
            var test = data.Result.ToList();
            Assert.AreEqual(1, test.Count);
        }

        [Test]
        public void RESTEventGetById()
        {
            var controller = new EventController(_eventRepository, false);

            var data = controller.Get(1).Result;
            Assert.AreEqual(1, data.id);
        }

        [Test]
        public void RESTEventTypeGetAllValues()
        {
            var controller = new EventTypeController(_eventTypeRepository, false);

            var data = controller.Get();
            var test = data.Result.ToList();
            Assert.AreEqual(1, test.Count);
        }

        [Test]
        public void RESTEventTypeGetById()
        {
            var controller = new EventTypeController(_eventTypeRepository, false);

            var data = controller.Get(1).Result;
            Assert.AreEqual(1, data.id);
        }

    }
}