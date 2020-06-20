import scrapy
from scrapy.loader import ItemLoader
from scraper.items import Article


def parse_article(response):
    def extract_with_css(query):
        return response.css(query).get(default='').strip()

    def extract_all_with_css(query):
        return response.css(query).getall()

    article = ItemLoader(item=Article())
    article.add_value('title', extract_with_css('h1.entry-title'))
    article.add_value('description', '')
    full_article = extract_all_with_css("section.cb-entry-content p")
    for paragraph in full_article:
        article.add_value('full_article', paragraph)
    article.add_value('source', response.url)
    return article.load_item()


class TrustMyScienceSpider(scrapy.Spider):
    name = "TrustMyScience"
    start_urls = [
        'https://trustmyscience.com/categories/actus-science/',
    ]

    def parse(self, response):
        for news in response.css('div.cb-mask'):
            article = news.css('a::attr(href)').get()
            if article is not None:
                yield response.follow(article, parse_article)

        for pagination_links in response.css('nav#cb-blog-infinite-load'):
            nextPage = pagination_links.css('a::attr(href)').get()
            if nextPage is not None:
                yield response.follow(nextPage, callback=self.parse)
