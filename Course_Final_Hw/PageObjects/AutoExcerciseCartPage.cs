using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;


namespace Course_Final_Hw.PageObjects
{
    internal class AutoExcerciseCartPage
    {
        private IPage page;
        private string AutoExcerciseCartPageURL = "https://automationexercise.com/view_cart";

        public AutoExcerciseCartPage(IPage pagenew)
        {
            page = pagenew;
        }
        public async Task GoToAutoExcerciseCartPage()
        {
            await page.GotoAsync(AutoExcerciseCartPageURL);
        }

        public async Task VerifyAnyPrductsInCart()
        {
            await Assertions.Expect(page.Locator("[id*='product-']").First).ToBeVisibleAsync();
        }
        public async Task<int> CountAmountOfProducts()
        {
            int count = await page.Locator("[id*='product-']").CountAsync();
            int amountOfProducts = 0;

            for (int i = 0; i < count; i++)
            {
                //Here we count how many items we added of each product
                //( in case we added more then one same item )
                string amountOfItem = await page.Locator(".cart_quantity").Nth(i).InnerTextAsync();
                amountOfProducts += int.Parse(amountOfItem);
            }

            Assert.That(amountOfProducts, Is.GreaterThanOrEqualTo(0));

            return amountOfProducts;
        }
        public async Task RemoveProduct()
        {
          
            int count = await page.Locator("[id*='product-']").CountAsync();
            for (int i = 0; i < count; i++)
            {
                await page.Locator(".cart_quantity_delete").First.ClickAsync();
            }
        }
        public async Task ClickCheckoutButton()
        {
            await page.GetByText("Proceed To Checkout").ClickAsync();
        }


    }
}
