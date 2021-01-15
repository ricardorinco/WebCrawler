using WebCrawler.ConsoleApp.Models;

namespace WebCrawler.ConsoleApp.Services.Arguments.Interfaces
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        ArgumentDataModel Handle(string[] request);
    }
}
