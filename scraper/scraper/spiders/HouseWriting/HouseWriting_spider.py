import scrapy
from scrapy.loader import ItemLoader
from scraper.items import Article


def parse_article(response):
    def extract_with_css(query):
        return response.css(query).get(default='').strip()

    def extract_all_with_css(query):
        return response.css(query).getall()

    article = ItemLoader(item=Article())
    article.add_value('title', extract_with_css('h1.post-title.entry-title'))
    description = extract_all_with_css('div#Chapo p')
    for p in description:
        article.add_value('description', p)
    full_article = extract_all_with_css("div#bsf_rt_marker p")
    for paragraph in full_article:
        article.add_value('full_article', paragraph)
    article.add_value('source', response.url)
    return article.load_item()


class HouseWritingSpider(scrapy.Spider):
    name = "HouseWriting"
    start_urls = [
        'https://actualite.housseniawriting.com/',
    ]

    def parse(self, response):
        for news in response.css('div.post-thumbnail'):
            article = news.css('a::attr(href)').get()
            if article is not None:
                yield response.follow(article, parse_article)

        for pagination_links in response.css('ul.group li.next.right'):
            nextPage = pagination_links.css('a::attr(href)').get()
            if nextPage is not None:
                yield response.follow(nextPage, callback=self.parse)
