using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Reports
{
    public class DataReport
    {
        public FRCDataCounts? Events { get; set; }
        public FRCDataCounts? Matches { get; set; }
        public FRCDataCounts? Teams { get; set; }

        public CountPerType? Templates { get; set; }

        public ScoutDataCounts? Scouts { get; set; }

        public class FRCDataCounts : TotalDataCounts
        {
            public int? Custom { get; set; }
            public int? Test { get; set; }
        }

        public class ScoutDataCounts : CountPerType
        {
            public Dictionary<string, int>? ByTeam { get; set; }
            public Dictionary<string, int>? ByEvent { get; set; }
        }
        public class CountPerType : TotalDataCounts
        {
            public Dictionary<string, int>? ByType { get; set; }
        }

        public class TotalDataCounts
        {
            public int? Total { get; set; }
        }
    }
}
