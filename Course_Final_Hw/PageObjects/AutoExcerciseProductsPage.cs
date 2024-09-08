using Microsoft.Playwright;


namespace Course_Final_Hw.PageObjects
{
    internal class AutoExcerciseProductsPage
    {
        private IPage page;
        private string AutoExcerciseProductsPageURL = "https://automationexercise.com/products";

        public AutoExcerciseProductsPage(IPage pagenew)
        {
            page = pagenew;
        }
        public async Task GoToAutoExcerciseProductsPage()
        {
            await page.GotoAsync(AutoExcerciseProductsPageURL);
        }
        public async Task SearchProduct(string productName)
        {
            await page.GetByPlaceholder("Search Product").ClickAsync();
            await page.GetByPlaceholder("Search Product").FillAsync(productName);
            await page.Locator("#submit_search").ClickAsync();

            await page.WaitForURLAsync("**/products?search*");
        }

        public async Task VerifyAnyProductsOnPage()
        {
            await Assertions.Expect(page.Locator(".single-products").First).ToBeVisibleAsync();
        }

        public async Task AddingProductsToCart(int productsAmount)
        {
            //Here we ensure amount of elements we want to check is not bigger then
            // the whole amount of elements  
            int count = await page.Locator(".single-products").CountAsync();
            Assert.That(count, Is.GreaterThanOrEqualTo(productsAmount));

            //Here we make step every 2 cause for some reason website have practically 2 copies of 
            //the same elements
            for (int i = 0; i < productsAmount*2; i+=2)
            {
                await page.Locator("[class*='add-to-cart']").Nth(i).ClickAsync();
                await page.GetByRole(AriaRole.Button, new() { Name = "Continue Shopping" }).ClickAsync();
            }
        }
    }
}
