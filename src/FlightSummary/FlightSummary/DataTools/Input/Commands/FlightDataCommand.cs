using FlightSummary.DataTypes.Flight;

namespace FlightSummary.DataTools.Input.Commands
{
    public abstract class FlightDataCommand
    {
        public abstract string CommandName{get;}
        public abstract bool Process(FlightData data, string parameters);
    }
}