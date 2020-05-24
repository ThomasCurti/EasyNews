import scrapy
from ..items import Article
from ..CleanHtml import cleanhtml


def parse_article(response):
    def extract_with_css(query):
        return response.css(query).get(default='').strip()

    def extract_all_with_css(query):
        return response.css(query).getall()

    title = extract_with_css('h1::text')
    description = extract_with_css('p.chapo::text')
    full_article = extract_all_with_css("div#col-middle p::text")
    source = response.url
    article = Article(title=cleanhtml(title),
                      description=cleanhtml(description),
                      full_article=cleanhtml(full_article),
                      source=source)
    yield {
        'Article': article,
    }


class FranceInfoSpider(scrapy.Spider):
    name = "FranceInfo"
    start_urls = [
        'https://www.francetvinfo.fr/sante/',
    ]

    def parse(self, response):
        for news in response.css('div.flowItem'):
            article = news.css('a::attr(href)').get()
            if article is not None:
                yield response.follow(article, parse_article)

        for pagination_links in response.xpath('//a[has-class("page next")]'):
            if pagination_links is not None:
                yield response.follow(pagination_links, callback=self.parse)
