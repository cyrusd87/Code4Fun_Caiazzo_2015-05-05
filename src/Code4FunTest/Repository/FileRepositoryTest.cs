using System.IO;
using Code4Fun.Repository;
using NUnit.Framework;

namespace Code4FunTest.Repository
{
    public class FileRepositoryTest
    {
        private FileRepository _repository;
        private const string TestFile = @".\test.dat";

        [SetUp]
        public void SetUp()
        {
            using (var fileStream = new FileStream(TestFile, FileMode.CreateNew))
            {
                using (var binaryWriter = new BinaryWriter(fileStream))
                {
                    binaryWriter.Write("num_connections\t65");
                    binaryWriter.Write("latency_ms\t70");
                    binaryWriter.Write("bandwidth\t20");
                }
            }

            _repository = new FileRepository(new BinaryToTsvFileAdapter());
        }

        [Test]
        public void ShouldLoadBinaryFile()
        {
            var result = _repository.Load(@".\test.dat");

            Assert.IsNotNull(result,"file should be loaded");
        }

        [Test]
        public void ShouldSaveTsvFile()
        {
            var loadedBinaryFile = _repository.Load(@".\test.dat");
            _repository.Save(loadedBinaryFile);
            
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(TestFile))
            {
                File.Delete(TestFile);
            }
        }
    }
}
