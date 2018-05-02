# Smaple project with .Net Core and Puppeteer

This is a sample project that use .net core NodetServices to utilise Puppeteer nodejs API.

The sample functionality will take an url as input and output the PDF of the pages.

Usage:
```sh
docker-compose -f docker-compose.yml up
```

Example requesy:
```sh
http://localhost:4200/api/url-2-pdf/convert?url=https%3A%2F%2Fwww.google.com
```

Or you can use visual studio 2017 to start the project direcly.