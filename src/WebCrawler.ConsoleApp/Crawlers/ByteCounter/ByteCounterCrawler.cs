using PuppeteerSharp;
using System.Threading.Tasks;
using WebCrawler.ConsoleApp.Services;

namespace WebCrawler.ConsoleApp.Crawlers.ByteCounter
{
    public static class ByteCounterCrawler
    {
        private static Page page;

        public static async Task<int> GetBytesAsync(string sentence)
        {
            try
            {
                // Inicializa a criação de uma página
                page = await CrawlerService.OpenAsync("https://mothereff.in/byte-counter/");

                // Realiza a escrita da sentença obtida no textarea
                await WriteSentenceAsync(sentence);

                int bytes = await GetBytesAsync();

                // Solicita o encerramento da execução da instância do navegador
                await CrawlerService.CloseAsync();

                return bytes;
            }
            catch
            {
                return ByteCounterService.GetByteCount(sentence);
            }
        }

        private static async Task WriteSentenceAsync(string sentence)
        {
            // Realiza a seleção do textarea
            await page.FocusAsync("textarea");

            // Obtêm o valor do textarea
            var value = await page.EvaluateExpressionAsync<string>("document.querySelector('textarea').value");

            // Define o cursor do textarea ao final do texto
            await page.Keyboard.DownAsync("End");

            // Realiza a limpeza do texto contido no textarea
            for (int i = 0; i <= value.Length; i++)
                await page.Keyboard.DownAsync("Backspace");

            // Insere a sentença informada no textarea
            await page.Keyboard.TypeAsync(sentence);
        }

        private static async Task<int> GetBytesAsync()
        {
            // Realiza a busca do objeto que contém o resultado em bytes da sentença enviada
            string bytesString = await page.EvaluateExpressionAsync<string>("document.getElementById('bytes').textContent");

            return int.Parse(bytesString.Replace("bytes", ""));
        }
    }
}
