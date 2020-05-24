import scrapy
from ..items import Article


def parse_article(response):
    def extract_with_css(query):
        return response.css(query).get(default='').strip()

    title = extract_with_css('h1.article__title::text')
    description = extract_with_css('p.article__desc::text')
    full_article = extract_with_css("article.article__content.old__article-content-single")
    source = response.url
    article = Article(title=title, description=description, full_article=full_article, source=source)
    yield {
        'Article': article,
    }


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
