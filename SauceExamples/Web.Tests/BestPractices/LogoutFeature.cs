using FluentAssertions;
using NUnit.Framework;
using Web.Tests.Pages;


namespace Web.Tests.BestPractices
{
    [TestFixture]
    [TestFixtureSource(typeof(CrossBrowserData),
        nameof(CrossBrowserData.LastThreeOnLinuxFirefoxChrome))]
    [Parallelizable]
    public class LogoutFeature : BaseTest
    {
        public LogoutFeature(string browser, string version, string os) : 
            base(browser, version, os)
        {
        }
        [Test]
        public void ShouldBeAbleToLogOut()
        {
            var loginPage = new SauceDemoLoginPage(Driver);
            loginPage.Open();
            var productsPage = loginPage.Login("standard_user", "secret_sauce");
            productsPage.Logout();
            loginPage.IsLoaded.Should().BeTrue("we successfully logged out, so the login page should be visible");
        }
    }
}
