using IndianStateCensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IndianStateCensusAnalyser.CensusAdapter;

namespace IndianStateCensusAnalyser
{
    public class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> dataMap;

        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeaders);
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
                string[] column = data.Split(",");
                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                    dataMap.Add(column[0], new CensusDTO(new StateCodeDAO(column[0], column[1], column[2], column[3])));
            }
            return dataMap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
