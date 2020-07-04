from scrapy.crawler import CrawlerProcess
from scrapy.commands import ScrapyCommand
from scrapy.utils.project import get_project_settings
from apscheduler.schedulers.twisted import TwistedScheduler


class ScheduleSpiderCommand(ScrapyCommand):
    requires_project = True
    excludes = []

    def syntax(self):
        return '[options]'

    def short_desc(self):
        return 'Run all spiders once a day'

    def run(self, args, opts):
        settings = get_project_settings()
        crawler_process = CrawlerProcess(settings)
        scheduler = TwistedScheduler()

        for spider_name in crawler_process.spider_loader.list():
            if spider_name in self.excludes:
                continue
            spider_cls = crawler_process.spider_loader.load(spider_name)
            scheduler.add_job(crawler_process.crawl, 'interval', args=[spider_cls], seconds=86400)
        scheduler.start()
        crawler_process.start(False)
