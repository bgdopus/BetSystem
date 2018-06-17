using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetSystem.Web.Models
{
    public class EventInputModel
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        public decimal OddsForFirstTeam { get; set; }

        public decimal OddsForDraw { get; set; }

        public decimal OddsForSecondTeam { get; set; }

        public DateTime EventStartDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}