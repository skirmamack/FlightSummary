using FlightSummary.DataTypes.Flight;

namespace FlightSummary.DataTools.Input
{
    public interface IFlightDataAnalyser
    {
        FlightAnalysis Analyse(FlightData data);
    }
}