# -*- coding: utf-8 -*-

# Define here the models for your scraped items
#
# See documentation in:
# https://docs.scrapy.org/en/latest/topics/items.html

import scrapy


class Quotes(scrapy.Item):
    Text = scrapy.Field()
    Author = scrapy.Field()


class Article(scrapy.Item):
    title = scrapy.Field()
    description = scrapy.Field()
    full_article = scrapy.Field()
    source = scrapy.Field()
