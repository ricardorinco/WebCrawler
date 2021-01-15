using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using WebCrawler.ConsoleApp.Models;
using WebCrawler.ConsoleApp.Utils;

namespace WebCrawler.ConsoleApp.Services
{
    public static class SentenceServices
    {
        public static StringBuilder GetSentenceBuffer(string sentence, int bufferSize)
        {
            var stringBuilder = new StringBuilder(0, bufferSize.ToBytes());

            do
            {
                stringBuilder.Append(sentence);
            } while (stringBuilder.Capacity <= bufferSize.ToBytes());

            return AdjustBufferLimit(stringBuilder, bufferSize.ToBytes());
        }

        public static string GetSentenceByJson()
        {
            var random = new Random();
            var sentenceFile = ConfigurationManager.AppSettings.Get("SentenceFile");
            var jsonString = File.ReadAllText(sentenceFile);
            var sentences = JsonConvert.DeserializeObject<SentenceModel[]>(jsonString);
            var sortSentence = random.Next(0, sentences.Length - 1);

            return sentences[sortSentence].sentence;
        }

        private static StringBuilder AdjustBufferLimit(StringBuilder sentence, int bufferSize)
        {
            while (sentence.Capacity > bufferSize)
                sentence.Remove(sentence.Length - 10, 10);

            return sentence;
        }
    }
}
