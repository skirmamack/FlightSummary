namespace FlightSummary.DataTypes.Passengers
{
    public class LoyaltyMember : Passenger
    {
        public int CurrentLoyaltyPoints { get;set; }
        public bool UsingLoyaltyPoints { get; set; }
        public bool UsingExtraBaggage { get; set; }
        public LoyaltyMember(string firstName, int age, int currentLoyaltyPoints,
            bool usingLoyaltyPoints, bool usingExtraBaggage)
            : base(firstName, age)
        {
            CurrentLoyaltyPoints = currentLoyaltyPoints;
            UsingLoyaltyPoints = usingLoyaltyPoints;
            UsingExtraBaggage = usingExtraBaggage;
        }

        public int LoyaltyPointsToRedeem(decimal ticketPrice)
        {
            if (!UsingLoyaltyPoints) return 0;
            return (CurrentLoyaltyPoints > ticketPrice) ? (int)ticketPrice : CurrentLoyaltyPoints;
        }

        public override decimal CalculatePrice(decimal ticketPrice)
        {
            if (!UsingLoyaltyPoints) return ticketPrice;
            return ticketPrice - LoyaltyPointsToRedeem(ticketPrice);
        }

        public override int NumberOfBags
        {
            get { return base.NumberOfBags + (UsingExtraBaggage ? 1 : 0); }
        }
    }
}