using System.IO;
using Code4Fun.Model;
using Code4Fun.Repository;
using Code4FunTest.Utilities;
using NUnit.Framework;

namespace Code4FunTest.Repository
{
    public class FileRepositoryTest
    {
        private FileRepository _repository;
        private const string LoadTestFile = @".\test.dat";
        private const string SaveTestFile = @".\savedTest.tsv";

        [SetUp]
        public void SetUp()
        {
            if (File.Exists(LoadTestFile))
            {
                File.Delete(LoadTestFile);
            }
            
            if (File.Exists(SaveTestFile))
            {
                File.Delete(SaveTestFile);
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

            _repository = new FileRepository(new BinaryToTsvFileAdapter());
        }

        [Test]
        public void ShouldLoadBinaryFile()
        {
            var result = _repository.LoadBinary(LoadTestFile);

            Assert.IsNotNull(result,"file should be loaded");
        }

        [Test]
        public void ShouldSaveTsvFile()
        {
            var tsvFile = new TsvFile();
            tsvFile.AddLine(new TsvLine("key1","value1"));
            tsvFile.AddLine(new TsvLine("key2","value2"));
            _repository.Save(tsvFile,SaveTestFile);
            Assert.IsTrue(File.Exists(SaveTestFile),"tsv file should be created");
        }


        [Test]
        public void LoadBinaryAndSavedTsvAreIdentical()
        {
            var loaded = _repository.LoadBinary(LoadTestFile);
            _repository.Save(loaded,SaveTestFile);

            var saved = _repository.LoadTsvFile(SaveTestFile);

            Assert.IsTrue(loaded.CompareTo(saved),"loaded and saved tsvFile should be identical");
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(LoadTestFile))
            {
                File.Delete(LoadTestFile);
            }


            if (File.Exists(SaveTestFile))
            {
                File.Delete(SaveTestFile);
            }
        }
    }
}
