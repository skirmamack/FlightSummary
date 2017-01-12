namespace FlightSummary.DataTools.Output
{
    public interface IResultWriter
    {
        void Write(string inputFileName, string result);
    }
}