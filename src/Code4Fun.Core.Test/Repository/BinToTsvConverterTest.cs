using System.IO;
using System.Linq;
using Code4Fun.Core.Model;
using Code4Fun.Core.Repository;
using NUnit.Framework;

namespace Code4Fun.Core.Test.Repository
{
    public class BinToTsvConverterTest
    {
        private BinToTsvConverter _repository;
        private TsvFile _result;
        private const string LoadTestFile = @".\test.dat";

        [SetUp]
        public void SetUp()
        {
            if (File.Exists(LoadTestFile))
            {
                File.Delete(LoadTestFile);
            }

            using (var fileStream = new FileStream(LoadTestFile, FileMode.CreateNew))
            {
                using (var binaryWriter = new BinaryWriter(fileStream))
                {
                    binaryWriter.Write("num_connections\t65");
                    binaryWriter.Write("latency_ms\t70");
                    binaryWriter.Write("bandwidth\t20");
                }
            }

            _repository = new BinToTsvConverter(new BinToTsvFileAdapter());
            _result = _repository.Convert(LoadTestFile);
        }

        [Test]
        public void ShouldConvertBinaryToTsv()
        {
            Assert.IsNotNull(_result, "file should be loaded");
            Assert.AreEqual(3, _result.TsvLines.Count(), "tsv lines should be 3");
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(LoadTestFile))
            {
                File.Delete(LoadTestFile);
            }
        }
    }
}
