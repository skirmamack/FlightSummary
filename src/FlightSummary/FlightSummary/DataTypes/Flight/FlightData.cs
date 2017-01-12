using System.Collections.Generic;
using FlightSummary.DataTypes.Passengers;

namespace FlightSummary.DataTypes.Flight
{
    public class FlightData
    {
        public Route Route{ get; set; }
        public Aircraft Aircraft { get; set; }
        public List<Passenger> Passengers { get; set; }
        public string ErrorMessage { get; set; }
        public bool ErrorsFound
        {
            get { return !string.IsNullOrEmpty(ErrorMessage); }
        }
        public FlightData()
        {
            Passengers = new List<Passenger>();
        }
    }
}
