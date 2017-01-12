using FlightSummary.DataTypes.Flight;
using FlightSummary.DataTypes.Passengers;

namespace FlightSummary.DataTools.Input.Commands
{
    public class AddAirlineCommand : FlightDataCommand
    {
        public override string CommandName
        {
            get { return "add airline "; }
        }

        public override bool Process(FlightData data, string parameters)
        {
            var segments = parameters.Split(' ');
            data.Passengers.Add(new AirlineEmployee(segments[0], int.Parse(segments[1])));
            return true;
        }
    }
}