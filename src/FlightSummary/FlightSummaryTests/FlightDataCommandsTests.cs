using FlightSummary;
using FlightSummary.Commands;
using FlightSummary.DataTypes;
using FlightSummary.DataTypes.Flight;
using NUnit.Framework;

namespace FlightSummaryTests
{
    [TestFixture]
    public class FlightDataCommandsTests
    {
        private FlightDataCommandsProcessor _commandsProcessor;
        private FlightAnalysis _analysis;
        private FlightData _flightData;

        [SetUp]
        public void SetUp()
        {
            _flightData = new FlightData();
            _commandsProcessor = new FlightDataCommandsProcessor();
            _analysis = new FlightAnalysis();
        }

        [Test]
        public void should_return_multiple_route_entries_error()
        {
            //given
            _flightData.Route = new Route();

            //when
            _commandsProcessor.Process(_flightData, _analysis, @"add route London Dublin 100 150 75
add route London Dublin 100 150 75");

            //then
            Assert.That(_analysis.ErrorMessage, Is.EqualTo(Constants.MultipleRouteEntriesError));
        }

        [Test]
        public void should_return_multiple_aircraft_entries_error()
        {
            //given
            _flightData.Aircraft = new Aircraft();

            //when
            _commandsProcessor.Process(_flightData, _analysis, @"add aircraft Gulfstream-G550 8
add aircraft Gulfstream-G550 8");

            //then
            Assert.That(_analysis.ErrorMessage, Is.EqualTo(Constants.MultipleAircraftEntriesError));
        }
    }
}
