import scrapy
from scrapy.loader import ItemLoader
from ..items import Article


def parse_article(response):
    def extract_with_css(query):
        return response.css(query).get(default='').strip()

    def extract_all_with_css(query):
        return response.css(query).getall()

    article = ItemLoader(item=Article())
    article.add_value('title', extract_with_css('header.header-article h1'))
    article.add_value('description', extract_with_css('strong.chapo'))
    full_article = extract_all_with_css("section.content p")
    for paragraph in full_article:
        article.add_value('full_article', paragraph)
    article.add_value('source', response.url)
    return article.load_item()


class Europe1Spider(scrapy.Spider):
    name = "Europe1"
    start_urls = [
        'https://www.europe1.fr/politique',
        'https://www.europe1.fr/societe',
        'https://www.europe1.fr/economie',
        'https://www.europe1.fr/international',
        'https://www.europe1.fr/medias-tele',
        'https://www.europe1.fr/culture',
        'https://www.europe1.fr/sport',
        'https://www.europe1.fr/faits-divers',
    ]

    def parse(self, response):
        for articles in response.xpath('//a[has-class("titre")]'):
            if articles is not None:
                yield response.follow(articles, callback=parse_article)

        for pagination_links in response.css('nav.pagination li'):
            nextPage = pagination_links.css('a::attr(href)').get()
            if nextPage is not None:
                yield response.follow(nextPage, callback=self.parse)