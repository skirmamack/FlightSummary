using System.IO;

namespace FlightSummary.DataTools.Input
{
    public class DataFileReader : IDataFileReader
    {
        public string ReadFile(string fileName)
        {
            try
            {
                return File.ReadAllText(fileName);
            }
            catch
            {
                return null;
            }
        }
    }
}