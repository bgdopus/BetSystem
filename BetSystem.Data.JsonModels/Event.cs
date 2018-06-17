using BetSystem.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BetSystem.Data.JsonModels
{
    public class Event : IMapFrom<BetSystem.Data.Models.Event>
    {
        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("oddsForFirstTeam")]
        public decimal OddsForFirstTeam { get; set; }

        [JsonProperty("oddsForDraw")]
        public decimal OddsForDraw { get; set; }

        [JsonProperty("oddsForSecondTeam")]
        public decimal OddsForSecondTeam { get; set; }

        [JsonProperty("eventStartDate")]
        public DateTime EventStartDate { get; set; }
    }
}
