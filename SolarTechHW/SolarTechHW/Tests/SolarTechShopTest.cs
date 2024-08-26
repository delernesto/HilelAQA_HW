using NUnit.Framework.Internal;
using SolarTechHW.PageObjects;
using UiTestFixture;

namespace SolarTechHW.Tests
{
    internal class SolarTechShopTest : UITestFixture
    {
        private SolarTehchnologyShop SolarTehchnologyShop;

        [SetUp]
        public async Task SetupSolarTehchnologyShopPage()
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
            // Arrange
            await SolarTehchnologyShop.GoToSolarPannels();

            // Act
            await SolarTehchnologyShop.PressButtonFilterProducts();
            await SolarTehchnologyShop.FilterItems(propertyname);

            // Assert
            await SolarTehchnologyShop.VerifyFilteredItems(propertyname);
        }

        [Test]
        [Description("Test Filter Fields of Solar Panels")]
        [TestCase("Deye")]
        [TestCase("Huawei")]
        [TestCase("Мережевий")]

        public async Task VerifyFilterCheckboxInventors(string propertyname)
        {
            await SolarTehchnologyShop.GoToInverters();
            await SolarTehchnologyShop.PressButtonFilterProducts();
            await SolarTehchnologyShop.FilterItems(propertyname);
            await SolarTehchnologyShop.VerifyFilteredItems(propertyname); 
        }

        [Test]
        [Description("Test Adding and deleting item of shopping cart ")]

        public async Task AddandDeleteProductsofShoppingCart()
        {
            await SolarTehchnologyShop.GoToInverters();
            await SolarTehchnologyShop.VerifyAnyItemsOnPage();
            await SolarTehchnologyShop.AddItemToShopCart();
            await SolarTehchnologyShop.VerifyAnyItemsInCart();
            await SolarTehchnologyShop.ClickDeleteItemFromShopCart();
            await SolarTehchnologyShop.VerrifyCartIsEmpty();
        }


        [Test]
        [Description("Verify that all products in main" +
            " page dispays corret name in quicklook and on product page ")]

        public async Task VerifyProductNamesAreIdentical()
        {
            await SolarTehchnologyShop.VerifyAnyItemsOnPage();
            await SolarTehchnologyShop.VerrifyClickedProductsNamesAreCorrect();
        }
    }
}