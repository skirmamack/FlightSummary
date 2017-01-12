using FlightSummary;
using FlightSummary.DataTools.Output;

namespace FlightSummaryTests.Stubs
{
    public class ResultWriterStub : IResultWriter
    {
        public string Result { get; set; }
        public void Write(string inputFileName, string result)
        {
            Result = result;
        }
    }
}