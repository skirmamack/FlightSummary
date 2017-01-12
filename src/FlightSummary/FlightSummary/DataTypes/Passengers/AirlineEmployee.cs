namespace FlightSummary.DataTypes.Passengers
{
    public class AirlineEmployee : Passenger
    {
        public AirlineEmployee(string firstName, int age) : base(firstName, age)
        {
        }

        public override decimal CalculatePrice(decimal ticketPrice)
        {
            return 0;
        }
    }
}