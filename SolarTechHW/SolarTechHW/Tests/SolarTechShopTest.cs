using NUnit.Framework.Internal;
using SolarTechHW.PageObjects;
using UiTestFixture;

namespace SolarTechHW.Tests
{
    internal class SolarTechShopTest : UITestFixture
    {
        private SolarTehchnologyShop SolarTehchnologyShop;

        [SetUp]
        public async Task SetupDemoQAPage()
        {
            SolarTehchnologyShop = new SolarTehchnologyShop(Page);
            await SolarTehchnologyShop.GoToSolarTehchnologyShopPage();

        }
        
        [Test]
        [Description("Test Filter Fields")]

        public async Task VerifyFilterCheckbox()
        {
            await SolarTehchnologyShop.GoToSolarPannels();
            await SolarTehchnologyShop.PressButtonFilterProducts();

            string[] properties = { "JA Solar", "Jinko Solar", "Полікристал", "60" };

            await SolarTehchnologyShop.VerifyItemsFilter(properties);


        }
        
    }
}
