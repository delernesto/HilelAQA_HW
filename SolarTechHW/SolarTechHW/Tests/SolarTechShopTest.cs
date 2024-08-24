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
        [Description("Test Filter Fields of Solar Panels")]
        [TestCase("JA Solar")]
        [TestCase("Jinko Solar")]
        [TestCase("Полікристал")]
        [TestCase("60")]
        public async Task VerifyFilterCheckboxSolarPanels(string propertyname)
        {
            await SolarTehchnologyShop.GoToSolarPannels();
            await SolarTehchnologyShop.PressButtonFilterProducts();
            await SolarTehchnologyShop.VerifyItemsFilter(propertyname);
        }

        [Test]
        [Description("Test Filter Fields of Solar Panels")]
        [TestCase("Deye")]
        [TestCase("Huawei")]
        [TestCase("Мережевий")]
        
        public async Task VerifyFilterCheckboxInventors(string propertyname)
        {
            await SolarTehchnologyShop.GoToSolarPannels();
            await SolarTehchnologyShop.GoToInverters();
            await SolarTehchnologyShop.PressButtonFilterProducts();
            await SolarTehchnologyShop.VerifyItemsFilter(propertyname);

        }
    }
}
