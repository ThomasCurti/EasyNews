import scrapy


def parse_article(response):
    article = response.css("div#contentcol").get(default='').strip()
    return article


class AfpSpider(scrapy.Spider):
    name = "Afp"
    start_urls = [
        'https://www.afp.com/fr/search/site/sant%25C3%25A9',
    ]

    def parse(self, response):
        for news in response.css('h4.htitle.txtblue.txt24.mb1'):
            article = news.css('a::attr(href)').get()
            if article is not None:
                yield response.follow(article, parse_article)

        for pagination_links in response.css('li.pager-item.btn.txtwhite.bgblue'):
            nextPage = pagination_links.css('a::attr(href)').get()
            if nextPage is not None:
                yield response.follow(nextPage, callback=self.parse)
