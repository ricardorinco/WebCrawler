using System;
using WebCrawler.ConsoleApp.Models;

namespace WebCrawler.ConsoleApp.Services.Arguments.Handlers
{
    public class BufferSizeArgumentHandler : AbstractHandler
    {
        public override ArgumentDataModel Handle(string[] request)
        {
            var flagBufferSize = GetArgument(request, "-bs");
            var bufferSize = 10;

            argumentData.BufferSize = bufferSize;

            if (flagBufferSize != null)
            {
                if (int.TryParse(flagBufferSize, out bufferSize) && bufferSize > 0)
                {
                    argumentData.BufferSize = bufferSize;
                }
                else
                {
                    Console.WriteLine($"Argument -bs {flagBufferSize} is invalid. The default value of {argumentData.BufferSize} MB has been entered.");
                }
            }

            return base.Handle(request);
        }
    }
}
