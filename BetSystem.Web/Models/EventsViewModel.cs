using BetSystem.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetSystem.Web.Models
{
    public class EventsViewModel
    {
        public IList<EventDTO> Events { get; set; }
    }
}