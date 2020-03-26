using AutoMapper;
using Backend.DataAccess;
using Backend.DataAccess.EFModels;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    public class RepositoriesTest
    {
        private Mock<earlynews_testContext> _context;
        private IMapper _mapper;

        private ArticleRepository _articleRepository;
        private ArticleSourceRepository _articleSourceRepository;
        private DubiousArticleRepository _dubiousArticleRepository;
        private EventRepository _eventRepository;
        private EventTypeRepository _eventTypeRepository;

        private Backend.DataAccess.EFModels.Article _efArticle = new Backend.DataAccess.EFModels.Article
            {
                Id = 0,
                Title = "test",
                Description = "test description",
                FullArticle = "full article test",
            };
        private Backend.DataAccess.EFModels.ArticleSource _efArticleSource =
            new Backend.DataAccess.EFModels.ArticleSource
            {
                Id = 0,
                Name = "test",
            };
        Backend.DataAccess.EFModels.DubiousArticle _efDubiousArticle =
            new Backend.DataAccess.EFModels.DubiousArticle
            {
                Id = 0,
                Title = "test",
                SourceId = 1,
                FullArticleSource = "example.com",
                OtherSourceId = 2,
                FullArticleOther = "blabla",
                SeenTwice = false,
            };
        Backend.DataAccess.EFModels.Event _efEvent =
            new Backend.DataAccess.EFModels.Event
            {
                Id = 0,
                TypeId = 1,
                ArticleId = 2,
                Published = new System.DateTime(),
            };
        Backend.DataAccess.EFModels.EventType _efEventType =
            new Backend.DataAccess.EFModels.EventType
            {
                Id = 0,
                Name = "test",
            };


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
            _context = new Mock<earlynews_testContext>();
            _context.Setup(c => c.SaveChanges()).Verifiable();
            _context.Setup(c => c.SaveChangesAsync(CancellationToken.None)).Verifiable();
            _context.Setup(x => x.Set<Article>())
                        .Returns(new FakeDbSet<Article>
                        {
                            _efArticle
                        });
            _context.Setup(x => x.Set<ArticleSource>())
                        .Returns(new FakeDbSet<ArticleSource>
                        {
                            _efArticleSource
                        });
            _context.Setup(x => x.Set<DubiousArticle>())
                        .Returns(new FakeDbSet<DubiousArticle>
                        {
                            _efDubiousArticle
                        });
            _context.Setup(x => x.Set<Event>())
                        .Returns(new FakeDbSet<Event>
                        {
                            _efEvent
                        });
            _context.Setup(x => x.Set<EventType>())
                        .Returns(new FakeDbSet<EventType>
                        {
                            _efEventType
                        });

            _mapper = MappingData();

            _context.Object.Article = new FakeDbSet<Article>();
            _context.Object.ArticleSource = new FakeDbSet<ArticleSource>();
            _context.Object.DubiousArticle = new FakeDbSet<DubiousArticle>();
            _context.Object.Event = new FakeDbSet<Event>();
            _context.Object.EventType = new FakeDbSet<EventType>();

            var logger = new LogRepository(_context.Object, _mapper);

            _articleRepository = new ArticleRepository(_context.Object, _mapper, logger);
            _articleRepository.Log = false;

            _articleSourceRepository = new ArticleSourceRepository(_context.Object, _mapper, logger);
            _articleSourceRepository.Log = false;

            _dubiousArticleRepository = new DubiousArticleRepository(_context.Object, _mapper, logger);
            _dubiousArticleRepository.Log = false;

            _eventRepository = new EventRepository(_context.Object, _mapper, logger);
            _eventRepository.Log = false;
            
            _eventTypeRepository = new EventTypeRepository(_context.Object, _mapper, logger);
            _eventTypeRepository.Log = false;
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

    }
}
