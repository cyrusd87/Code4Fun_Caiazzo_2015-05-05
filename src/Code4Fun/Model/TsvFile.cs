using System.Collections.Generic;

namespace Code4Fun.Model
{
    public class TsvFile : ITsvFile
    {
        private readonly List<ITsvLine> _tsvLines;
        public ITsvLine[] TsvLines { get { return _tsvLines.ToArray(); } }

        public TsvFile()
        {
            _tsvLines = new List<ITsvLine>();
        }

        public void AddLine(ITsvLine line)
        {
            _tsvLines.Add(line);
        }
    }
}