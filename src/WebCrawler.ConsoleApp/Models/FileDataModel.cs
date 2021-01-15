using System;
using System.Collections.Generic;

namespace WebCrawler.ConsoleApp.Models
{
    public class FileDataModel
    {
        public FileDataModel()
        {
            TimeSpan = new List<TimeSpan>();
        }

        public string FileSavePath { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }

        public decimal StringBuffer { get; set; }

        public IList<TimeSpan> TimeSpan { get; set; }
        public int Interactions { get; set; }
    }
}
