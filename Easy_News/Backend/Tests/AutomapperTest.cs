using AutoMapper;
using Backend.DataAccess;
using NUnit.Framework;

namespace Tests
{
    public class AutomapperTest
    {
        private IMapper _mapper;

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
            _mapper = MappingData();
        }

        [Test]
        public void ArticleMapper()
        {
            Backend.DataAccess.EFModels.Article efArticle =
            new Backend.DataAccess.EFModels.Article
            {
                Id = 0,
                Title = "test",
                Description = "test description",
                FullArticle = "full article test",
            };

            var val = _mapper.Map<Backend.Dbo.Model.article>(efArticle);

            Assert.IsNotNull(val as Backend.Dbo.Model.article);
            Assert.AreEqual(efArticle.Id, val.id);
            Assert.AreEqual(efArticle.Title, val.title);
            Assert.AreEqual(efArticle.Description, val.description);
            Assert.AreEqual(efArticle.FullArticle, val.full_article);
        }

        [Test]
        public void ArticleSourceMapper()
        {
            Backend.DataAccess.EFModels.ArticleSource efArticleSource =
            new Backend.DataAccess.EFModels.ArticleSource
            {
                Id = 0,
                Name = "test",
            };

            var val = _mapper.Map<Backend.Dbo.Model.article_source>(efArticleSource);

            Assert.IsNotNull(val as Backend.Dbo.Model.article_source);
            Assert.AreEqual(efArticleSource.Id, val.id);
            Assert.AreEqual(efArticleSource.Name, val.name);
        }

        [Test]
        public void DubiousArticleMapper()
        {
            Backend.DataAccess.EFModels.DubiousArticle efDubiousArticle =
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

            var val = _mapper.Map<Backend.Dbo.Model.dubious_article>(efDubiousArticle);

            Assert.IsNotNull(val as Backend.Dbo.Model.dubious_article);
            Assert.AreEqual(efDubiousArticle.Id, val.id);
            Assert.AreEqual(efDubiousArticle.Title, val.title);
            Assert.AreEqual(efDubiousArticle.FullArticleSource, val.full_article_source);
            Assert.AreEqual(efDubiousArticle.FullArticleOther, val.full_article_other);
            Assert.AreEqual(efDubiousArticle.SeenTwice, val.seen_twice);
            
        }

        [Test]
        public void EventMapper()
        {
            Backend.DataAccess.EFModels.Event efEvent =
            new Backend.DataAccess.EFModels.Event
            {
                Id = 0,
                TypeId = 1,
                ArticleId = 2,
                Published = new System.DateTime(),
            };

            var val = _mapper.Map<Backend.Dbo.Model.Event>(efEvent);

            Assert.IsNotNull(val as Backend.Dbo.Model.Event);
            Assert.AreEqual(efEvent.Id, val.id);
            Assert.AreEqual(efEvent.Published, val.published);
        }

        [Test]
        public void EventTypeMapper()
        {
            Backend.DataAccess.EFModels.EventType efEventType =
            new Backend.DataAccess.EFModels.EventType
            {
                Id = 0,
                Name = "test",
            };

            var val = _mapper.Map<Backend.Dbo.Model.event_type>(efEventType);

            Assert.IsNotNull(val as Backend.Dbo.Model.event_type);
            Assert.AreEqual(efEventType.Id, val.id);
            Assert.AreEqual(efEventType.Name, val.name);
        }


    }
}
