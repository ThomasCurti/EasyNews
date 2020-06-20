import scrapy
from scrapy.loader import ItemLoader
from scraper.items import Article


def parse_article(response):
    def extract_with_css(query):
        return response.css(query).get(default='').strip()

    def extract_all_with_css(query):
        return response.css(query).getall()

    article = ItemLoader(item=Article())
    article.add_value('title', extract_with_css('h1::text'))
    article.add_value('description', extract_with_css('p.chapo::text'))
    full_article = extract_all_with_css("div#col-middle p")
    for paragraph in full_article:
        article.add_value('full_article', paragraph)
    article.add_value('source', response.url)
    return article.load_item()


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
