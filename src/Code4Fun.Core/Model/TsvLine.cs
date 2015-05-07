namespace Code4Fun.Core.Model
{
    public class TsvLine 
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