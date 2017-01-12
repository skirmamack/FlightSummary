using System.Collections.Generic;
using FlightSummary.DataTools.Input;
using FlightSummary.DataTypes.Flight;
using FlightSummary.DataTypes.Passengers;
using NUnit.Framework;

namespace Tests.Unit
{
    [TestFixture]
    public class FlightDataAnalyserTests
    {
        private FlightDataAnalyser _flightDataAnalyser;


        [SetUp]
        public void SetUp()
        {
            _flightDataAnalyser = new FlightDataAnalyser();
        }
       
        [Test]
        public void CanFlightProceed_should_be_TRUE_when_revenue_exceeds_cost()
        {
            //given
            const int costPerPerson = 100;
            const int ticketPrice = 110;
            var data = CreateTestFlightData(costPerPerson, ticketPrice);

            //when
            var result = _flightDataAnalyser.Analyse(data);

            //then
            Assert.True(result.CanFlightProceed);
        }

        [Test]
        public void CanFlightProceed_should_be_FALSE_when_cost_exceeds_revenue()
        {
            //given
            const int costPerPerson = 120;
            const int ticketPrice = 110;
            var data = CreateTestFlightData(costPerPerson, ticketPrice);

            //when
            var result = _flightDataAnalyser.Analyse(data);

            //then
            Assert.False(result.CanFlightProceed);
        }

        [Test]
        public void CanFlightProceed_should_be_TRUE_when_enough_seats()
        {
            //given
            const int costPerPerson = 100;
            const int ticketPrice = 110;
            const int numberOfSeats = 2;
            var data = CreateTestFlightData(costPerPerson, ticketPrice, numberOfSeats);

            //when
            var result = _flightDataAnalyser.Analyse(data);

            //then
            Assert.True(result.CanFlightProceed);
        }

        [Test]
        public void CanFlightProceed_should_be_FALSE_when_not_enough_seats()
        {
            //given
            const int costPerPerson = 100;
            const int ticketPrice = 110;
            const int numberOfSeats = 0;
            var data = CreateTestFlightData(costPerPerson, ticketPrice, numberOfSeats);

            //when
            var result = _flightDataAnalyser.Analyse(data);

            //then
            Assert.False(result.CanFlightProceed);
        }

        [Test]
        public void CanFlightProceed_should_be_FALSE_when_takeoff_load_percentage_enough()
        {
            //given
            const int costPerPerson = 100;
            const int ticketPrice = 110;
            const int numberOfSeats = 2;
            const int minimumTakeOffPercentage = 50;
            var data = CreateTestFlightData(costPerPerson, ticketPrice, numberOfSeats, minimumTakeOffPercentage);

            //when
            var result = _flightDataAnalyser.Analyse(data);

            //then
            Assert.True(result.CanFlightProceed);
        }

        [Test]
        public void CanFlightProceed_should_be_FALSE_when_takeoff_load_percentage_too_low()
        {
            //given
            const int costPerPerson = 100;
            const int ticketPrice = 110;
            const int numberOfSeats = 2;
            const int minimumTakeOffPercentage = 75;
            var data = CreateTestFlightData(costPerPerson, ticketPrice, numberOfSeats, minimumTakeOffPercentage);

            //when
            var result = _flightDataAnalyser.Analyse(data);

            //then
            Assert.False(result.CanFlightProceed);
        }

        private static FlightData CreateTestFlightData(decimal costPerPerson, int ticketPrice, int numberofSeats = int.MaxValue, double minimumTakeOffPercentage = 0)
        {
            return new FlightData()
            {
                Aircraft = new Aircraft() {NumberOfSeats = numberofSeats},
                Route = new Route()
                {
                    CostPerPassenger = costPerPerson,
                    TicketPrice = ticketPrice,
                    MinimumTakeOffLoadPercentage = minimumTakeOffPercentage
                },
                Passengers = new List<Passenger>()
                {
                    new GeneralPassenger("Skirma", 34)
                }
            };
        }
    }
}
