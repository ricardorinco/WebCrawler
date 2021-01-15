using WebCrawler.ConsoleApp.Models;
using WebCrawler.ConsoleApp.Services.Arguments.Handlers;

namespace WebCrawler.ConsoleApp.Services.Arguments
{
    public class ArgumentService
    {
        private static readonly AbstractHandler bufferSizeArgumentHandler = new BufferSizeArgumentHandler();
        private static readonly AbstractHandler fileSavePathArgumentHandler = new FileSavePathArgumentHandler();
        private static readonly AbstractHandler fileSizeArgumentHandler = new FileSizeArgumentHandler();
        private static readonly AbstractHandler interactionsArgumentHandler = new InteractionsArgumentHandler();
        private static readonly AbstractHandler sentenceModoArgumentHandler = new SentenceModoArgumentHandler();

        public static ArgumentDataModel CheckCommands(string[] args)
        {
            bufferSizeArgumentHandler
                .SetNext(fileSavePathArgumentHandler)
                .SetNext(fileSizeArgumentHandler)
                .SetNext(interactionsArgumentHandler)
                .SetNext(sentenceModoArgumentHandler);

            return ArgumentHandler.Execute(args, bufferSizeArgumentHandler);
        }
    }
}
