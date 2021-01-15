using PuppeteerSharp;
using System.Configuration;
using System.Threading.Tasks;

namespace WebCrawler.ConsoleApp.Services
{
    public static class CrawlerService
    {
        private static Browser browser;

        public static async Task<Page> OpenAsync(string url)
        {
            Page page = await NewPageAsync();
            await page.GoToAsync(url);

            return page;
        }

        public static async Task CloseAsync()
        {
            await browser.CloseAsync();
        }

        private static async Task<Page> NewPageAsync()
        {
            var executeInHeadless = bool.Parse(ConfigurationManager.AppSettings.Get("ChromiumHeadless"));
            
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            string[] args = { "--no-sandbox", "--disable-setuid-sandbox" };
            browser = await Puppeteer.LaunchAsync(
                new LaunchOptions
                {
                    Headless = executeInHeadless,
                    Args = args
                });

            return await browser.NewPageAsync();
        }
    }
}
