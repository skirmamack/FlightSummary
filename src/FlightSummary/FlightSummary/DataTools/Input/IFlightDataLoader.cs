using FlightSummary.DataTypes.Flight;

namespace FlightSummary.DataTools.Input
{
    public interface IFlightDataLoader
    {
        FlightData LoadFlightData(string dataString);
    }
}
