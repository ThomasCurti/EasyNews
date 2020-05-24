from bs4 import BeautifulSoup


def cleanhtml(raw_html):
    cleantext = BeautifulSoup(raw_html, "lxml").text
    return cleantext
