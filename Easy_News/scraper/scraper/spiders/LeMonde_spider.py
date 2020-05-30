import scrapy
from scrapy.loader import ItemLoader
from ..items import Article


def parse_article(response):
    def extract_with_css(query):
        return response.css(query).get(default='').strip()

    article = ItemLoader(item=Article())
    article.add_value('title', extract_with_css('h1.article__title::text'))
    article.add_value('description', extract_with_css('p.article__desc::text'))
    article.add_value('full_article', extract_with_css('article.article__content.old__article-content-single'))
    article.add_value('source', response.url)
    return article.load_item()


class LeMondeSpider(scrapy.Spider):
    name = "LeMonde"
    start_urls = [
        'https://www.lemonde.fr/archives-du-monde/',
    ]

    def parse(self, response):
        for articles in response.xpath('//a[has-class("teaser__link")]'):
            if articles is not None:
                yield response.follow(articles, callback=parse_article)

        for pagination_links in response.xpath('//a[has-class("page__button-sitemap button button--month")]'):
            if pagination_links is not None:
                yield response.follow(pagination_links, callback=self.parse)
