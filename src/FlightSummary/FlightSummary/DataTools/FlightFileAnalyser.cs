using FlightSummary.DataTools.Input;
using FlightSummary.DataTools.Output;

namespace FlightSummary.DataTools
{
    public class FlightFileAnalyser
    {
        private readonly IDataFileReader _dataFileReader;
        private readonly IFlightDataLoader _loader;
        private readonly IFlightDataAnalyser _analyser;
        private readonly IResultFormatter _resultFormatter;
        private readonly IResultWriter _resultWriter;

        public FlightFileAnalyser() : this(new DataFileReader(), new FlightDataLoader(), new FlightDataAnalyser(), new ResultFormatter(), new ResultWriter())
        {
            
        }

        public FlightFileAnalyser(IDataFileReader dataFileReader, IFlightDataLoader loader, IFlightDataAnalyser analyser, IResultFormatter resultFormatter, IResultWriter resultWriter)
        {
            _dataFileReader = dataFileReader;
            _loader = loader;
            _analyser = analyser;
            _resultFormatter = resultFormatter;
            _resultWriter = resultWriter;
        }

        public void Run(string fileName)
        {
            var fullFileName = Constants.DataFolderName + "\\" + fileName;
            var dataString = _dataFileReader.ReadFile(fullFileName);
            string resultString;
            if (dataString == null)
            {
                resultString = "Failed to read file";
            }
            else
            {
                
                var flightData = _loader.LoadFlightData(dataString);
                var flightAnalysis = _analyser.Analyse(flightData);
                resultString = _resultFormatter.Format(flightAnalysis);
            }

            _resultWriter.Write(fullFileName, resultString);
        }
    }
}
