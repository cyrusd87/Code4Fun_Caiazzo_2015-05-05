using System;
using System.IO;
using Code4Fun.App.Commands;
using Code4Fun.App.Presenters;
using Code4Fun.Core.Repository;
using Moq;
using NUnit.Framework;

namespace Code4Fun.App.Test.Commands
{
    public class ConvertBinaryToTsvCommandTest
    {
        private const string TestPath = @"..\..\..\..\test-baselines";
        private const string BinaryFile = @"..\..\..\..\test-baselines\binary1.dat";

        private MockRepository _mockRepository;
        private Mock<IPresenter> _mockPresenter;

        [SetUp]
        public void SetUp()
        {
            foreach (var file in Directory.GetFiles(TestPath))
            {
                if (Path.GetExtension(file) == ".tsv")
                {
                    File.Delete(file);
                }
            }

            _mockRepository = new MockRepository(MockBehavior.Strict);
            _mockPresenter = _mockRepository.Create<IPresenter>();
        }

        [Test]
        public void ShouldNotifyErrorWhenFileNotExist()
        {
            _mockPresenter.Setup(x => x.NotifyError(It.IsAny<Exception>()));
            var sut = new ConvertBinaryToTsvCommand(new FileRepository(new BinaryToTsvFileAdapter()), new FakeChooseFileName(Path.Combine(TestPath, "invalidFile.dat")),_mockPresenter.Object);
            sut.Execute(null);
        }

        [Test]
        public void ShouldNotifySuccess()
        {
            _mockPresenter.Setup(x => x.Notify(It.IsAny<string>()));
            var sut = new ConvertBinaryToTsvCommand(new FileRepository(new BinaryToTsvFileAdapter()), new FakeChooseFileName(BinaryFile), _mockPresenter.Object);
            sut.Execute(null);
        }


        [TearDown]
        public void TearDown()
        {
            _mockRepository.VerifyAll();
        }
    }
}
