﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.Sport;
using UtopiaCity.ViewModels.Sport;

namespace UtopiaCity.Controllers.CityAdministration
{
    public class RequestsConfirmationController : Controller
    {
        private readonly RequestToAdministrationService _requestToAdministrationService;
        private readonly SportComplexService _sportComplexService;
        private readonly IMapper _mapper;

        public RequestsConfirmationController(RequestToAdministrationService requestToAdministrationService, SportComplexService sportComplexService, IMapper mapper)
        {
            _requestToAdministrationService = requestToAdministrationService;
            _sportComplexService = sportComplexService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<RequestToAdministration> allRequests = await _requestToAdministrationService.GetAllRequestsToAdministration();
            List<RequestToAdministrationViewModel> viewModels = _requestToAdministrationService.CreatingRequestToAdministationViewModel(allRequests, _mapper);
            return View("~/Views/CityAdministration/RequestsConfirmation/Index.cshtml", viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return View("Error", "The id is incorrect. Please, try again");
            }

            RequestToAdministration request = await _requestToAdministrationService.GetRequestToAdministrationById(id);
            if (request == null)
            {
                return View("Error", "The request is not found. Please, try again");
            }

            var requestViewModel = _mapper.Map<RequestToAdministrationViewModel>(request);
            return View("~/Views/CityAdministration/RequestsConfirmation/Edit.cshtml", requestViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, RequestToAdministrationViewModel requestViewModel)
        {
            if (id == null)
            {
                return View("Error", "The id is incorrect. Please, try again");
            }
            else if (requestViewModel == null)
            {
                return View("Error", "Some errors in input data. Please, try again");
            }

            SportComplex sportComplex = await _sportComplexService.GetSportComplexByTitle(requestViewModel.SportComplexTitle);

            if (sportComplex == null)
            {
                return View("Error", "Some problems with the sport complex data. Please, try again");
            }

            if (requestViewModel.IsApproved && !sportComplex.Available)
            {
                sportComplex.Available = true;
            }
            else if (!requestViewModel.IsApproved && sportComplex.Available)
            {
                sportComplex.Available = false;
            }

            if (!requestViewModel.IsReviewed)
            {
                requestViewModel.IsReviewed = true;
            }

            requestViewModel.SportComplexId = sportComplex.SportComplexId;
            await _sportComplexService.UpdateSportComplexInDb(sportComplex);
            var request = _mapper.Map<RequestToAdministration>(requestViewModel);
            await _requestToAdministrationService.UpdateRequestInDb(request);
            return RedirectToAction(nameof(Index));
        }
    }
}