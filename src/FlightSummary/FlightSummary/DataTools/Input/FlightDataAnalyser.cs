using System.Linq;
using FlightSummary.DataTypes.Flight;
using FlightSummary.DataTypes.Passengers;

namespace FlightSummary.DataTools.Input
{
    public class FlightDataAnalyser : IFlightDataAnalyser
    {
        public FlightAnalysis Analyse(FlightData data)
        {
            var result = new FlightAnalysis();
            if (data.ErrorsFound)
            {
                result.ErrorMessage = data.ErrorMessage;
                return result;
            }

            var loyaltyMembers = data.Passengers.OfType<LoyaltyMember>().ToList();

            result.TotalPassengerCount = data.Passengers.Count;
            result.GeneralPassengerCount = data.Passengers.Count(p => p is GeneralPassenger);
            result.AirlinePassengerCount = data.Passengers.Count(p => p is AirlineEmployee);
            result.LoyaltyPassengerCount = loyaltyMembers.Count;
            result.TotalNumberOfBags = data.Passengers.Sum(p => p.NumberOfBags);
            result.TotalLoyaltyPointsRedeemed = loyaltyMembers.Sum(p => p.LoyaltyPointsToRedeem(data.Route.TicketPrice));
            result.TotalCostOfFlight = result.TotalPassengerCount * data.Route.CostPerPassenger;
            result.TotalUnadjustedTicketRevenue = result.TotalPassengerCount * data.Route.TicketPrice;
            result.TotalAdjustedRevenue = data.Passengers.Sum(p => p.CalculatePrice(data.Route.TicketPrice));

            var percentage = (double)result.TotalPassengerCount / data.Aircraft.NumberOfSeats * 100;

            result.CanFlightProceed =
                result.TotalAdjustedRevenue > result.TotalCostOfFlight &&
                result.TotalPassengerCount <= data.Aircraft.NumberOfSeats &&
                percentage >= data.Route.MinimumTakeOffLoadPercentage;

            return result;
        }
    }
}