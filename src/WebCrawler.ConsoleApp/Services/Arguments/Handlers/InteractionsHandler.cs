using System;
using WebCrawler.ConsoleApp.Models;

namespace WebCrawler.ConsoleApp.Services.Arguments.Handlers
{
    public class InteractionsArgumentHandler : AbstractHandler
    {
        public override ArgumentDataModel Handle(string[] request)
        {
            var flagInteractions = GetArgument(request, "-i");
            var interactions = 1;

            argumentData.Interactions = interactions;

            if (flagInteractions != null)
            {
                if (int.TryParse(flagInteractions, out interactions) && interactions > 0)
                {
                    argumentData.Interactions = interactions;
                }
                else
                {
                    Console.WriteLine($"Argument -i {flagInteractions} is invalid. The default value of {argumentData.Interactions} has been entered.");
                }
            }

            return base.Handle(request);
        }
    }
}
