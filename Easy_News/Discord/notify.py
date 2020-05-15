import sys
import requests
import discord
from discord import Webhook, RequestsWebhookAdapter

WEBHOOK_ID_SCRAPER = 710807485866442833
WEBHOOK_TOKEN_SCRAPER = "JGTChjh7Zzojlym1nEtfhkdj8JJV1E3NmfceCN5Y84wGG74iPwhS49RlcDEIEWITZ7kU"

WEBHOOK_ID_CI = 710822625709916190
WEBHOOK_TOKEN_CI = "Qf5D00tuH5RmjUBH78OJYu_9X22YGYYPdzLY57Bw48N9BchuPhleleGFNq1jbqsxkCeg"

def send_scraper_channel(text):
    webhook_scraper = Webhook.partial(WEBHOOK_ID_SCRAPER, WEBHOOK_TOKEN_SCRAPER, adapter=RequestsWebhookAdapter())
    lines = text.split('\\n')
    for line in lines:
        webhook_scraper.send(line)

def send_ci_channel(text):
    webhook_ci = Webhook.partial(WEBHOOK_ID_CI, WEBHOOK_TOKEN_CI, adapter=RequestsWebhookAdapter())
    lines = text.split('\\n')
    for line in lines:
        webhook_ci.send(lines)

if len(sys.argv) != 3:
    print ("Usage: python3 notify.py CHANNEL TEXT")
    print ("    CHANNEL = 'ci' | 'scraper'")

if sys.argv[1] == 'ci':
    send_ci_channel(sys.argv[2])
elif sys.argv[1] == 'scraper':
    send_scraper_channel(sys.argv[2])
else:
    print ("Wrong channel name. Must be 'ci' or 'scraper'")
