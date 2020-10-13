# -*- coding: utf-8 -*-

# Define here the models for your scraped items
#
# See documentation in:
# https://docs.scrapy.org/en/latest/topics/items.html

import scrapy
from scrapy.loader.processors import Join, MapCompose
from w3lib.html import remove_tags


class Quotes(scrapy.Item):
    Text = scrapy.Field()
    Author = scrapy.Field()


class Article(scrapy.Item):
    title = scrapy.Field(
        input_processor=MapCompose(remove_tags),
        output_processor=Join(),
    )
    description = scrapy.Field(
        input_processor=MapCompose(remove_tags),
        output_processor=Join(),
    )
    full_article = scrapy.Field(
        input_processor=MapCompose(remove_tags),
        output_processor=Join(),
    )
    source = scrapy.Field()
