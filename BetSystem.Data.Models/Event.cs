using BetSystem.Data.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetSystem.Data.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
        public string EventName { get; set; }

        public decimal OddsForFirstTeam { get; set; }

        public decimal OddsForDraw { get; set; }

        public decimal OddsForSecondTeam { get; set; }

        public DateTime EventStartDate { get; set; }
    }
}
