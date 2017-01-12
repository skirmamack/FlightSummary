namespace FlightSummary.DataTypes.Flight
{
    public class Aircraft
    {
        public string Title { get; set; }
        public int NumberOfSeats { get; set; }
        public static Aircraft FromString(string routeString)
        {
            var segments = routeString.Split(' ');
            return new Aircraft()
            {
                Title = segments[0],
                NumberOfSeats = int.Parse(segments[1])
            };
        }
    }
}