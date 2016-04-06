using NUnit.Framework;
using RichardSzalay.MockHttp;

namespace ModernDev.InTouch.Tests
{
    [TestFixture]
    public class BasicValuesTests
    {
        private InTouch _apiCLient;

        [OneTimeSetUp]
        public void TestSetup()
        {
            var mockHttp = new MockHttpMessageHandler();

            mockHttp.When("http://localost/api/user/*").Respond("application/json", "{'name' : 'Test McGee'}");

            _apiCLient = new InTouch(mockHttp, 1488, "superSecret");
        }

        [Test]
        public void TestBaseValues()
        {
            Assert.That(_apiCLient.Session, Is.Null);
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _apiCLient.Dispose();
        }
    }
}
