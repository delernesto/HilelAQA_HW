using Microsoft.Playwright;
using NUnit.Framework;

namespace SolarTechHW.PageObjects
{
    internal class SolarTehchnologyShop
    {
        private IPage page;
        private string SolarTehchShopPageUrl = "https://solartechnology.com.ua/shop";

        public SolarTehchnologyShop(IPage pagenew)
        {
            page = pagenew;
        }
        public async Task GoToSolarTehchnologyShopPage()
        {
            await page.GotoAsync(SolarTehchShopPageUrl);
        }
        public async Task PressButtonFilterProducts()
        {
            await page.GetByText("Фільтр товарів").ClickAsync();
        }
        #region Pages
        public async Task GoToSolarPannels()
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Сонячні панелі" }).ClickAsync();
            await page.WaitForURLAsync("https://solartechnology.com.ua/shop/solar-panels");
        }
        public async Task GoToInverters()
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Інвертори" }).ClickAsync();
            await page.WaitForURLAsync("https://solartechnology.com.ua/shop/inverters");
        }

        public async Task GoToBatteries()
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Акумулятори" }).ClickAsync();
            await page.WaitForURLAsync("https://solartechnology.com.ua/shop/batteries");
        }

        public async Task GoToChargeControllers()
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Контролери заряду" }).ClickAsync();
            await page.WaitForURLAsync("https://solartechnology.com.ua/shop/charge-controllers");
        }

        public async Task GoToMountingSystems()
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Системи кріплення" }).ClickAsync();
            await page.WaitForURLAsync("https://solartechnology.com.ua/shop/mounting-systems");
        }

        public async Task GoToSolarCable()
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Кабель і комутація" }).ClickAsync();
            await page.WaitForURLAsync("https://solartechnology.com.ua/shop/solar-cable");
        }
        #endregion

        public async Task VerifyItemsFilter(string[] propertyname)
        {
            Assert.That(propertyname.Length > 0, "Filter array is empty");
            foreach (string name in propertyname)
            {
                var filterCheckbox = page.Locator(".card-content").Locator($"span:text-is(\"{name}\")");
                //var filterCheckbox = page.Locator(".checkbox").Filter(new() { HasText = name });
                await filterCheckbox.CheckAsync();
                await Assertions.Expect(filterCheckbox).ToBeCheckedAsync();

                var productLocator = page.Locator("[class*='prod-holder']").First;
                bool anyproducts = await productLocator.IsVisibleAsync();


                if (anyproducts)
                {
                    int count = await productLocator.CountAsync();
                    bool elementFound = false;
                    for (int i = 0; i < count; i++)
                    {
                        var product = productLocator.Nth(i);
                        bool isVisible = await product.Locator($"span:has-text(\"{name}\")").First.IsVisibleAsync();
                        if (isVisible)
                        {
                            elementFound = true;
                            break;
                        }
                    }
                    Assert.That(elementFound, $"No product matches the filter '{name}'");
                }
            }
        }
    }
}
