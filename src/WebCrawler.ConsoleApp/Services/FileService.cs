using System.Diagnostics;
using System.IO;
using WebCrawler.ConsoleApp.Models;
using WebCrawler.ConsoleApp.Utils;

namespace WebCrawler.ConsoleApp.Services
{
    public static class FileService
    {
        public static FileDataModel Write(string sentence, string fileSavePath, int bufferSize, int fileSize)
        {
            var fileData = CreateFileData(fileSavePath);
            var sentenceBuffer = SentenceServices.GetSentenceBuffer(sentence, bufferSize);

            using (var outputFile = new StreamWriter(fileData.FileName, true))
            {
                do
                {
                    var watch = Stopwatch.StartNew();
                    outputFile.WriteLine(sentenceBuffer);
                    watch.Stop();
                    
                    fileData.TimeSpan.Add(watch.Elapsed);
                    fileData.Interactions++;
                } while (outputFile.BaseStream.Length < fileSize.ToBytes());

                fileData.StringBuffer = sentenceBuffer.Capacity;
                fileData.FileSize = outputFile.BaseStream.Length;
            }

            sentenceBuffer.Length = 0;

            return fileData;
        }

        private static FileDataModel CreateFileData(string fileSavePath)
        {
            var fileData = new FileDataModel();
            fileData.FileSavePath = fileSavePath;
            fileData.FileName = Path.Combine(fileSavePath, FileUtil.GetFileName());

            return fileData;
        }
    }
}
