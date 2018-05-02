const puppeteer = require('puppeteer');

const convert = async (url) => {
    const browser = await puppeteer.launch({ args: ['--no-sandbox', '--disable-dev-shm-usage', '--disable-setuid-sandbox'] });
    const page = await browser.newPage();
    await page.goto(url, { waitUntil: 'networkidle2' });
    await page.emulateMedia('screen');
    let buffer = await page.pdf({ format: 'A4', printBackground: true });
    await browser.close();
    return buffer;
}


module.exports = (callback, url) => {
    convert(url).then((buffer) => {
        callback(null, buffer.toString('base64'));
    }).catch((e) => {
        callback(e, null);
    })
}