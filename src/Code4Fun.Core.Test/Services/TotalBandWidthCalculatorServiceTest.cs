using Code4Fun.Core.Model;
using Code4Fun.Core.Services;
using NUnit.Framework;

namespace Code4Fun.Core.Test.Services
{
    public class TotalBandWidthCalculatorServiceTest
    {
        private TsvFile _tsvFile1;
        private TsvFile _tsvFile2;
        private TsvFile _tsvFile3;

        [SetUp]
        public void SetUp()
        {
            _tsvFile1 = new TsvFile();
            _tsvFile1.AddLine(new TsvLine("bandwidth", "80"));
            _tsvFile1.AddLine(new TsvLine("bandwidth", "70"));
            _tsvFile1.AddLine(new TsvLine("latency_ms1", "85"));

            _tsvFile2 = new TsvFile();
            _tsvFile2.AddLine(new TsvLine("bandwidth", "90"));
            _tsvFile2.AddLine(new TsvLine("bandwidth", "70"));
            _tsvFile2.AddLine(new TsvLine("latency_ms1", "85"));

            _tsvFile3 = new TsvFile();
            _tsvFile3.AddLine(new TsvLine("key", "value"));

        }

        [Test]
        public void ShouldReturnZeroWhenNoBandwidthArePresent()
        {
            var sut = new TotalBandWidthCalculatorService();
            Assert.AreEqual(0.0, sut.Calculate(new ITsvFile[] { _tsvFile3 }), "should return 0 if no latency key are present");
        }

        [Test]
        public void ShouldReturnZeroWithEmptyTsvFile()
        {
            var sut = new TotalBandWidthCalculatorService();
            Assert.AreEqual(0.0, sut.Calculate(new ITsvFile[] { new TsvFile() }), "should return 0 if no tsv line are present");
        }

        [Test]
        public void ShouldReturnZeroWithEmptyTsvFilesArray()
        {
            var sut = new TotalBandWidthCalculatorService();
            Assert.AreEqual(0.0, sut.Calculate(new ITsvFile[0]), "should return 0 if tsv lines array has no entry");
        }

        [Test]
        public void ShouldCalculateSumBandWidth()
        {
            var tsvFile = new TsvFile();
            tsvFile.AddLine(new TsvLine("key", "value"));
            var sut = new TotalBandWidthCalculatorService();
            Assert.AreEqual(310, sut.Calculate(new ITsvFile[] { _tsvFile1, _tsvFile2, _tsvFile3 }), "should return 0 if no latency key are present");
        }
    }
}
