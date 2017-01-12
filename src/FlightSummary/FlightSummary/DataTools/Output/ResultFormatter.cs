using System;
using FlightSummary.DataTypes.Flight;

namespace FlightSummary.DataTools.Output
{
    public class ResultFormatter : IResultFormatter
    {
        public string Format(FlightAnalysis flightAnalysis)
        {
            if (flightAnalysis.ErrorsFound)
            {
                return flightAnalysis.ErrorMessage;
            }
            return String.Format(
                "{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
                flightAnalysis.TotalPassengerCount,
                flightAnalysis.GeneralPassengerCount,
                flightAnalysis.AirlinePassengerCount,
                flightAnalysis.LoyaltyPassengerCount,
                flightAnalysis.TotalNumberOfBags,
                flightAnalysis.TotalLoyaltyPointsRedeemed,
                flightAnalysis.TotalCostOfFlight,
                flightAnalysis.TotalUnadjustedTicketRevenue,
                flightAnalysis.TotalAdjustedRevenue,
                flightAnalysis.CanFlightProceed ? "TRUE" : "FALSE");
        }
    }
}