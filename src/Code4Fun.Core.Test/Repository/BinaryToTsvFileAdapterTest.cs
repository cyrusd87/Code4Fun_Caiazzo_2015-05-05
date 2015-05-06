using System.Linq;
using System.Text;
using Code4Fun.Core.Model;
using Code4Fun.Core.Repository;
using NUnit.Framework;

namespace Code4Fun.Core.Test.Repository
{
    public class BinaryToTsvFileAdapterTest
    {
        private string _testLine;
        private string _testMoreLines;
        private BinaryToTsvFileAdapter _sut;
        private ITsvFile _tsvFileDeserializeResult;
        private ITsvFile _tsvFile;

        [SetUp]
        public void SetUp()
        {
            _testLine = "key\tvalue\n";
            _testMoreLines = "key1\tvalue1\nkey2\tvalue2\n";
            _sut = new BinaryToTsvFileAdapter();

            _tsvFile = new TsvFile();
        }

        [Test]
        public void ShouldDeserializeSingleLine()
        {
            _tsvFileDeserializeResult = _sut.DeserializeTsv(_testLine);

            Assert.IsNotNull(_tsvFileDeserializeResult,"Tsv file result should not be null");
            Assert.AreEqual(1,_tsvFileDeserializeResult.TsvLines.Count(),"Tsv file should contain 1 line");
            AssertLine("key", "value", _tsvFileDeserializeResult.TsvLines[0]);
        }

        [Test]
        public void ShouldDeserializeMoreLines()
        {
            _tsvFileDeserializeResult = _sut.DeserializeTsv(_testMoreLines);

            Assert.IsNotNull(_tsvFileDeserializeResult, "Tsv file result should not be null");
            Assert.AreEqual(2, _tsvFileDeserializeResult.TsvLines.Count(), "Tsv file should contain 1 line");
            AssertLine("key1", "value1", _tsvFileDeserializeResult.TsvLines[0]);
            AssertLine("key2", "value2", _tsvFileDeserializeResult.TsvLines[1]);
        }

        [Test]
        public void ShouldSerializeTsvWithEmptyLine()
        {
            var tsvFileSerializeResult = _sut.SerializeTsv(_tsvFile);
            Assert.AreEqual(string.Empty, tsvFileSerializeResult,"without line serialized content should be empty");
        }
        
        [TestCase("ShouldSerializeTsvWithSingleLine", new[]{"key\tvalue" })]
        [TestCase("ShouldSerializeTsvWithMoreLines", new[] { "key1\tvalue1","key2\tvalue2"})]
        public void ShouldSerializeTsv(string testCase,string[] lines)
        {
            var tsvFile = new TsvFile();
            var expectedResult = new StringBuilder();
            foreach (var line in lines)
            {
                var splittedline = line.Split('\t');

                tsvFile.AddLine(new TsvLine(splittedline[0], splittedline[1]));
                expectedResult.AppendLine(line.Trim());
            }
            var serialized = _sut.SerializeTsv(tsvFile);
            Assert.AreEqual(expectedResult.ToString().Replace("\r",""),serialized,string.Format("{0}: Expected and actual serialized should be equal",testCase));

        }

        [Test]
        public void DeserializedAndSerializedTsvFileShouldBeEqual()
        {
            _tsvFileDeserializeResult = _sut.DeserializeTsv(_testMoreLines);
            var serialized = _sut.SerializeTsv(_tsvFileDeserializeResult);
            Assert.AreEqual(_testMoreLines, serialized, "original and serialized tsv should be equal");
        }

        private void AssertLine(string key, string value,ITsvLine resultLine)
        {
            Assert.AreEqual(key, resultLine.Key, "keys should be equal");
            Assert.AreEqual(value, resultLine.Value, "values should be equal");
        }

    }
}
