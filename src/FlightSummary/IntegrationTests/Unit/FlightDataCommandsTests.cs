using FlightSummary;
using FlightSummary.DataTools.Input;
using NUnit.Framework;

namespace Tests.Unit
{
    [TestFixture]
    public class FlightDataCommandsTests
    {
        private FlightDataLoader _loader;

        [SetUp]
        public void SetUp()
        {
            _loader = new FlightDataLoader();
        }

        [Test]
        public void should_return_multiple_route_entries_error()
        {
            //given

            //when
            var flightData = _loader.LoadFlightData(@"add route London Dublin 100 150 75
add route London Dublin 100 150 75");

            //then
            Assert.That(flightData.ErrorMessage, Is.EqualTo(Constants.MultipleRouteEntriesError));
        }

        [Test]
        public void should_return_multiple_aircraft_entries_error()
        {
            //given
            
            //when
            var flightData = _loader.LoadFlightData(@"add aircraft Gulfstream-G550 8
add aircraft Gulfstream-G550 8");

            //then
            Assert.That(flightData.ErrorMessage, Is.EqualTo(Constants.MultipleAircraftEntriesError));
        }
    }
}
