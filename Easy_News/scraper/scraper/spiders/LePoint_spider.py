import scrapy
from scrapy.loader import ItemLoader
from ..items import Article


def parse_article(response):
    def extract_with_css(query):
        return response.css(query).get(default='').strip()

    article = ItemLoader(item=Article())
    article.add_value('title', extract_with_css('h1.art-titre::text'))
    article.add_value('description', extract_with_css('h2.art-chapeau::text'))
    article.add_value('full_article', extract_with_css('div.art-text'))
    article.add_value('source', response.url)
    return article.load_item()


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
