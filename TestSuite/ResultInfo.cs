using System.Collections.Generic;

namespace TestSuite
{
    public class ResultInfo
    {
        public int TotalTests { get; set; }
        public int TestsPassed { get; set; }
        public int TestsFailed { get; set; }
        public int TestsNotRun { get; set; }
        public IEnumerable<TestInfo> TestInfo { get; set; }
    }
}
