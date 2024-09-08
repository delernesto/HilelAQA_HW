using Microsoft.Playwright;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;


namespace Course_Final_Hw.PageObjects
{
    internal class CartPage
    {
        private IPage page;
        private string AutoExcerciseCartPageURL = "https://automationexercise.com/view_cart";

        public CartPage(IPage pagenew)
        {
            page = pagenew;
        }
        public async Task GoToAutoExcerciseCartPage()
        {
            await page.GotoAsync(AutoExcerciseCartPageURL);
        }

        //Here we have simlar methods, but the first one we use just to check if there any products,
        // and in the second method we Verify that we exactly have any products
        public async Task<bool> CheckifAnyProductsInCart()
        {
            bool anyProducts = await page.Locator("[id*='product-']").First.IsVisibleAsync();
            return anyProducts;
        }
        public async Task VerifyAnyProductsInCart()
        {
            await Assertions.Expect(page.Locator("[id*='product-']").First).ToBeVisibleAsync();
        }

        public async Task<int> CountTheAmountOfProducts()
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
        public async Task RemoveProducts()
        {
            int count = await page.Locator("[id*='product-']").CountAsync();
            for (int i = 0; i < count; i++)
            {
                await page.Locator(".cart_quantity_delete").First.ClickAsync();

                //doesnt help
                //await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

                //works but bad practice
                await Task.Delay(1000);
            }
        }
        public async Task ClickCheckoutButton()
        {
            await page.GetByText("Proceed To Checkout").ClickAsync();
        }
        public async Task<bool> IsCartEmpty()
        {
            bool isCartEmpty = await page.Locator("#empty_cart").IsVisibleAsync();
            return isCartEmpty;
        }

    }
}
