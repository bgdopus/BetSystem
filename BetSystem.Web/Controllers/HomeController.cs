using AutoMapper;
using BetSystem.Common.Constants;
using BetSystem.Services.Contracts;
using BetSystem.Services.DTO;
using BetSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BetSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventService eventService;
        private readonly IMapper mapper;

        public HomeController()
        {

        }
        public HomeController(IEventService eventService, IMapper mapper)
        {
            this.eventService = eventService;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var model = new EventsViewModel
            {
                Events = this.eventService.GetAllEvents()
            };

            return View(model);
        }

        public ActionResult Edit()
        {

            var model = new EventsViewModel
            {
                Events = this.eventService.GetAllEvents()
            };

            return View(model);
        }

        public ActionResult AddEvent()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult AddEvent(EventInputModel inputModel)
        {
            var model = new EventDTO
            {
                EventName = inputModel.EventName,
                OddsForFirstTeam = inputModel.OddsForFirstTeam,
                OddsForDraw = inputModel.OddsForDraw,
                OddsForSecondTeam = inputModel.OddsForSecondTeam,
                EventStartDate = inputModel.EventStartDate
            };

            this.eventService.AddEvent(model);

            return this.RedirectToAction(Views.IndexView);
        }

        [HttpPost]
        public ActionResult UpdateEvent(EventInputModel inputModel)
        {
            var model = new EventDTO
            {
                Id = inputModel.Id,
                EventName = inputModel.EventName,
                OddsForFirstTeam = inputModel.OddsForFirstTeam,
                OddsForDraw = inputModel.OddsForDraw,
                OddsForSecondTeam = inputModel.OddsForSecondTeam,
                EventStartDate = inputModel.EventStartDate,
                IsDeleted = inputModel.IsDeleted
            };

            try
            {
                this.eventService.UpdateEvent(model);
            }
            catch (Exception ex)
            {

                return Json(new { status = "error", message = "Error occured" });
            }


            return Json(new { status = "success", message = "Done" });
        }
    }
}