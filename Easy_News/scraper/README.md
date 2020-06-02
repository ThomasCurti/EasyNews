# Scraper

## Requirement

```
docker pull prom/pushgateway  
pip install discord  
pip install scrapy-prometheus  
```

Download [Prometheus](https://github.com/prometheus/prometheus)

## To Launch

Launch prometheus in a terminal :  

```
prometheus
```  

Open a new terminal and launch docker image of prom/pushgateway:  

```
docker run --name=pushgateway -d -p 9091:9091 prom/pushgateway
```

Or if the container already exist: 

```
docker start pushgateway
```

Now you can launch Scrapy in terminal:

```
scrapy
```