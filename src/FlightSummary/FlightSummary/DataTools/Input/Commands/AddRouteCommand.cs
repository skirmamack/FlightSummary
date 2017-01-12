using FlightSummary.DataTypes.Flight;

namespace FlightSummary.DataTools.Input.Commands
{
    public class AddRouteCommand : FlightDataCommand
    {
        public override string CommandName
        {
            get { return "add route "; }
        }

        public override bool Process(FlightData data, string parameters)
        {
            if (data.Route != null)
            {
                data.ErrorMessage = Constants.MultipleRouteEntriesError;
                return false;
            }
            data.Route = Route.FromString(parameters);
            return true;
        }
    }
}