using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WebCrawler.ConsoleApp.Crawlers.ByteCounter;
using WebCrawler.ConsoleApp.Crawlers.LeroLero;
using WebCrawler.ConsoleApp.Models;
using WebCrawler.ConsoleApp.Services;
using WebCrawler.ConsoleApp.Services.Arguments;

namespace WebCrawler.ConsoleApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
#if (DEBUG)
            args = new List<string> { "-fsp", "D:\\CrawlerReports" }.ToArray();
#else
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a argument -fsp to select a path to save file to be processed. Example -fsp C:/MyFolder.");
                
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
#endif
            if (args.Length > 0)
            {
                var argumentData = ArgumentService.CheckCommands(args);

                Console.WriteLine("\n\nPlease wait, the necessary data is being obtained.\n");
                RunAsync(argumentData).GetAwaiter().GetResult();

                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }

        private static async Task RunAsync(ArgumentDataModel argumentData)
        {
            var fileDataResults = new List<FileDataModel>();

            var watch = Stopwatch.StartNew();
            for (int i = 1; i <= argumentData.Interactions; i++)
            {
                string sentence = await LeroLeroCrawler.GetSentenceAsync(argumentData.SentenceModo);
                await ByteCounterCrawler.GetBytesAsync(sentence);

                var fileData = FileService.Write(
                    sentence,
                    argumentData.FileSavePath,
                    argumentData.BufferSize,
                    argumentData.FileSize
                );
                fileDataResults.Add(fileData);
            }
            watch.Stop();

            ReportService.WriteData(watch.Elapsed, fileDataResults);

            Console.ReadKey();
        }
    }
}

