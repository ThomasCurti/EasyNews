import scrapy
from ..items import Article


def parse_article(response):
    def extract_with_css(query):
        return response.css(query).get(default='').strip()

    def extract_all_with_css(query):
        return response.css(query).getall()

    title = extract_with_css('h1.alpha.color-white.text-shadow::text')
    description = extract_with_css('div.chapo p::text')
    full_article = extract_all_with_css("p.py0p5::text")
    source = response.url
    article = Article(title=title, description=description, full_article=full_article, source=source)
    yield {
        'Article': article,
    }


class FuturaScienceSpider(scrapy.Spider):
    name = "FuturaSciences"
    start_urls = [
        'https://www.futura-sciences.com/sante/actualites/',
    ]

    def parse(self, response):
        for articles in response.xpath('//a[has-class("link-wrapper")]'):
            if articles is not None:
                yield response.follow(articles, callback=parse_article)

        for pagination_links in response.css('ul.glossary-pager li'):
            nextPage = pagination_links.css('a::attr(href)').get()
            if nextPage is not None:
                yield response.follow(nextPage, callback=self.parse)

        for pagination_links_hidden in response.css('ul.hidden-xs.glossary-pager-controller li'):
            nextPage = pagination_links_hidden.css('a::attr(href)').get()
            if nextPage is not None:
                yield response.follow(nextPage, callback=self.parse)
