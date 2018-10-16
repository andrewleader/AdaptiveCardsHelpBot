using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveCardsHelpBot.Model
{
    public class Host
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public string[] Keywords { get; set; }

        public string GetVersionsFilePath()
        {
            return $"StaticCards/Hosts/{Id}/Versions.json";
        }
    }
}
