using WebCrawler.ConsoleApp.Crawlers.LeroLero.Struct;

namespace WebCrawler.ConsoleApp.Models
{
    public class ArgumentDataModel
    {
        public string FileSavePath { get; set; }
        public int FileSize { get; set; }
        public int Interactions { get; set; }
        public int BufferSize { get; set; }
        public SentenceModo SentenceModo { get; set; }
    }
}
