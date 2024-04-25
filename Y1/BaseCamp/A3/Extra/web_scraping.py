import requests
from bs4 import BeautifulSoup

URL = "https://www.funda.nl/koop/barendrecht/huis-42326179-kuiperij-2/"
HEADERS = {'User-Agent': "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) "
                         "Chrome/42.0.2311.135 Safari/537.36 Edge/12.246"}

page = requests.get(URL, headers=HEADERS)
soup = BeautifulSoup(page.content, "html5lib")

features_body = soup.find("div", attrs={"class": "object-kenmerken-body"})

feature_titles = features_body.findAll("h3", attrs={"class": "object-kenmerken-list-header"})
feature_list = features_body.findAll("dl", attrs={"class": "object-kenmerken-list"})

for i in range(len(feature_list)):
    print("=====================")
    print(feature_titles[i].text)
    for dt in feature_list[i].findAll("dt"):
        print(dt.prettify())
    for dd in feature_list[i].findAll("dd"):
        print(dd.prettify())
    # print(feature_list[i].prettify())
