
using System.Net;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{

    [TestFixture]
    class InstallerHelperTests
    {
        private InstallerHelper _installerHelper;
        private Mock<IFileDownloader> _fileDownloader;

        [SetUp]
        public void setUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_DownlodFails_ReturnFalse()
        {
            _fileDownloader.Setup(fd => 
                fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();
            var result = _installerHelper.DownloadInstaller("Customer", "installer");

            Assert.That(result,Is.False);
        }

        [Test]
        public void DownloadInstaller_DownlodCompletes_ReturnTrue()
        {
      
            var result = _installerHelper.DownloadInstaller("Customer", "installer");

            Assert.That(result, Is.True);
        }
    }
}
