using Code4Fun.Core.Model;
using Code4Fun.Core.Services;
using NUnit.Framework;

namespace Code4Fun.Core.Test.Services
{
    public class AverageLatencyCalculatorServiceTest
    {
        private TsvFile _tsvFile1;
        private TsvFile _tsvFile2;
        private TsvFile _tsvFile3;

        [SetUp]
        public void SetUp()
        {
             _tsvFile1 = new TsvFile();
            _tsvFile1.AddLine(new TsvLine("latency_ms","80"));
            _tsvFile1.AddLine(new TsvLine("latency_ms","70"));
            _tsvFile1.AddLine(new TsvLine("latency_ms1","85"));

            _tsvFile2 = new TsvFile();
            _tsvFile2.AddLine(new TsvLine("latency_ms", "90"));
            _tsvFile2.AddLine(new TsvLine("latency_ms", "70"));
            _tsvFile2.AddLine(new TsvLine("latency_ms1", "85"));

            _tsvFile3 = new TsvFile();
            _tsvFile3.AddLine(new TsvLine("key","value"));
            
        }

        [Test]
        public void ShouldReturnZeroWhenNoLatenciesArePresent()
        {
            var sut = new AverageLatencyCalculatorService();
            Assert.AreEqual(0.0, sut.Calculate(new TsvFile[] { _tsvFile3 }), "should return 0 if no latency key are present");
        }

        [Test]
        public void ShouldReturnZeroWithEmptyTsvFile()
        {
            var sut = new AverageLatencyCalculatorService();
            Assert.AreEqual(0.0, sut.Calculate(new TsvFile[] { new TsvFile() }), "should return 0 if no tsv line are present");
        }

        [Test]
        public void ShouldReturnZeroWithEmptyTsvFilesArray()
        {
            var sut = new AverageLatencyCalculatorService();
            Assert.AreEqual(0.0, sut.Calculate(new TsvFile[0]), "should return 0 if tsv lines array has no entry");
        }

        [Test]
        public void ShouldCalculateAverageLatency()
        {
            var tsvFile = new TsvFile();
            tsvFile.AddLine(new TsvLine("key", "value"));
            var sut = new AverageLatencyCalculatorService();
            Assert.AreEqual(77.5, sut.Calculate(new TsvFile[] { _tsvFile1, _tsvFile2, _tsvFile3 }), "should return 0 if no latency key are present");
        }

    }
}
