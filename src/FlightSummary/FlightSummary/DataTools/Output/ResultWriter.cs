using System;
using System.IO;

namespace FlightSummary.DataTools.Output
{
    public class ResultWriter : IResultWriter
    {
        public void Write(string inputFileName, string result)
        {
            try
            {
                Console.WriteLine(result);
                var newFileName = inputFileName + ".out.txt";
                File.WriteAllText(newFileName, result);
                Console.WriteLine("Result file " + newFileName + " created successfully.");
            }
            catch
            {
                Console.WriteLine("Failed to write into file!");
            }
            finally
            {
                Console.WriteLine("Press enter.");
                Console.ReadLine();
            }
        }
    }
}