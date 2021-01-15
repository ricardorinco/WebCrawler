using WebCrawler.ConsoleApp.Models;
using WebCrawler.ConsoleApp.Services.Arguments.Handlers;

namespace WebCrawler.ConsoleApp.Services.Arguments
{
    public class ArgumentHandler
    {
        public static ArgumentDataModel Execute(string[] args, AbstractHandler handler)
        {
            return handler.Handle(args);
        }
    }
}
