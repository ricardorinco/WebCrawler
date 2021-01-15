using PuppeteerSharp;
using System.Threading.Tasks;
using WebCrawler.ConsoleApp.Crawlers.LeroLero.Struct;
using WebCrawler.ConsoleApp.Services;

namespace WebCrawler.ConsoleApp.Crawlers.LeroLero
{
    public static class LeroLeroCrawler
    {
        private static Page page;

        public static async Task<string> GetSentenceAsync(SentenceModo? sentenceModo)
        {
            try
            {
                // Inicializa a criação de uma página
                page = await CrawlerService.OpenAsync("https://lerolero.com/");

                // Caso informado, realiza a seleção de um novo modo de sentença
                if (sentenceModo.HasValue)
                    await SelectSentenceModo(sentenceModo.Value);

                // Obtêm o valor da setence
                string setence = await ReadSentenceAsync();

                // Solicita o encerramento da execução da instância do navegador
                await CrawlerService.CloseAsync();

                return setence;
            }
            catch (System.Exception)
            {
                return SentenceServices.GetSentenceByJson();
            }
        }

        private static async Task<string> ReadSentenceAsync()
        {
            // Realiza a busca da sentença
            string sentence = await page.QuerySelectorAsync(".sentence").EvaluateFunctionAsync<string>("_ => _.innerText");

            return sentence;
        }

        private static async Task SelectSentenceModo(SentenceModo sentenceModo)
        {
            // Realiza a seleção dos modo para realização do click no botão
            var modoButtons = await page.QuerySelectorAllAsync("span");
            
            // Click no botão selecionado
            await modoButtons[(int)sentenceModo].ClickAsync();
            // Aguarda 600 milissegundos para atualização da nova sentença
            await page.WaitForTimeoutAsync(600);
        }
    }
}
