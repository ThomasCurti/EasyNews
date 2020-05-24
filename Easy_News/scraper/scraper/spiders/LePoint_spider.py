import scrapy
from ..items import Article
from ..CleanHtml import cleanhtml


def parse_article(response):
    def extract_with_css(query):
        return response.css(query).get(default='').strip()

    title = extract_with_css('h1.art-titre::text')
    description = extract_with_css('h2.art-chapeau::text')
    full_article = extract_with_css("div.art-text")
    source = response.url
    article = Article(title=cleanhtml(title),
                      description=cleanhtml(description),
                      full_article=cleanhtml(full_article),
                      source=source)
    yield {
        'Article': article,
    }


class LePointSpider(scrapy.Spider):
    name = "LePoint"
    start_urls = [
        'https://www.lepoint.fr/24h-info/sante/',
    ]

    def parse(self, response):
        for articles in response.xpath('//a[has-class("row keep-cols")]'):
            if articles is not None:
                yield response.follow(articles, callback=parse_article)

        for pagination_links in response.css('ol.pagination.bottom li'):
            nextPage = pagination_links.css('a::attr(href)').get()
            if nextPage is not None:
                yield response.follow(nextPage, callback=self.parse)
