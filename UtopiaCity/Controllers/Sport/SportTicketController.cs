﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common;
using UtopiaCity.Models.CitizenAccount;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.CitizenAccount;
using UtopiaCity.Services.Sport;
using UtopiaCity.ViewModels.Sport;

namespace UtopiaCity.Controllers.Sport
{
    public class SportTicketController : Controller
    {
        private readonly SportTicketService _sportTicketService;
        private readonly SportComplexService _sportComplexService;
        private readonly SportEventService _sportEventService;
        private readonly CitizensAccountService _appUserService;
        private readonly CitizenTaskService _citizenTaskService;
        private readonly IMapper _mapper;
        private readonly string _userId;

        public SportTicketController(SportTicketService sportTicketService, SportComplexService sportComplexService, SportEventService sportEventService,
            CitizensAccountService appUserService, CitizenTaskService citizenTaskService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _sportTicketService = sportTicketService;
            _sportComplexService = sportComplexService;
            _sportEventService = sportEventService;
            _appUserService = appUserService;
            _citizenTaskService = citizenTaskService;
            _mapper = mapper;
            _userId = GetInformationAboutAuthenticatedUser.GetAuthenticatedUsersId(httpContextAccessor);
        }

        public async Task<IActionResult> AllSportTickets()
        {
            List<SportTicket> sportTickets = await _sportTicketService.GetAllSportTickets(_userId);
            if (sportTickets == null)
            {
                return View("Error", "Some problems. Please, try again");
            }

            var sportTicketsViewModels = new List<SportTicketViewModel>();
            foreach (var sportTicket in sportTickets)
            {
                sportTicketsViewModels.Add(_mapper.Map<SportTicketViewModel>(sportTicket));
            }

            return View(sportTicketsViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Create(string id)
        {
            if(id == null)
            {
                return View("Error", "Incorrect Id. Please, try again");
            }

            SportEvent sportEvent = await _sportEventService.GetSportEventByIdWithSportComplex(id);
            if (sportEvent == null)
            {
                return View("Error", "Some problems. Please, try again");
            }

            var appUser = await _appUserService.GetUserById(_userId);
            if (appUser == null)
            {
                return View("Error", "App user not found. Please, try again");
            }

            SportTicket sportTicket = new SportTicket
            {
                SportComplexId = sportEvent.SportComplex.SportComplexId,
                SportEventId = sportEvent.SportEventId,
                AppUserId = _userId,
                SportComplex = sportEvent.SportComplex,
                SportEvent = sportEvent,
                AppUser = appUser
            };

            var sportTicketViewModel = _mapper.Map<SportTicketViewModel>(sportTicket);
            return View(sportTicketViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SportTicketViewModel sportTicketViewModel)
        {
            if (sportTicketViewModel == null)
            {
                return View("Error", "You made mistakers while creating new Sport Ticket. Please, try again");
            }

            string sportComplexId = await _sportComplexService.GetSportComplexIdByTitle(sportTicketViewModel.SportComplexTitle);
            if (sportComplexId == null)
            {
                return View("Error", "Incorrect sport complex chosen." + Environment.NewLine + "Please, try again");
            }

            string sportEventId = await _sportEventService.GetSportEventIdByTitle(sportTicketViewModel.SportEventTitle);
            if (sportEventId == null)
            {
                return View("Error", "Incorrect sport event chosen." + Environment.NewLine + "Please, try again");
            }

            var sportTicket = _mapper.Map<SportTicket>(sportTicketViewModel);
            sportTicket.SportComplexId = sportComplexId;
            sportTicket.SportEventId = sportEventId;
            sportTicket.AppUserId = _userId;
            await _sportTicketService.AddSportTicketToDb(sportTicket);

            CitizensTask citizensTask = new CitizensTask
            {
                UserId = _userId,
                Description = sportTicketViewModel.SportEventTitle,
                ReminderDate = sportTicketViewModel.DateOfTheEvent
            };

            await _citizenTaskService.AddCitizenTask(citizensTask);
            return RedirectToAction(nameof(AllSportTickets));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return View("Error", "Incorrect ID." + Environment.NewLine + "Please, try again");
            }

            SportTicket sportTicket = await _sportTicketService.GetSportTicketById(id);
            if (sportTicket == null)
            {
                return View("Error", "Sport ticket not found." + Environment.NewLine + "Please, try again");
            }

            SportTicketViewModel sportTicketViewModel = _mapper.Map<SportTicketViewModel>(sportTicket);
            return View(sportTicketViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return View("Error", "Incorrect ID." + Environment.NewLine + "Please, try again");
            }

            SportTicket sportTicket = await _sportTicketService.GetSportTicketById(id);
            if (sportTicket == null)
            {
                return View("Error", "Sport ticket not found." + Environment.NewLine + "Please, try again");
            }

            var tasks = await _citizenTaskService.GetTasksByReminderDate(_userId);
            var task = tasks.FirstOrDefault(x => x.Description.Equals(sportTicket.SportEvent.Title));
            await _sportTicketService.RemoveSportTicketFromDb(sportTicket);
            if (task != null)
            {
                await _citizenTaskService.DeleteCitizenTask(task);
            }

            return RedirectToAction(nameof(AllSportTickets));
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return View("Error", "Incorrect ID." + Environment.NewLine + "Please, try again");
            }

            SportTicket sportTicket = await _sportTicketService.GetSportTicketById(id);
            if (sportTicket == null)
            {
                return View("Error", "Sport ticket not found." + Environment.NewLine + "Please, try again");
            }

            var sportTicketViewModel = _mapper.Map<SportTicketViewModel>(sportTicket);
            return View(sportTicketViewModel);
        }
    }
}
