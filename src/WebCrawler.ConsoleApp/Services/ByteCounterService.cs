using System.Text;

namespace WebCrawler.ConsoleApp.Services
{
    public static class ByteCounterService
    {
        public static int GetByteCount(string sentence)
        {
            return Encoding.UTF8.GetByteCount(sentence);
        }
    }
}
