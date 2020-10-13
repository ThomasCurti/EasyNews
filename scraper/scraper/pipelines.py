# -*- coding: utf-8 -*-

# Define your item pipelines here
#
# Don't forget to add your pipeline to the ITEM_PIPELINES setting
# See: https://docs.scrapy.org/en/latest/topics/item-pipeline.html
import json
from scrapy.utils.serialize import ScrapyJSONEncoder
# import requests

api_host = 'https://localhost:44346/'
api_dubiousArticle = 'api/DubiousArticle'


class ScraperPipeline(object):
    def process_item(self, item, spider):
        return item


class JsonWriterPipeline(object):

    def open_spider(self, spider):
        self.file = open('items', 'w')

    def close_spider(self, spider):
        self.file.close()

    def process_item(self, item, spider):
        line = json.dumps(dict(item), cls=ScrapyJSONEncoder) + "\n"
        self.file.write(line)
        # call to Backend API, api/DubiousArticle
        # requests.post(url=(api_host + api_dubiousArticle), data=line)
        return item
