using System;
using WebCrawler.ConsoleApp.Crawlers.LeroLero.Struct;
using WebCrawler.ConsoleApp.Models;

namespace WebCrawler.ConsoleApp.Services.Arguments.Handlers
{
    public class SentenceModoArgumentHandler : AbstractHandler
    {
        public override ArgumentDataModel Handle(string[] request)
        {
            var flagSentenceModo = GetArgument(request, "-m");
            var sentenceModo = (int)SentenceModo.Programador;

            argumentData.SentenceModo = (SentenceModo)sentenceModo;

            if (flagSentenceModo != null)
            {
                var hasError = false;
                if (int.TryParse(flagSentenceModo, out sentenceModo) && sentenceModo > 0)
                {
                    if (Enum.IsDefined(typeof(SentenceModo), sentenceModo))
                    {
                        argumentData.SentenceModo = (SentenceModo)sentenceModo;
                    }
                    else
                    {
                        hasError = true;
                    }
                }
                else
                {
                    hasError = true;
                }

                if (hasError)
                {
                    Console.WriteLine($"Argument -m {flagSentenceModo} is invalid. The default value of {argumentData.SentenceModo} has been entered.");
                }
            }

            return base.Handle(request);
        } 
    }
}
