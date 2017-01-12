using FlightSummary.DataTypes.Flight;

namespace FlightSummary.DataTools.Output
{
    public interface IResultFormatter
    {
        string Format(FlightAnalysis flightAnalysis);
    }
}