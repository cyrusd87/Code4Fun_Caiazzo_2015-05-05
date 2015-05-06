using System.IO;
using Code4Fun.Core.Repository;
using Code4Fun.Core.Services;
using Code4Fun.Core.Test.Utilities;
using NUnit.Framework;

namespace Code4Fun.Core.Test.Services
{
    public class BinToTsvConverterServiceTest
    {
        private BinToTsvConverterService _sut;
        private FileRepository _fileRepository;
        private const string LoadTestFile = @".\test.dat";
        private const string SavedTestFile = @".\test.tsv";

        [SetUp]
        public void SetUp()
        {
            if (File.Exists(LoadTestFile))
            {
                File.Delete(LoadTestFile);
            }

            if (File.Exists(SavedTestFile))
            {
                File.Delete(SavedTestFile);
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

            _fileRepository = new FileRepository(new BinaryToTsvFileAdapter());
            _sut = new BinToTsvConverterService(_fileRepository);
        }

        [Test]
        public void ShouldConvertBinaryToTsv()
        {
            _sut.Convert(LoadTestFile);
            Assert.IsTrue(File.Exists(SavedTestFile), "tsv file was created");
        }

        [Test]
        public void LoadedAndConvertedFileShouldBeEqual()
        {
            var loaded = _fileRepository.LoadBinary(LoadTestFile);
            _sut.Convert(LoadTestFile);
            var converted = _fileRepository.LoadTsvFile(SavedTestFile);
            Assert.IsTrue(loaded.CompareTo(converted),"loaded and converted tsv should be equal");
        }
    }
}