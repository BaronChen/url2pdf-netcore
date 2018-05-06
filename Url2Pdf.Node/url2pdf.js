const puppeteer = require('puppeteer');

const convert = async (url) => {
    const browser = await puppeteer.launch({ args: ['--no-sandbox', '--disable-dev-shm-usage', '--disable-setuid-sandbox'] });

    try {
        const page = await browser.newPage();
        await page.goto(url, { waitUntil: 'networkidle2', timeout: 120000 });
        await page.emulateMedia('screen');
        let buffer = await page.pdf({ format: 'A4', printBackground: true });
        await browser.close();
        return buffer;
    } catch (err) {
        await browser.close();
        throw err;
    }
}


module.exports = (callback, url) => {
    convert(url).then((buffer) => {
        callback(null, buffer.toString('base64'));
    }).catch((e) => {
        callback(e, null);
    });
}