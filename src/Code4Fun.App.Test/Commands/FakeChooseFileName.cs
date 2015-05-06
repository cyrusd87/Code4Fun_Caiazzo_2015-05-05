using Code4Fun.App.Commands;

namespace Code4Fun.App.Test.Commands
{
    public class FakeChooseFileName : IChooserFileName
    {
        private readonly string _binaryFile;

        public FakeChooseFileName(string binaryFile)
        {
            _binaryFile = binaryFile;
        }

        public string Choose()
        {
            return _binaryFile;
        }
    }
}