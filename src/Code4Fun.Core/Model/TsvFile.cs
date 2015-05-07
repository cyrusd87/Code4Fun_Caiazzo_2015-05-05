using System.Collections.Generic;

namespace Code4Fun.Core.Model
{
    public class TsvFile 
    {
        private readonly List<TsvLine> _tsvLines;
        public TsvLine[] TsvLines { get { return _tsvLines.ToArray(); } }

        public TsvFile()
        {
            _tsvLines = new List<TsvLine>();
        }

        public void AddLine(TsvLine line)
        {
            _tsvLines.Add(line);
        }
    }
}