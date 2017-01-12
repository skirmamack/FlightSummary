using FlightSummary.DataTypes.Flight;
using FlightSummary.DataTypes.Passengers;

namespace FlightSummary.DataTools.Input.Commands
{
    public class AddLoyaltyCommand : FlightDataCommand
    {
        public override string CommandName
        {
            get { return "add loyalty "; }
        }

        public override bool Process(FlightData data, string parameters)
        {
            var segments = parameters.Split(' ');
            var passenger = new LoyaltyMember(segments[0], int.Parse(segments[1]),
                int.Parse(segments[2]), segments[3] == "TRUE", segments[4] == "TRUE")
            {

            };
            data.Passengers.Add(passenger);
            return true;
        }
    }
}