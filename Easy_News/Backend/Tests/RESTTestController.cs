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
        bool isLocal = false;

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

                var logger = new LogRepository(_context, _mapper);

                _articleRepository = new ArticleRepository(_context, _mapper, logger);
                _articleSourceRepository = new ArticleSourceRepository(_context, _mapper, logger);
                _dubiousArticleRepository = new DubiousArticleRepository(_context, _mapper, logger);
                _eventRepository = new EventRepository(_context, _mapper, logger);
                _eventTypeRepository = new EventTypeRepository(_context, _mapper, logger);
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
            Assert.IsNotNull(test);

            var test2 = test.ToList();
            Assert.AreEqual(12, test2.Count);
        }

        [Test]
        public void RESTArticleGetById()
        {
            var controller = new ArticleController(_articleRepository, false);

            var data = controller.Get(1).Result;
            Assert.IsNotNull(data);
            Assert.AreEqual(1, data.id);
            Assert.AreEqual("Naissance du Coronavirus", data.title);
            Assert.AreEqual("Le coronavirus est une maladie qui est apparu en Chine dans la ville de Wuhan.", data.description);
            Assert.AreEqual("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce accumsan semper sodales. Fusce rhoncus, justo sed lacinia lacinia, sapien tellus dictum massa, ac viverra diam nibh non lacus. Sed tristique, eros ut fringilla sollicitudin, purus lacus facilisis orci, a euismod lectus elit sed nisi. Integer vestibulum erat vel metus consectetur auctor. Phasellus in suscipit sapien, nec rutrum dui. Maecenas tristique ornare velit, non dictum ante. Morbi interdum magna eu nulla cursus, non tincidunt odio mattis. Nam vehicula lectus ut eleifend luctus. Cras a ullamcorper lectus, ac cursus elit. Fusce nec ex risus. Morbi ipsum ligula, pulvinar ac laoreet sed, ultrices id ipsum. Duis blandit, augue vel pretium venenatis, velit sapien cursus nisl, a gravida lectus ex a dolor.", data.full_article);
            Assert.AreEqual(1, data.SourceId);
        }

        [Test]
        public void RESTArticleSourceGetAllValues()
        {
            var controller = new ArticleSourceController(_articleSourceRepository, false);

            var data = controller.Get();
            var test = data.Result.ToList();
            Assert.AreEqual(4, test.Count);
        }

        [Test]
        public void RESTArticleSourceGetById()
        {
            var controller = new ArticleSourceController(_articleSourceRepository, false);

            var data = controller.Get(1).Result;
            Assert.IsNotNull(data);
            Assert.AreEqual(1, data.id);
            Assert.AreEqual("AFP", data.name);
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
            Assert.IsNull(data);
        }

        [Test]
        public void RESTEventGetAllValues()
        {
            var controller = new EventController(_eventRepository, false);

            var data = controller.Get();
            Assert.IsNotNull(data);

            var test = data.Result.ToList();
            Assert.AreEqual(12, test.Count);
        }

        [Test]
        public void RESTEventGetById()
        {
            var controller = new EventController(_eventRepository, false);

            var data = controller.Get(1).Result;
            Assert.IsNotNull(data);
            Assert.AreEqual(1, data.id);
            Assert.AreEqual(new DateTime(2020, 3, 2), data.published);
            Assert.AreEqual(1, data.TypeId);
            Assert.AreEqual(1, data.ArticleId);
        }

        [Test]
        public void RESTEventTypeGetAllValues()
        {
            var controller = new EventTypeController(_eventTypeRepository, false);

            var data = controller.Get();
            Assert.IsNotNull(data);

            var test = data.Result.ToList();
            Assert.AreEqual(3, test.Count);
        }

        [Test]
        public void RESTEventTypeGetById()
        {
            var controller = new EventTypeController(_eventTypeRepository, false);

            var data = controller.Get(1).Result;
            Assert.IsNotNull(data);
            Assert.AreEqual(1, data.id);
            Assert.AreEqual("plague", data.name);
        }

    }
}