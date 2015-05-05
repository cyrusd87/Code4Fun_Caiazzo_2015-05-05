namespace Code4Fun.Core.Model
{
    public class TsvLine : ITsvLine
    {
        public TsvLine(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; private set; }
        public string Value { get; private set; }
    }
}