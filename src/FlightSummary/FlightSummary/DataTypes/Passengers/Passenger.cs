namespace FlightSummary.DataTypes.Passengers
{
    public abstract class Passenger
    {
        public string FirstName { get; set; }
        public int Age { get; set; }

        protected Passenger(string firstName, int age)
        {
            FirstName = firstName;
            Age = age;
        }

        public abstract decimal CalculatePrice(decimal ticketPrice);

        public virtual int NumberOfBags
        {
            get { return 1; }
        }
    }
}