using AdaptiveCardsHelpBot.Helpers;
using AdaptiveCardsHelpBot.Model;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveCardsHelpBot.SimpleResponses
{
    public static class HostVersionResponse
    {
        public static async Task RespondAsync(DialogContext dc, RecognizerResult luisResults)
        {
            if (Hosts.TryGetHost(luisResults, out Host host))
            {
                await AdaptiveCardHelper.SendCardFromFileAsync(dc, host.GetVersionsFilePath());
            }
            else
            {
                await dc.Context.SendActivityAsync("Please specify which host you're curious about, like \"What version is supported in Outlook?\"");
            }
        }
    }
}
