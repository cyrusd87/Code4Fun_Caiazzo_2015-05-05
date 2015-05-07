using System.Linq;
using Code4Fun.Core.Model;
using Code4Fun.Core.Repository;
using NUnit.Framework;

namespace Code4Fun.Core.Test.Repository
{
    public class BinaryToTsvFileAdapterTest
    {
        private string _testLine;
        private string _testMoreLines;
        private BinToTsvFileAdapter _sut;
        private TsvFile _tsvFileDeserializeResult;

        [SetUp]
        public void SetUp()
        {
            _testLine = "key\tvalue\n";
            _testMoreLines = "key1\tvalue1\nkey2\tvalue2\n";
            _sut = new BinToTsvFileAdapter();
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

        private void AssertLine(string key, string value,TsvLine resultLine)
        {
            Assert.AreEqual(key, resultLine.Key, "keys should be equal");
            Assert.AreEqual(value, resultLine.Value, "values should be equal");
        }

    }
}
