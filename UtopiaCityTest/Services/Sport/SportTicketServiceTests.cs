﻿using System.Linq;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;
using UtopiaCity.Models.Sport;
using UtopiaCityTest.Common.ObjectsForTests;
using Xunit;

namespace UtopiaCityTest.Services.Sport
{
    public class SportTicketServiceTests : BaseServiceTest
    {
        private readonly SportTicket _sportTicketForTests;
        private readonly SportTicket[] _sportTicketsForTests;
        private readonly SportComplex _sportComplexForTests;
        private readonly SportComplex[] _sportComplexesForTests;
        private readonly SportEvent _sportEventForTests;
        private readonly SportEvent[] _sportEventsForTests;
        private readonly AppUser _appUserForTests;
        private readonly AppUser[] _appUsersForTests;

        public SportTicketServiceTests()
        {
            Setup();
            _sportTicketForTests = SportObjectsForTests.SportTicketForTests();
            _sportTicketsForTests = SportObjectsForTests.ArrayOfSportTicketsForTests();
            _sportComplexForTests = SportObjectsForTests.SportComplexForTests();
            _sportComplexesForTests = SportObjectsForTests.ArrayOfSportComplexesForTests();
            _sportEventForTests = SportObjectsForTests.SportEventForTests();
            _sportEventsForTests = SportObjectsForTests.ArrayOfSportEventsForTests();
            _appUserForTests = SportObjectsForTests.AppUserForTests();
            _appUsersForTests = SportObjectsForTests.ArrayOfAppUsersForTests();
        }

        [Fact]
        public void GetAllSportTickets_ReturnsListOfTicketsWithRelationalTablesData()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.AddRange(_sportComplexesForTests);
                context.SportEvents.AddRange(_sportEventsForTests);
                context.AppUser.AddRange(_appUsersForTests);
                context.SportTickets.AddRange(_sportTicketsForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportTicketService(context);

                //act
                var result = service.GetAllSportTicketsWithRelationalData();

                //assert
                Assert.Collection(result,
                    item =>
                    {
                        Assert.Equal(_sportTicketsForTests[0].TicketId, item.SportTicketId);
                        Assert.Equal(_sportTicketsForTests[0].SportComplexId, item.SportComplexId);
                        Assert.Equal(_sportTicketsForTests[0].SportEventId, item.SportEventId);
                        Assert.Equal(_sportTicketsForTests[0].AppUserId, item.AppUserId);
                        Assert.NotNull(item.SportComplex);
                        Assert.NotNull(item.SportEvent());
                        Assert.NotNull(item.ResidentAccount);
                    },
                    item =>
                    {
                        Assert.Equal(_sportTicketsForTests[0].TicketId, item.SportTicketId);
                        Assert.Equal(_sportTicketsForTests[0].SportComplexId, item.SportComplexId);
                        Assert.Equal(_sportTicketsForTests[0].SportEventId, item.SportEventId);
                        Assert.Equal(_sportTicketsForTests[0].AppUserId, item.AppUserId);
                        Assert.NotNull(item.SportComplex);
                        Assert.NotNull(item.SportEvent());
                        Assert.NotNull(item.ResidentAccount);
                    },
                    item =>
                    {
                        Assert.Equal(_sportTicketsForTests[0].TicketId, item.SportTicketId);
                        Assert.Equal(_sportTicketsForTests[0].SportComplexId, item.SportComplexId);
                        Assert.Equal(_sportTicketsForTests[0].SportEventId, item.SportEventId);
                        Assert.Equal(_sportTicketsForTests[0].AppUserId, item.AppUserId);
                        Assert.NotNull(item.SportComplex);
                        Assert.NotNull(item.SportEvent());
                        Assert.NotNull(item.ResidentAccount);
                    },
                    item =>
                    {
                        Assert.Equal(_sportTicketsForTests[0].TicketId, item.SportTicketId);
                        Assert.Equal(_sportTicketsForTests[0].SportComplexId, item.SportComplexId);
                        Assert.Equal(_sportTicketsForTests[0].SportEventId, item.SportEventId);
                        Assert.Equal(_sportTicketsForTests[0].AppUserId, item.AppUserId);
                        Assert.NotNull(item.SportComplex);
                        Assert.NotNull(item.SportEvent());
                        Assert.NotNull(item.ResidentAccount);
                    },
                    item =>
                    {
                        Assert.Equal(_sportTicketsForTests[0].TicketId, item.SportTicketId);
                        Assert.Equal(_sportTicketsForTests[0].SportComplexId, item.SportComplexId);
                        Assert.Equal(_sportTicketsForTests[0].SportEventId, item.SportEventId);
                        Assert.Equal(_sportTicketsForTests[0].AppUserId, item.AppUserId);
                        Assert.NotNull(item.SportComplex);
                        Assert.NotNull(item.SportEvent());
                        Assert.NotNull(item.ResidentAccount);
                    }
                );
            }

            TearDown();
        }

        [Fact]
        public void GetSportTicketById_ReturnsSportTicketWithRelationalData()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.Add(_sportComplexForTests);
                context.SportEvents.Add(_sportEventForTests);
                context.AppUser.Add(_appUserForTests);
                context.SportTickets.Add(_sportTicketForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportTicketService(context);

                //act
                var result = service.GetSportTicketByIdWithRelationalData("1");

                //assert
                Assert.NotNull(result);
                Assert.Equal("1", result.TicketId);
                Assert.Equal("1", result.SportComplexId);
                Assert.Equal("1", result.SportEventId);
                Assert.Equal("1", result.AppUserId);
                Assert.NotNull(result.SportComplex);
                Assert.NotNull(result.SportEvent);
                Assert.NotNull(result.AppUser);
            }

            TearDown();
        }

        [Fact]
        public void AddSportTicketToDbTest()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.Add(_sportComplexForTests);
                context.SportEvents.Add(_sportEventForTests);
                context.AppUser.Add(_appUserForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportTicketService(context);
                service.AddSportTicketToDb(_sportTicketForTests);

                //act
                var result = context.SportTickets.FirstOrDefault(x => x.TicketId.Equals(_sportTicketForTests.TicketId));

                //assert
                Assert.NotNull(result);
                Assert.Equal("1", result.TicketId);
                Assert.NotNull(result.SportComplex);
                Assert.NotNull(result.SportEvent);
                Assert.NotNull(result.AppUser);
            }

            TearDown();
        }

        [Fact]
        public void UpdateSportTicketInDbTest()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportTickets.Add(_sportTicketForTests);
                context.SportComplex.AddRange(_sportComplexesForTests);
                context.SportEvents.AddRange(_sportEventsForTests);
                context.AppUser.AddRange(_appUserForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportTicketService(context);
                service.UpdateSportTicketInDb(new SportTicket
                {
                    TicketId = "1",
                    SportComplexId = "2",
                    SportEventId = "2",
                    AppUserId = "3"
                });

                //act
                var result = context.SportTickets.FirstOrDefault(x => x.TicketId.Equals(_sportTicketForTests));

                //assert
                Assert.NotNull(result);
                Assert.Equal("1", result.TicketId);
                Assert.Equal("2", result.SportComplexId);
                Assert.Equal("2", result.SportEventId);
                Assert.Equal("3", result.AppUserId);
                Assert.NotNull(result.SportComplex);
                Assert.NotNull(result.SportEvent);
                Assert.NotNull(result.AppUser);
            }

            TearDown();
        }

        [Fact]
        public void DeleteSportTicketFromDbTest()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.SportComplex.Add(_sportComplexForTests);
                context.SportEvents.Add(_sportEventForTests);
                context.AppUser.Add(_appUserForTests);
                context.SportTickets.Add(_sportTicketForTests);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var service = new SportTicketService(context);
                service.DeleteSportTicketFromDb(_sportTicketForTests);

                //act
                var result = context.SportTickets.FirstOrDefault(x => x.TicketId.Equals(_sportTicketForTests.TicketId));

                //assert
                Assert.Null(result);
            }
        }
    }
}