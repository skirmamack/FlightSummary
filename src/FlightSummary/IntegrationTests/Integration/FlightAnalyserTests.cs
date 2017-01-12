using FlightSummary.DataTools;
using FlightSummary.DataTools.Input;
using FlightSummary.DataTools.Output;
using Moq;
using NUnit.Framework;
using Tests.Stubs;

namespace Tests.Integration
{
    public class FlightAnalyserTests
    {
        private const string FakeFileName = "something";

        private Mock<IDataFileReader> _dataFileReaderMock;
        private IFlightDataLoader _loader;
        private FlightDataAnalyser _flightDataAnalyser;
        private IResultFormatter _resultformatter;
        private ResultWriterStub _resultWritterStub;
        private FlightFileAnalyser _flightFileAnalyser;


        [SetUp]
        public void SetUp()
        {
            _dataFileReaderMock = new Mock<IDataFileReader>();
            _loader = new FlightDataLoader();
            _flightDataAnalyser = new FlightDataAnalyser();
            _resultformatter = new ResultFormatter();
            _resultWritterStub = new ResultWriterStub();
            _flightFileAnalyser = new FlightFileAnalyser(_dataFileReaderMock.Object, _loader, _flightDataAnalyser, _resultformatter, _resultWritterStub);
        }

        [TestCase(@"add route London Dublin 100 150 75
add aircraft Gulfstream-G550 8
add general Mark 35
add general Tom 15
add general James 72
add airline Trevor 54
add loyalty Alan 65 50 FALSE FALSE
add loyalty Susie 21 40 TRUE FALSE
add loyalty Joan 56 100 FALSE TRUE
add general Jack 50", "8 4 1 3 9 40 800 1200 1010 TRUE")]
        [TestCase(@"add route London Dublin 100 150 75
add aircraft Gulfstream-G550 12
add general Mark 35
add general Tom 15
add general James 72
add general Jack 50
add airline Jane 75
add general Steve 20", "6 5 1 0 6 0 600 900 750 FALSE")]
        public void should_do_analysis_correctly(string inputData, string expectedResult)
        {
            //given
            SetUpInputData(inputData);

            _resultWritterStub.Result = expectedResult;


            //when
            _flightFileAnalyser.Run(FakeFileName);

            //then
            Assert.That(_resultWritterStub.Result, Is.EqualTo(expectedResult));
        }

        private void SetUpInputData(string inputData)
        {
            _dataFileReaderMock
                .Setup(r => r.ReadFile(It.IsAny<string>()))
                .Returns(inputData);
        }
    }
}
