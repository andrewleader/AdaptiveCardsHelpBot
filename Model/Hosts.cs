using AdaptiveCardsHelpBot.Helpers;
using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveCardsHelpBot.Model
{
    public static class Hosts
    {
        public static readonly Host[] AllHosts = new Host[]
        {
            new Host()
            {
                Name = "Outlook Actionable Messages",
                Id = "OutlookActionableMessages",
            },
            new Host()
            {
                Name = "Timeline",
                Id = "Timeline",
                Keywords = new string[] { "Windows" },
            },
            new Host()
            {
                Name = "Bot Framework",
                Id = "BotFramework",
                Keywords = new string[] { "Microsoft Teams", "WebChat" },
            },
        };

        public static Host FindHost(string hostName)
        {
            var words = hostName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var host = AllHosts.OrderByDescending(i => CountOfWords(words, i)).FirstOrDefault();
            if (host != null && CountOfWords(words, host) > 0)
            {
                return host;
            }

            return null;
        }

        public static bool TryGetHost(RecognizerResult luisResults, out Host host)
        {
            if (EntitiesHelper.TryGetHostEntity(luisResults, out string hostString))
            {
                host = FindHost(hostString);
                return host != null;
            }
            else
            {
                host = null;
                return false;
            }
        }

        private static int CountOfWords(string[] words, Host host)
        {
            int answer = 0;
            var source = host.Name.ToLower();
            foreach (var w in words)
            {
                if (source.Contains(w))
                {
                    answer++;
                }
                else if (host.Keywords != null)
                {
                    foreach (var k in host.Keywords)
                    {
                        var keyword = k.ToLower();
                        if (keyword.Contains(w))
                        {
                            answer++;
                            break;
                        }
                    }
                }
            }
            return answer;
        }
    }
}
