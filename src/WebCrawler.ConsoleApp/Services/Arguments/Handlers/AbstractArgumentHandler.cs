using System.Linq;
using WebCrawler.ConsoleApp.Models;
using WebCrawler.ConsoleApp.Services.Arguments.Interfaces;

namespace WebCrawler.ConsoleApp.Services.Arguments.Handlers
{
    public abstract class AbstractHandler : IHandler
    {
        protected static ArgumentDataModel argumentData = new ArgumentDataModel();

        private IHandler nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            nextHandler = handler;

            return handler;
        }

        public virtual ArgumentDataModel Handle(string[] request)
        {
            if (nextHandler != null)
                return nextHandler.Handle(request);

            return argumentData;
        }

        protected string GetArgument(string[] arguments, string flag)
        {
            for (int i = 0; i < arguments.Length; i++)
            {
                if (arguments[i] == flag)
                    return arguments[i + 1];
            }

            return null;
        }
    }
}
