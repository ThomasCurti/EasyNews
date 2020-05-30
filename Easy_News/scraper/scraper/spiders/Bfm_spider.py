import scrapy
from ..items import Article
from scrapy.loader import ItemLoader


def parse_article(response):
    def extract_with_css(query):
        return response.css(query).get(default='').strip()

    article = ItemLoader(item=Article())
    article.add_value('title', extract_with_css('h1.titre-article::text'))
    article.add_value('description', extract_with_css('h2.title-large::text'))
    article.add_value('full_article', extract_with_css('div.article-body-main'))
    article.add_value('source', response.url)
    return article.load_item()


class BfmSpider(scrapy.Spider):
    name = "Bfm"
    start_urls = [
        'https://www.bfmtv.com/sante/actualites/?page=1',
    ]

    def parse(self, response):
        for news in response.css('li.timeline-bloc.timeline-inverted'):
            article = news.css('article a::attr(href)').get()
            if article is not None:
                yield response.follow(article, parse_article)

        for pagination_links in response.css('ul.pagination'):
            nextPage = pagination_links.css('li a::attr(href)').get()
            if nextPage is not None:
                yield response.follow(nextPage, callback=self.parse)
