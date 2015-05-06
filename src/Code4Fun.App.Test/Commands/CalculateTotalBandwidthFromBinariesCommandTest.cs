using System;
using System.IO;
using Code4Fun.App.Commands;
using Code4Fun.App.Presenters;
using Code4Fun.Core.Repository;
using Code4Fun.Core.Services;
using Moq;
using NUnit.Framework;

namespace Code4Fun.App.Test.Commands
{
    public class CalculateTotalBandwidthFromBinariesCommandTest
    {
        private const string TestPath = @"..\..\..\..\test-baselines";
        private const string InvalidPath = @"..\..\..\..\test-baselines\invalidPath";

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
        public void ShouldNotifyErrorWhenDirectoryNotExist()
        {
            _mockPresenter.Setup(x => x.NotifyError(It.IsAny<Exception>()));
            var calculatorResultPresenter = new FakeResultPresenter();
            var sut = new CalculateTotalBandwidthFromBinariesCommand(new FileRepository(new BinaryToTsvFileAdapter()), new FakeChooseDirectoryName(InvalidPath), new TotalBandWidthCalculatorService(), calculatorResultPresenter, _mockPresenter.Object);
            sut.Execute(null);
        }

        [Test]
        public void ShouldNotifySuccess()
        {
            _mockPresenter.Setup(x => x.Notify(It.IsAny<string>()));
            var calculatorResultPresenter = new FakeResultPresenter();
            var sut = new CalculateTotalBandwidthFromBinariesCommand(new FileRepository(new BinaryToTsvFileAdapter()), new FakeChooseDirectoryName(TestPath), new TotalBandWidthCalculatorService(), calculatorResultPresenter, _mockPresenter.Object);
            sut.Execute(null);
            Assert.AreEqual("42", calculatorResultPresenter.TotalBandWidthText, "expected and actual average should be equal");
        }


        [TearDown]
        public void TearDown()
        {
            _mockRepository.VerifyAll();


            foreach (var file in Directory.GetFiles(TestPath))
            {
                if (Path.GetExtension(file) == ".tsv")
                {
                    File.Delete(file);
                }
            }
        }
    }
}
