using WebCrawler.ConsoleApp.Models;

namespace WebCrawler.ConsoleApp.Services.Arguments.Handlers
{
    public class FileSavePathArgumentHandler : AbstractHandler
    {
        public override ArgumentDataModel Handle(string[] request)
        {
            var flagFileSavePath = GetArgument(request, "-fsp");
            if (flagFileSavePath != null)
                argumentData.FileSavePath = flagFileSavePath;

            return base.Handle(request);
        }
    }
}
