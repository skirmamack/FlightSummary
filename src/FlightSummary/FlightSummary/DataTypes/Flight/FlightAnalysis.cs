namespace FlightSummary.DataTypes.Flight
{
    public class FlightAnalysis
    {
        public int TotalPassengerCount {get;set;}
        public int GeneralPassengerCount {get;set;}
        public int AirlinePassengerCount {get;set;}
        public int LoyaltyPassengerCount {get;set;}
        public int TotalNumberOfBags {get;set;}
        public int TotalLoyaltyPointsRedeemed {get;set;}
        public decimal TotalCostOfFlight {get;set;}
        public decimal TotalUnadjustedTicketRevenue {get;set;}
        public decimal TotalAdjustedRevenue {get;set;}
        public bool CanFlightProceed { get; set; }
        public string ErrorMessage { get; set; }

        public bool ErrorsFound
        {
            get { return !string.IsNullOrEmpty(ErrorMessage); }
        }
    }
}
