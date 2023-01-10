using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser.POCO
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;

        public CensusDTO(StateCodeDAO stateCodeData)
        {
            this.stateName = stateCodeData.stateName;
            this.serialNumber = stateCodeData.serialNumber;
            this.tin = stateCodeData.tin;
            this.stateCode = stateCodeData.stateCode;
        }
    }
}
