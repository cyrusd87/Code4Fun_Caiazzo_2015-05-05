using System.Linq;
using Code4Fun.Model;
using Code4Fun.Repository;
using NUnit.Framework;

namespace Code4FunTest.Repository
{
    public class BinaryToTsvFileAdapterTest
    {
        private string _testLine;
        private string _testMoreLines;
        private BinaryToTsvFileAdapter _sut;
        private ITsvFile _tsvFileResult;

        [SetUp]
        public void SetUp()
        {
            _testLine = "key\tvalue";
            _testMoreLines = "key1\tvalue1\nkey2\tvalue2";
            _sut = new BinaryToTsvFileAdapter();
        }

        [Test]
        public void ShouldDeserializeSingleLine()
        {
            _tsvFileResult = _sut.DeserializeTsv(_testLine);

            Assert.IsNotNull(_tsvFileResult,"Tsv file result should not be null");
            Assert.AreEqual(1,_tsvFileResult.TsvLines.Count(),"Tsv file should contain 1 line");
            AssertLine("key", "value", _tsvFileResult.TsvLines[0]);
        }

        [Test]
        public void ShouldDeserializeMoreLines()
        {
            _tsvFileResult = _sut.DeserializeTsv(_testMoreLines);

            Assert.IsNotNull(_tsvFileResult, "Tsv file result should not be null");
            Assert.AreEqual(2, _tsvFileResult.TsvLines.Count(), "Tsv file should contain 1 line");
            AssertLine("key1", "value1", _tsvFileResult.TsvLines[0]);
            AssertLine("key2", "value2", _tsvFileResult.TsvLines[1]);
        }


        private void AssertLine(string key, string value,ITsvLine resultLine)
        {
            Assert.AreEqual(key, resultLine.Key, "keys should be equal");
            Assert.AreEqual(value, resultLine.Value, "values should be equal");
        }

    }
}
