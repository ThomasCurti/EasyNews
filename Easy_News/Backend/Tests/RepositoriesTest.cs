using AutoMapper;
using Backend.DataAccess;
using Backend.DataAccess.EFModels;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Moq;

namespace Tests
{
    public class RepositoriesTest
    {
        earlynews_testContext _context;
        private IMapper _mapper;

        private ILogger _logger;

        private ArticleRepository _articleRepository;
        private ArticleSourceRepository _articleSourceRepository;
        private DubiousArticleRepository _dubiousArticleRepository;
        private EventRepository _eventRepository;
        private EventTypeRepository _eventTypeRepository;
        private ScenarioRepository _scenarioRepository;

        private void Seed()
        {
            var articles = new[]
            {
                new Article { Id = 1, Title = "Article1", Description = "DescArticle1", FullArticle = "FullArticle1", SourceId = 1 },
                new Article { Id = 2, Title = "Article2", Description = "DescArticle2", FullArticle = "FullArticle2", SourceId = 2 },
            };

            var scenarios = new[]
            {
                new Scenarios { Id = 1, Virus = "virus1", TownId = 1, BeginDate = "Date1", Description = "description1"},
                new Scenarios { Id = 2, Virus = "virus2", TownId = 2, BeginDate = "Date2", Description = "description2"},
            };

            var eventTypes = new[]
            {
                new EventType { Id = 1, Name = "EventType1"},
                new EventType { Id = 2, Name = "EventType2"},
            };

            var events = new[]
            {
                new Event { Id = 1, TypeId = 0, ArticleId = 0, Published = new DateTime() },
                new Event { Id = 2, TypeId = 1, ArticleId = 1, Published = new DateTime() },
            };

            var dubiousArticles = new[]
            {
                new DubiousArticle { Id = 1, Title = "dubious1", SourceId = 0, FullArticleSource = "source1", OtherSourceId = 0, FullArticleOther = "other1", SeenTwice = false },
                new DubiousArticle { Id = 2, Title = "dubious2", SourceId = 1, FullArticleSource = "source2", OtherSourceId = 1, FullArticleOther = "other2", SeenTwice = true },
            };

            var articleSources = new[]
            {
                new ArticleSource { Id = 1, Name = "source1"},
                new ArticleSource { Id = 2, Name = "source2"},
            };

            _context.AddRange(articles);
            _context.AddRange(scenarios);
            _context.AddRange(eventTypes);
            _context.AddRange(events);
            _context.AddRange(dubiousArticles);
            _context.AddRange(articleSources);

            _context.SaveChanges();
        }

        private IMapper MappingData()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutomapperProfiles>();
            });
            IMapper mapper = new Mapper(config);
            return mapper;
        }

        [TearDown]
        public void ClearAllRepoAndContext()
        {
            _context.Dispose();

            _articleRepository = null;
            _articleSourceRepository = null;
            _dubiousArticleRepository = null;
            _eventRepository = null;
            _eventTypeRepository = null;

            _context = null;
        }

        [SetUp]
        public void Setup()
        {
            //context
            var options = new DbContextOptionsBuilder<Backend.DataAccess.EFModels.earlynews_testContext>()
                               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                               .Options;
            _context = new earlynews_testContext(options);

            //Set data in context
            Seed();

            //Mapper
            _mapper = MappingData();

            //LogRepo
            var logger = new LogRepository(_context, _mapper, _logger);

            //logger
            _logger = new Mock<ILogger>().Object;

            //All other repo
            _articleRepository = new ArticleRepository(_context, _mapper, logger, _logger);
            _articleRepository.DoLog = false;

            _articleSourceRepository = new ArticleSourceRepository(_context, _mapper, logger, _logger);
            _articleSourceRepository.DoLog = false;

            _dubiousArticleRepository = new DubiousArticleRepository(_context, _mapper, logger, _logger);
            _dubiousArticleRepository.DoLog = false;

            _eventRepository = new EventRepository(_context, _mapper, logger, _logger);
            _eventRepository.DoLog = false;
            
            _eventTypeRepository = new EventTypeRepository(_context, _mapper, logger, _logger);
            _eventTypeRepository.DoLog = false;

            _scenarioRepository = new ScenarioRepository(_context, _mapper, logger, _logger);
            _scenarioRepository.DoLog = false;
        }

        [Test]
        public async Task ArticleInsert()
        {
            var res = await _articleRepository.Insert(new Backend.Dbo.Model.article());
            Assert.IsNotNull(res);
        }

        [Test]
        public async Task ArticleSourceInsert()
        {
            var res = await _articleSourceRepository.Insert(new Backend.Dbo.Model.article_source());
            Assert.IsNotNull(res);
        }

        [Test]
        public async Task DubiousArticleInsert()
        {
            var res = await _dubiousArticleRepository.Insert(new Backend.Dbo.Model.dubious_article());
            Assert.IsNotNull(res);
        }

        [Test]
        public async Task EventInsert()
        {
            var res = await _eventRepository.Insert(new Backend.Dbo.Model.Event());
            Assert.IsNotNull(res);
        }

        [Test]
        public async Task EventTypeInsert()
        {
            var res = await _eventTypeRepository.Insert(new Backend.Dbo.Model.event_type());
            Assert.IsNotNull(res);
        }

        [Test]
        public void ArticleGetAll()
        {
            var res = _articleRepository.Get().Result.ToList();
            Assert.NotNull(res);
            Assert.AreEqual(2, res.Count);
        }

        [Test]
        public void ArticleGetFirst()
        {
            var res = _articleRepository.Get(1).Result.FirstOrDefault();
            Assert.NotNull(res);
            Assert.AreEqual(1, res.id);
            Assert.AreEqual("Article1", res.title);
            Assert.AreEqual("DescArticle1", res.description);
            Assert.AreEqual("FullArticle1", res.full_article);
            Assert.AreEqual(1, res.SourceId);
        }

        [Test]
        public void ArticleGetWrong()
        {
            var res = _articleRepository.Get(10).Result.FirstOrDefault();
            Assert.IsNull(res);
        }


        [Test]
        public void ScenariosGetAll()
        {
            var res = _scenarioRepository.Get().Result.ToList();
            Assert.NotNull(res);
            Assert.AreEqual(2, res.Count);
        }

        [Test]
        public void ScenariosGetFirst()
        {
            var res = _scenarioRepository.Get(1).Result.FirstOrDefault();
            Assert.NotNull(res);
            Assert.AreEqual(1, res.id);
            Assert.AreEqual("virus1", res.Virus);
            Assert.AreEqual(1, res.TownId);
            Assert.AreEqual("Date1", res.BeginDate);
            Assert.AreEqual("description1", res.Description);
        }

        [Test]
        public void ScenariosGetWrong()
        {
            var res = _scenarioRepository.Get(10).Result.FirstOrDefault();
            Assert.IsNull(res);
        }


        [Test]
        public void EventTypeGetAll()
        {
            var res = _eventTypeRepository.Get().Result.ToList();
            Assert.NotNull(res);
            Assert.AreEqual(2, res.Count);
        }

        [Test]
        public void EventTypeGetFirst()
        {
            var res = _eventTypeRepository.Get(1).Result.FirstOrDefault();
            Assert.NotNull(res);
            Assert.AreEqual(1, res.id);
            Assert.AreEqual("EventType1", res.name);
        }

        [Test]
        public void EventTypeGetWrong()
        {
            var res = _eventTypeRepository.Get(10).Result.FirstOrDefault();
            Assert.IsNull(res);
        }



        [Test]
        public void EventGetAll()
        {
            var res = _eventRepository.Get().Result.ToList();
            Assert.NotNull(res);
            Assert.AreEqual(2, res.Count);
        }

        [Test]
        public void EventGetFirst()
        {
            var res = _eventRepository.Get(1).Result.FirstOrDefault();
            Assert.NotNull(res);
            Assert.AreEqual(1, res.id);
            Assert.AreEqual(0, res.TypeId);
            Assert.AreEqual(0, res.ArticleId);
        }

        [Test]
        public void EventGetWrong()
        {
            var res = _eventRepository.Get(10).Result.FirstOrDefault();
            Assert.IsNull(res);
        }


        [Test]
        public void DubiousGetAll()
        {
            var res = _dubiousArticleRepository.Get().Result.ToList();
            Assert.NotNull(res);
            Assert.AreEqual(2, res.Count);
        }

        [Test]
        public void DubiousGetFirst()
        {
            var res = _dubiousArticleRepository.Get(1).Result.FirstOrDefault();
            Assert.NotNull(res);
            Assert.AreEqual(1, res.id);
            Assert.AreEqual("dubious1", res.title);
            Assert.AreEqual(0, res.sourceId);
            Assert.AreEqual("source1", res.fullArticleSource);
            Assert.AreEqual(0, res.otherSourceId);
            Assert.AreEqual("other1", res.fullArticleOther);
            Assert.AreEqual(false, res.seenTwice);
        }

        [Test]
        public void DubiousGetWrong()
        {
            var res = _dubiousArticleRepository.Get(10).Result.FirstOrDefault();
            Assert.IsNull(res);
        }

        [Test]
        public void DubiousInsert()
        {
            Backend.Dbo.Model.dubious_article dubious_Article = new Backend.Dbo.Model.dubious_article
            {
                title = "testInsertion",
                sourceId = 1,
                fullArticleSource = "fullArticleSource",
                otherSourceId = 2,
                fullArticleOther = "fullArticleOther",
                seenTwice = false
            };

            var res = _dubiousArticleRepository.Insert(dubious_Article);

            var test = _dubiousArticleRepository.Get().Result.ToList();
            var entity = test.Where(x => x.title == "testInsertion").FirstOrDefault();

            Assert.NotNull(entity);

            Assert.AreEqual("testInsertion", entity.title);
            Assert.AreEqual(1, entity.sourceId);
            Assert.AreEqual("fullArticleSource", entity.fullArticleSource);
            Assert.AreEqual(2, entity.otherSourceId);
            Assert.AreEqual("fullArticleOther", entity.fullArticleOther);
            Assert.AreEqual(false, entity.seenTwice);
        }

        [Test]
        public void DubiousDeleteAll()
        {
            bool res = _dubiousArticleRepository.DeleteAll().Result;
            Assert.IsTrue(res);
        }



        [Test]
        public void ArticleSourceGetAll()
        {
            var res = _articleSourceRepository.Get().Result.ToList();
            Assert.NotNull(res);
            Assert.AreEqual(2, res.Count);
        }

        [Test]
        public void ArticleSourceGetFirst()
        {
            var res = _articleSourceRepository.Get(1).Result.FirstOrDefault();
            Assert.NotNull(res);
            Assert.AreEqual(1, res.id);
            Assert.AreEqual("source1", res.name);
        }

        [Test]
        public void ArticleSourceGetWrong()
        {
            var res = _articleSourceRepository.Get(10).Result.FirstOrDefault();
            Assert.IsNull(res);
        }
    }
}
