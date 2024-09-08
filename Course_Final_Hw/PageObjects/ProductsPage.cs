using Microsoft.Playwright;


namespace Course_Final_Hw.PageObjects
{
    internal class ProductsPage
    {
        private IPage page;
        private string AutoExcerciseProductsPageURL = "https://automationexercise.com/products";

        public ProductsPage(IPage pagenew)
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

        public async Task VerifyAmountIsLessThanWholeAmount(int productsAmount)
        {
            int count = await page.Locator(".single-products").CountAsync();
            Assert.That(count, Is.GreaterThanOrEqualTo(productsAmount));

        }

        public async Task AddProductToCart(int productnumber)
        {
            await page.Locator("[class*='add-to-cart']").Nth(productnumber*2).ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { Name = "Continue Shopping" }).ClickAsync();
        }
    }
}

