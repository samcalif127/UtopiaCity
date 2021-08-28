﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UtopiaCity.Data;
using UtopiaCity.Models.Sport;
using UtopiaCity.ViewModels.Sport;

namespace UtopiaCity.Services.Sport
{
    /// <summary>
    /// Class to handle basic CRUD operations for <see cref="RequestToAdministration"/>
    /// </summary>
    public class RequestToAdministrationService
    {
        private readonly ApplicationDbContext _dbContext;

        public RequestToAdministrationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets list of all requests to the city administration.
        /// </summary>
        /// <returns>List of all existing requests to the city administration.</returns>
        public List<RequestToAdministration> GetAllRequestsToAdministration() => _dbContext.RequestsToAdministration
            .Include(x => x.SportComplex).ToList();

        /// <summary>
        /// Gets list of all requests to the city administation by sport complex's id>.
        /// </summary>
        /// <param name="sportComplexId">Id of sport complex</param>
        /// <returns>List of all existing requests to the city administration.</returns>
        public List<RequestToAdministration> GetRequestsToAdministrationBySportComplexId(string sportComplexId) => _dbContext
            .RequestsToAdministration
            .Include(x => x.SportComplex)
            .Where(x => x.SportComplexId.Equals(sportComplexId))
            .ToList();

        /// <summary>
        /// Gets list of all requests to the city administation by the date>.
        /// </summary>
        /// <param name="date">Date of request</param>
        /// <returns>List of all existing requests to the city administration.</returns>
        public List<RequestToAdministration> GetRequestsToAdministrationByDate(DateTime date) => _dbContext.RequestsToAdministration
            .Include(x => x.SportComplex)
            .Where(x => x.DateOfRequest.Date.Equals(date))
            .ToList();

        /// <summary>
        /// Gets <see cref="RequestToAdministration"/> by Id.
        /// </summary>
        /// <param name="requestId">Id of request.</param>
        /// <returns>Request to the administration if it exists, otherwise null.</returns>
        public RequestToAdministration GetRequestToAdministrationById(string requestId) => _dbContext.RequestsToAdministration
            .Include(x => x.SportComplex)
            .FirstOrDefault(x => x.Id.Equals(requestId));

        /// <summary>
        /// Method for adding new request to the administration to database.
        /// </summary>
        /// <param name="request">Request to the administation for adding.</param>
        public void AddRequestToDb(RequestToAdministration request)
        {
            _dbContext.RequestsToAdministration.Add(request);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Method for updating request to the administration in database.
        /// </summary>
        /// <param name="request">Request to the administation for updating.</param>
        public void UpdateRequestInDb(RequestToAdministration request)
        {
            _dbContext.RequestsToAdministration.Update(request);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Method for removing request to the administration from database.
        /// </summary>
        /// <param name="request">Request to the administation for removing.</param>
        public void RemoveRequestFromDb(RequestToAdministration request)
        {
            _dbContext.RequestsToAdministration.Remove(request);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Method for mapping <see cref="RequestToAdministration"/> model into <see cref="RequestToAdministrationViewModel"/> view model.
        /// </summary>
        /// <param name="allRequests">Requests for mapping from model to viewModel<./param>
        /// <param name="mapper">Mapper for mapping model to viewModel</param>
        /// <returns>List of <see cref="RequestToAdministrationViewModel"/></returns>
        public List<RequestToAdministrationViewModel> CreatingRequestToAdministationViewModel(List<RequestToAdministration> allRequests, IMapper mapper)
        {
            var requestsViewModel = new List<RequestToAdministrationViewModel>();
            foreach (var request in allRequests)
            {
                requestsViewModel.Add(mapper.Map<RequestToAdministrationViewModel>(request));
            }

            return requestsViewModel;
        }
    }
}