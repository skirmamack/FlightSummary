using FlightSummary.DataTypes.Flight;
using FlightSummary.DataTypes.Passengers;

namespace FlightSummary.DataTools.Input.Commands
{
    public class AddGeneralCommand : FlightDataCommand
    {
        public override string CommandName
        {
            get { return "add general "; }
        }

        public override bool Process(FlightData data, string parameters)
        {
            var segments = parameters.Split(' ');
            data.Passengers.Add(new GeneralPassenger(segments[0], int.Parse(segments[1])));
            return true;
        }
    }
}