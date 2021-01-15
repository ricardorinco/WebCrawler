using System;

namespace WebCrawler.ConsoleApp.Utils
{
    public static class DateTimeUtil
    {
        public static string ToMinutesFormated(this TimeSpan timespan)
        {
            return $"{timespan.Hours:D2}:{timespan.Minutes:D2}:{timespan.Seconds:D2}:{timespan.Milliseconds}";
        }
    }
}
