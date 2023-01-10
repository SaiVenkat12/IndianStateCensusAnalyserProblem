using IndianStateCensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA
        }

        Dictionary<string, CensusDTO> dataMap;

        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
