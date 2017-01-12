using FlightSummary.DataTools;

namespace FlightSummary
{
    public class Program
    {
        static void Main(string[] args)
        {
            var flightAnalyser = new FlightFileAnalyser();
            flightAnalyser.Run(args[0]);
        }
    }
}
