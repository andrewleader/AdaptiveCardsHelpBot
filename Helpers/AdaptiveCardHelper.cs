using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveCardsHelpBot.Helpers
{
    public static class AdaptiveCardHelper
    {
        public static async Task SendCardFromFileAsync(DialogContext dc, string cardFile)
        {
            string cardJson = File.ReadAllText(cardFile);
            await dc.Context.SendActivityAsync(CreateCardMessage(dc, cardJson));
        }

        public static IActivity CreateCardMessage(DialogContext context, string cardJson)
        {
            var message = context.Context.Activity.CreateReply();
            message.Attachments = new List<Attachment>()
            {
                new Attachment()
                {
                    ContentType = "application/vnd.microsoft.card.adaptive",
                    Content = JsonConvert.DeserializeObject(cardJson),
                },
            };
            return message;
        }
    }
}
