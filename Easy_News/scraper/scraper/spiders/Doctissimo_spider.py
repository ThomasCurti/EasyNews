import scrapy
from ..items import Article


def parse_article(response):
    def extract_with_css(query):
        return response.css(query).get(default='').strip()

    title = extract_with_css('div.row.doc-title h1::text')
    description = ''
    full_article = extract_with_css("div.row.doc-content")
    source = response.url
    article = Article(title=title, description=description, full_article=full_article, source=source)
    yield {
        'Article': article,
    }


class DoctissimoSpider(scrapy.Spider):
    name = "Doctissimo"
    start_urls = [
        'https://www.doctissimo.fr/news',
    ]

    def parse(self, response):
        for news in response.css('div.doc-block-news'):
            article = news.css('a::attr(href)').get()
            if article is not None:
                yield response.follow(article, parse_article)

        for pagination_links in response.css('ul.pagination li.col-xs-2'):
            nextPage = pagination_links.css('a::attr(href)').get()
            if nextPage is not None:
                yield response.follow(nextPage, callback=self.parse)
