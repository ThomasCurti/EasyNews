import scrapy
from scrapy.loader import ItemLoader
from scraper.items import Article


def parse_article(response):
    def extract_with_css(query):
        return response.css(query).get(default='').strip()

    article = ItemLoader(item=Article())
    article.add_value('title', extract_with_css('div.row.doc-title h1::text'))
    article.add_value('description', '')
    article.add_value('full_article', extract_with_css('div.row.doc-content'))
    article.add_value('source', response.url)
    return article.load_item()


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
