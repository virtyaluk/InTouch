using NUnit.Framework;
using System.Threading.Tasks;
using static NUnit.Framework.Assert;

namespace ModernDev.InTouch.Tests
{
    [TestFixture]
    public class UsersMethodsTest
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("users");
        }

        [Test]
        public async Task Get()
        {
            var resp = await _inTouch.Users.Get();

            IsFalse(resp.IsError);
            IsNotEmpty(resp.Data);
            IsNotNull(resp.Data[0]);
        }

        [Test]
        public async Task IsAppUser()
        {
            var resp = await _inTouch.Users.IsAppUser();
            
            IsFalse(resp.IsError);
            IsTrue(resp.Data);
        }

        [Test]
        public async Task Report()
        {
            var resp = await _inTouch.Users.Report(2, ReportTypes.Porn);

            IsFalse(resp.IsError);
            IsFalse(resp.Data);
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch?.Dispose();
        }
    }
}
