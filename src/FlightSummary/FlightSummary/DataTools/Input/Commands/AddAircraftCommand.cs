using FlightSummary.DataTypes.Flight;

namespace FlightSummary.DataTools.Input.Commands
{
    public class AddAircraftCommand : FlightDataCommand
    {
        public override string CommandName
        {
            get { return "add aircraft "; }
        }

        public override bool Process(FlightData data, string parameters)
        {
            if (data.Aircraft != null)
            {
                data.ErrorMessage = Constants.MultipleAircraftEntriesError;
                return false;
            }
            data.Aircraft = Aircraft.FromString(parameters);
            return true;
        }
    }
}