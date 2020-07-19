# -*- coding: UTF-8 -*-
from bs4 import BeautifulSoup
import requests
import sys
import pymysql
import re

#--------保存爬取的文章 -----------
save_data()

def save_data():
    dict = read_article_info()
    for key,value in dict.items():
        get_content(key,value)

#--------set page amount----------

def set_download_urls():
    downloadUrls = []
    baseUrl = 'http://www.agri.cn/kj/syjs/zzjs/'
    downloadUrls.append('http://www.agri.cn/kj/syjs/zzjs/index.htm')
    for i in range(1,10):
        url = baseUrl + 'index_' + str(i) + '.htm'
        downloadUrls.append(url)
    return downloadUrls


#--------get download page urls

def get_download_tables():
    downloadUrls = set_download_urls()
    tables = []
    for url in downloadUrls:
        req = requests.get(url)

        req.encoding = 'utf-8'
        html = req.text
        table_bf = BeautifulSoup(html)
        tables.append(table_bf.find('table',width=500,align='center'))

    return tables

#---------get article links------------
def get_download_url():
    downloadTables = get_download_tables()
    articles = []
    for each in downloadTables:
        articles.append(each.find_all('a',class_='link03'))
    return articles

def read_article_info():
    articles = get_download_url()
    baseUrl = 'http://www.agri.cn/kj/syjs/zzjs'
    dict = {}

    for each in articles:
        for item in each:
            dict[item.string] = baseUrl + item.get('href')[1:]
    return dict


#---------method of save to MySQL-----------

def save_mysql(title,date,source,content,tech_code,info_code):
    db = pymysql.connect('localhost','root','123456asd...','wechat_pulic_flatfrom')

    cursor = db.cursor()

    sql = 'INSERT INTO information_stock (title,date,source,content,tech_code,info_code) VALUES ("%s","%s","%s","%s",%s,%s)' % (title,date,source,content,tech_code,info_code)

    try:
        cursor.execute(sql)
        db.commit()
        print("write success")
    except Exception as e:
        db.rollback()
        print("write fail")
        print(e)

    db.close()


#---------get content info and save ---------------

def get_content(title,url):
    print(title + '---->' + url)

    req = requests.get(url)
    req.encoding = 'utf-8'
    html = req.text
    table_bf = BeautifulSoup(html)
    article = table_bf.find('table',width=640)

    #----article content-----
    #content = article.find(class_='TRS_Editor').get_text()
    #content = article.find('div',attrs={'id':re.compile("TRS_")}).select("p")
    content = article.select("p")
    info = article.find(class_='hui_12-12').get_text()
    date = info[3:19]
    source = info.split("：")[3]
    text = ""

    for item in content:
        text += item.get_text()
        text += "\n"

    #print(text)
    save_mysql(title,date,source,text,0,0)


