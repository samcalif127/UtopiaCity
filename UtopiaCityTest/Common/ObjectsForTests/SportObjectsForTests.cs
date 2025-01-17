﻿using System;
using System.Collections.Generic;
using UtopiaCity.Models.CitizenAccount;
using UtopiaCity.Models.Sport;
using UtopiaCity.Models.Sport.Enums;
using UtopiaCity.ViewModels.Sport;

namespace UtopiaCityTest.Common.ObjectsForTests
{
    public static class SportObjectsForTests
    {
        public static SportComplex SportComplexForTests()
        {
            return new SportComplex
            {
                SportComplexId = "1",
                Title = "title_1",
                Address = "address_1",
                NumberOfSeats = 100,
                TypeOfSport = TypesOfSport.Athletics,
                BuildDate = new DateTime(2021, 8, 10),
                SportEvents = null
            };
        }

        public static SportComplexViewModel SportComplexViewModelForTests()
        {
            return new SportComplexViewModel
            {
                SportComplexId = "1",
                SportComplexTitle = "title_1",
                Address = "address_1",
                NumberOfSeats = 100,
                TypeOfSport = TypesOfSport.Athletics,
                BuildDate = new DateTime(2021, 8, 10),
            };
        }

        public static SportComplex[] ArrayOfSportComplexesForTests()
        {
            return new SportComplex[]
            {
                new SportComplex
                {
                    SportComplexId = "1",
                    Title = "title_1",
                    NumberOfSeats = 100,
                    TypeOfSport = TypesOfSport.Athletics,
                    Address = "address_1",
                    BuildDate = new DateTime(2021, 10, 12),
                    SportEvents = null
                },

                new SportComplex
                {
                    SportComplexId = "2",
                    Title = "title_2",
                    NumberOfSeats = 200,
                    TypeOfSport = TypesOfSport.FigureSkating,
                    Address = "address_2",
                    BuildDate = new DateTime(2022, 10, 12),
                    SportEvents = null
                },

                new SportComplex
                {
                    SportComplexId = "3",
                    Title = "title_3",
                    NumberOfSeats = 300,
                    TypeOfSport = TypesOfSport.Motorsport,
                    Address = "address_3",
                    BuildDate = new DateTime(2023, 10, 12),
                    SportEvents = null
                }
            };
        }

        public static SportEvent SportEventForTests()
        {
            return new SportEvent
            {
                SportEventId = "1",
                Title = "title_1",
                DateOfTheEvent = new DateTime(2021, 11, 12),
                SportComplexId = "1"
            };
        }

        public static SportEventViewModel SportEventViewModelForTests()
        {
            return new SportEventViewModel
            {
                SportEventId = "1",
                SportEventTitle = "title_1",
                DateOfTheEvent = new DateTime(2021, 11, 12),
                SportComplexId = "1",
                SportComplexTitle = "title_1",
                Address = "address_1"
            };
        }

        public static SportEvent[] ArrayOfSportEventsForTests()
        {
            return new SportEvent[]
            {
                new SportEvent
                {
                    SportEventId = "1",
                    Title = "title_1",
                    DateOfTheEvent = new DateTime(2021, 11, 12),
                    SportComplexId = "1"
                },

                new SportEvent
                {
                    SportEventId = "2",
                    Title = "title_2",
                    DateOfTheEvent = new DateTime(2021, 11, 12),
                    SportComplexId = "2"
                },

                new SportEvent
                {
                    SportEventId = "3",
                    Title = "title_3",
                    DateOfTheEvent = new DateTime(2021, 11, 12),
                    SportComplexId = "3"
                }
            };
        }

        public static SportTicket SportTicketForTests()
        {
            return new SportTicket
            {
                TicketId = "1",
                SportComplexId = "1",
                SportEventId = "1",
                AppUserId = "1"
            };
        }

        public static SportTicket[] ArrayOfSportTicketsForTests()
        {
            return new SportTicket[]
            {
                new SportTicket
                {
                    TicketId = "1",
                    SportComplexId = "1",
                    SportEventId = "1",
                    AppUserId = "1"
                },

                new SportTicket
                {
                    TicketId = "2",
                    SportComplexId = "1",
                    SportEventId = "1",
                    AppUserId = "1"
                },

                new SportTicket
                {
                    TicketId = "3",
                    SportComplexId = "2",
                    SportEventId = "2",
                    AppUserId = "2"
                },

                new SportTicket
                {
                    TicketId = "4",
                    SportComplexId = "3",
                    SportEventId = "3",
                    AppUserId = "3"
                },

                new SportTicket
                {
                    TicketId = "5",
                    SportComplexId = "2",
                    SportEventId = "2",
                    AppUserId = "2"
                }
            };
        }

        public static AppUser AppUserForTests()
        {
            return new AppUser
            {
                Id = "1",
                Name = "Name_1",
                Surname = "Surname_1",
                DateOfBirth = new DateTime(2001, 1, 1),
                Gender = Gender.Male,
                Balance = 1.1
            };
        }

        public static AppUser[] ArrayOfAppUsersForTests()
        {
            return new AppUser[]
            {
                new AppUser
                {
                    Id = "1",
                    Name = "Name_1",
                    Surname = "Surname_1",
                    DateOfBirth = new DateTime(2001, 1, 1),
                    Gender = Gender.Male,
                    Balance = 1.1
                },

                new AppUser
                {
                    Id = "2",
                    Name = "Name_2",
                    Surname = "Surname_2",
                    DateOfBirth = new DateTime(2002, 2, 2),
                    Gender = Gender.Male,
                    Balance = 2.2
                },

                new AppUser
                {
                    Id = "3",
                    Name = "Name_3",
                    Surname = "Surname_3",
                    DateOfBirth = new DateTime(2003, 3, 3),
                    Gender = Gender.Male,
                    Balance = 3.3
                }
            };
        }

        public static List<CitizensTask> ListOfCitizensTask()
        {
            return new List<CitizensTask>()
            {
                new CitizensTask()
                {
                    Id = "1",
                    Description = "title_1",
                    ReminderDate = new DateTime(2021, 11, 12),
                    UserId = "1"
                },

                new CitizensTask()
                {
                    Id = "1",
                    Description = "title_2",
                    ReminderDate = new DateTime(2021, 11, 12),
                    UserId = "1"
                },

                new CitizensTask()
                {
                    Id = "2",
                    Description = "title_2",
                    ReminderDate = new DateTime(2021, 11, 12),
                    UserId = "2"
                },

                new CitizensTask()
                {
                    Id = "3",
                    Description = "title_3",
                    ReminderDate = new DateTime(2021, 11, 12),
                    UserId = "3"
                }
            };
        }

        public static SportTicketViewModel SportTicketViewModelForTests()
        {
            return new SportTicketViewModel()
            {
                SportTicketId = "1",
                SportEventTitle = "title_1",
                DateOfTheEvent = new DateTime(2021, 1, 1),
                SportComplexTitle = "title_1",
                Address = "address_1",
                VisitorName = "name_1",
                VisitorSurname = "surname_1"
            };
        }
        
        public static RequestToAdministration RequestToAdministrationForTests()
        {
            return new RequestToAdministration()
            {
                Id = "1",
                Description = "description_1",
                DateOfRequest = new DateTime(2001, 1, 1),
                IsApproved = false,
                IsReviewed = false,
                SportComplexId = "1"
            };
        }

        public static RequestToAdministration[] ArrayOfRequestsToAdministrationForTests()
        {
            return new RequestToAdministration[]
            {
                new RequestToAdministration
                {
                    Id = "1",
                    Description = "description_1",
                    DateOfRequest = new DateTime(2001, 1, 1),
                    IsApproved = false,
                    IsReviewed = false,
                    SportComplexId = "1"
                },

                new RequestToAdministration
                {
                    Id = "2",
                    Description = "description_2",
                    DateOfRequest = new DateTime(2002, 2, 2),
                    IsApproved = false,
                    IsReviewed = true,
                    SportComplexId = "2"
                },
                new RequestToAdministration
                {
                    Id = "3",
                    Description = "description_3",
                    DateOfRequest = new DateTime(2003, 3, 3),
                    IsApproved = false,
                    IsReviewed = false,
                    SportComplexId = "3"
                }
            };
        }

        public static RequestToAdministrationViewModel RequestToAdministrationViewModelForTests()
        {
            return new RequestToAdministrationViewModel
            {
                Id = "1",
                Description = "description_1",
                DateOfRequest = new DateTime(2001, 1, 1),
                IsApproved = false,
                IsReviewed = false,
                Available = false,
                TypeOfSport = TypesOfSport.Athletics,
                SportComplexId = "1",
                SportComplexTitle = "title_1"
            };
        }

        public static RequestToAdministrationViewModel[] ArrayOfRequestToAdministrationViewModelsForTests()
        {
            return new RequestToAdministrationViewModel[]
            {
                new RequestToAdministrationViewModel
                {
                    Id = "1",
                    Description = "description_1",
                    DateOfRequest = new DateTime(2001, 1, 1),
                    IsApproved = false,
                    IsReviewed = false,
                    Available = false,
                    SportComplexId = "1",
                    TypeOfSport = TypesOfSport.Athletics,
                    SportComplexTitle = "title_1"
                },

                new RequestToAdministrationViewModel
                {
                    Id = "2",
                    Description = "description_2",
                    DateOfRequest = new DateTime(2002, 2, 2),
                    IsApproved = false,
                    IsReviewed = false,
                    Available = false,
                    SportComplexId = "2",
                    TypeOfSport = TypesOfSport.FigureSkating,
                    SportComplexTitle = "title_2"
                },

                new RequestToAdministrationViewModel
                {
                    Id = "3",
                    Description = "description_3",
                    DateOfRequest = new DateTime(2003, 3, 3),
                    IsApproved = false,
                    IsReviewed = false,
                    Available = false,
                    SportComplexId = "3",
                    TypeOfSport = TypesOfSport.Motorsport,
                    SportComplexTitle = "title_3"
                },
            };
        }
    }
}