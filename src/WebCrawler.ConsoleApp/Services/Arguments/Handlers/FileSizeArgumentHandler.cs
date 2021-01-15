using System;
using WebCrawler.ConsoleApp.Models;

namespace WebCrawler.ConsoleApp.Services.Arguments.Handlers
{
    public class FileSizeArgumentHandler : AbstractHandler
    {
        public override ArgumentDataModel Handle(string[] request)
        {
            var flagFileSize = GetArgument(request, "-fs");
            var fileSize = 100;

            argumentData.FileSize = fileSize;

            if (flagFileSize != null)
            {
                if (int.TryParse(flagFileSize, out fileSize) && fileSize > 0)
                {
                    argumentData.FileSize = fileSize;
                }
                else
                {
                    Console.WriteLine($"Argument -fs {flagFileSize} is invalid. The default value of {argumentData.FileSize} MB has been entered.");
                }
            }

            return base.Handle(request);
        }
    }
}
