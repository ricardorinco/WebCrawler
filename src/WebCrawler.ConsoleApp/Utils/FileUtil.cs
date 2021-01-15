using System;

namespace WebCrawler.ConsoleApp.Utils
{
    public static class FileUtil
    {
        public static string GetFileName()
        {
            var dateTime = DateTime.Now.ToString("yyyy-MM-dd-HHmmss");
            return $"{dateTime}-arquivogerado.txt";
        }

        public static int ToBytes(this int megabytes)
        {
            return megabytes * 1048576;
        }

        public static decimal ToMegabytes(this long bytes)
        {
            return bytes / 1048576;
        }
    }
}
