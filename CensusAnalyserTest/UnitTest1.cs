using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.POCO;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo, State Name, TIN, State Code";
        static string indianStateCensusFilePath = @"C:\Users\venky\source\IndianStateCensusAnalyser\CSVFiles\StateCensusData.csv";
        static string indianStateCodeFilePath = @"C:\Users\venky\source\IndianStateCensusAnalyser\CSVFiles\StateCode.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\venky\source\IndianStateCensusAnalyser\CSVFiles\wrongHeaderIndianCensus.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\venky\source\IndianStateCensusAnalyser\CSVFiles\wrongHeaderStateCode.csv";
        static string delimeterIndianCensusFilePath = @"C:\Users\venky\source\IndianStateCensusAnalyser\CSVFiles\delimeterIndianCensus.csv";
        static string delimeterIndianStateCodeFilePath = @"C:\Users\venky\source\IndianStateCensusAnalyser\CSVFiles\DelimeterIndianStateCode.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\venky\source\IndianStateCensusAnalyser\CSVFiles\StateCensusdatass.csv";
        static string wrongIndianStateCodeFilePath = @"C:\Users\venky\source\IndianStateCensusAnalyser\CSVFiles\StateCodedatass.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\venky\source\IndianStateCensusAnalyser\CSVFiles\wrongIndianStateCensus.txt";
        static string wrongIndianStateCodeFileType = @"C:\Users\venky\source\IndianStateCensusAnalyser\CSVFiles\wrongIndianStateCodeFileType.txt";
        IndianStateCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenDelimiterNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimeterIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimeterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}