import pprint

from scrapy import statscollectors
from ..Discord import notify


class DiscordStatsCollector(statscollectors.StatsCollector):
    def __init__(self, crawler):
        super(DiscordStatsCollector, self).__init__(crawler)

    def _persist_stats(self, stats, spider):
        super(DiscordStatsCollector, self)._persist_stats(stats, spider)
        if spider:
            notify.send_scraper_channel('Retrieved stats from ' + spider.name + ' spider :\n' + pprint.pformat(stats) + '\n')
