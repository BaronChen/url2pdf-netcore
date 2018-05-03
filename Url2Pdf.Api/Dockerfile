FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

RUN apt-get update && apt-get install -yq libgconf-2-4 && apt-get install -yq gnupg2
# Install latest chrome dev package and fonts to support major charsets (Chinese, Japanese, Arabic, Hebrew, Thai and a few others)
# Note: this installs the necessary libs to make the bundled version of Chromium that Puppeteer
# installs, work.
RUN apt-get update && apt-get install -y wget --no-install-recommends \
    && wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - \
    && sh -c 'echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list' \
    && apt-get update \
    && apt-get install -y google-chrome-unstable fonts-ipafont-gothic fonts-wqy-zenhei fonts-thai-tlwg fonts-kacst ttf-freefont \
      --no-install-recommends \
    && rm -rf /var/lib/apt/lists/* \
    && apt-get purge --auto-remove -y curl \
    && rm -rf /src/*.deb

ENV NODE_VERSION 8.11.1
ENV NODE_DOWNLOAD_URL https://nodejs.org/dist/v$NODE_VERSION/node-v$NODE_VERSION-linux-x64.tar.gz
ENV NODE_DOWNLOAD_SHA 610705D45EB2846A9E10690678A078D9159E5F941487ACA20C6F53B33104358C

RUN wget -q -O nodejs.tar.gz "$NODE_DOWNLOAD_URL" \
    && echo "$NODE_DOWNLOAD_SHA nodejs.tar.gz" \
    && tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \
    && rm nodejs.tar.gz \
    && ln -s /usr/local/bin/node /usr/local/bin/nodejs
RUN PATH=/usr/local/bin/node:$PATH

WORKDIR /node-app
COPY ["Url2Pdf.Core/package.json", "Url2Pdf.Core/package-lock.json", "/node-app/"]
RUN npm install
COPY Url2Pdf.Core/url2pdf.js ./

FROM microsoft/aspnetcore-build:2.0 AS build

WORKDIR /src
COPY Url2Pdf.sln ./
COPY Url2Pdf.Api/Url2Pdf.Api.csproj Url2Pdf.Api/
RUN dotnet restore -nowarn:msb3202,nu1503

COPY . .
WORKDIR /src/Url2Pdf.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Url2Pdf.Api.dll"]
