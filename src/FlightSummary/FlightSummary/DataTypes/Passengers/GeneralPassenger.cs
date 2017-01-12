namespace FlightSummary.DataTypes.Passengers
{
    public class GeneralPassenger : Passenger
    {
        public GeneralPassenger(string firstName, int age) : base(firstName, age)
        {
        }

        public override decimal CalculatePrice(decimal ticketPrice)
        {
            return ticketPrice;
        }
    }
}