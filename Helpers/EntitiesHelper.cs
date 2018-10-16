using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveCardsHelpBot.Helpers
{
    public static class EntitiesHelper
    {
        public static bool TryGetHostEntity(RecognizerResult luisResult, out string host)
        {
            host = GetEntity(luisResult, "host");
            return host != null;
        }

        public static string GetEntity(RecognizerResult luisResult, string entityName)
        {
            if (luisResult.Entities != null && luisResult.Entities.HasValues)
            {
                var entity = luisResult.Entities[entityName];
                if (entity != null)
                {
                    return (string)entity[0];
                }
            }

            return null;
        }
    }
}
