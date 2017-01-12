using System.Collections.Generic;
using System.Linq;
using FlightSummary.DataTools.Input.Commands;
using FlightSummary.DataTypes.Flight;

namespace FlightSummary.DataTools.Input
{
    public class FlightDataLoader : IFlightDataLoader
    {
        public IEnumerable<FlightDataCommand> Commands { get; set; }

        public FlightDataLoader()
        {
            Commands = new FlightDataCommand[]
            {
                new AddRouteCommand(),
                new AddAircraftCommand(),
                new AddGeneralCommand(),
                new AddAirlineCommand(), 
                new AddLoyaltyCommand()
            }.AsEnumerable();
        }

        public FlightData LoadFlightData(string dataString)
        {
            var data = new FlightData();
            foreach (var line in dataString.Split('\n'))
            {
                var lineToProcess = line.Replace("\r", "");
                if (!Process(data, lineToProcess))
                {
                    break;
                }
            }
            return data;
        }

        private bool Process(FlightData data, string line)
        {
            var command = Commands.FirstOrDefault(cmd => line.StartsWith(cmd.CommandName));
            if (command != null)
            {
                line = line.Remove(0, command.CommandName.Length);
                return command.Process(data, line);
            }

            data.ErrorMessage = Constants.UnknownCommand;
            return false;
        }
    }
}