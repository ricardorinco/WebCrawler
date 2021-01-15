using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCrawler.ConsoleApp.Models;
using WebCrawler.ConsoleApp.Utils;

namespace WebCrawler.ConsoleApp.Services
{
    public static class ReportService
    {
        public static void WriteData(TimeSpan totalTime, IList<FileDataModel> fileData)
        {
            Console.WriteLine("Report Results");

            var consoleTable = new ConsoleTable("#", "Nome", "Tamanho", "Path", "Iterações", "String Buffer", "Tempo Total", "Tempo Médio");
            var index = 0;
            foreach (var data in fileData)
            {
                var averageTime = TimeSpan.FromSeconds(data.TimeSpan.Select(s => s.TotalSeconds).Average());

                consoleTable.AddRow(
                    ++index,
                    data.FileName,
                    $"{data.FileSize.ToMegabytes()} MB",
                    data.FileSavePath,
                    data.Interactions,
                    $"{data.StringBuffer} bytes",
                    totalTime.ToMinutesFormated(),
                    averageTime.ToMinutesFormated()
                );
            }
            
            consoleTable.Write();
        }
    }
}
