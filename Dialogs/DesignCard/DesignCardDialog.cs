using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdaptiveCardsHelpBot.Dialogs.Greeting
{
    public class DesignCardDialog : Dialog
    {
        public DesignCardDialog()
            : base(nameof(DesignCardDialog))
        {
        }

        public override async Task<DialogTurnResult> BeginDialogAsync(DialogContext dc, object options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            await dc.Context.SendActivityAsync("You can use the [Adaptive Card Designer](https://adaptivecards.io/designer/) to design a card. To see what's possible, browse [the samples](https://adaptivecards.io/samples/). Check out [the schema explorer](https://adaptivecards.io/explorer/) to learn what properties and elements can be used within cards.");

            return await dc.EndDialogAsync();
        }
    }
}
