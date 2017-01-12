namespace FlightSummary.DataTypes.Flight
{
    public class Route
    {
        public string Origin { get;set; }
        public string Destination { get;set; }
        public decimal CostPerPassenger{get; set; }
        public decimal TicketPrice { get; set; }
        public double MinimumTakeOffLoadPercentage { get; set; }
        public static Route FromString(string routeString)
        {
            var segments = routeString.Split(' ');
            return new Route()
            {
                Origin = segments[0],
                Destination = segments[1],
                CostPerPassenger = decimal.Parse(segments[2]),
                TicketPrice = decimal.Parse(segments[3]),
                MinimumTakeOffLoadPercentage = double.Parse(segments[4])
            };
        }
    }
}