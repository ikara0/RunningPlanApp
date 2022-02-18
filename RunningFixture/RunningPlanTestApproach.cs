using NUnit.Framework;

namespace RunningFixture
{
    [TestFixture]
    public class Fixtures
    {
        [TestCase(43.5, 28, 0, 45, 548.1)]
        [TestCase(52, 33, 1, 18,1338.48)]
        public void RunningCalcute_IsTrue(double stepDistance, double stepFreq, int runningHour, int runningMinute,double expected)
        {
            var result = Calculate.CalculateRunning(stepDistance, stepFreq, runningHour, runningMinute);

            Assert.AreEqual(result, expected);
        }
    }
}