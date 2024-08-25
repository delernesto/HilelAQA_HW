using Microsoft.Playwright;

namespace SolarTechHW.PageObjects
{
    internal class SolarTehchnologyShop
    {
        private IPage page;
        private string SolarTechShopPageUrl = "https://solartechnology.com.ua/shop";

        public SolarTehchnologyShop(IPage pagenew)
        {
            page = pagenew;
        }
        public async Task GoToSolarTehchnologyShopPage()
        {
            await page.GotoAsync(SolarTechShopPageUrl);
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

        public async Task FilterItems(string propertyname)
        {
            //Arrange
            var filterCheckbox = page.Locator(".card-content").Locator($"span:text-is(\"{propertyname}\")");
            //var filterCheckbox = page.Locator(".checkbox").Filter(new() { HasText = name });

            //Act
            await filterCheckbox.ClickAsync();

            //Assert
            await Assertions.Expect(filterCheckbox).ToBeCheckedAsync();
        }
        public async Task VerifyFilteredItems(string propertyname)
        {
            //First used here because playright throws exeption cause there are many objects with same class
            bool anyproducts = await page.Locator("[class*='prod-holder']").First.IsVisibleAsync();

            //Here used If instead of Assert cause its possible to be 0 elements after filters
            //P.S. acknowledged that its bad practice to put assert inside if but not sure
            //how to do it in a different way
            if (anyproducts)
            {
                await Task.Delay(5000);
                //Here we count all how many pruducts are suitable for filters 
                int count = await page.Locator("[class*='prod-holder']").CountAsync();
                for (int i = 0; i < count; i++)
                {
                    //Here we compare text inside product quicklook with our specific filter
                    var product = page.Locator("[class*='prod-holder']").Nth(i);
                    string textContent = await product.InnerTextAsync();
                    bool containsText = textContent.Contains(propertyname, StringComparison.OrdinalIgnoreCase);

                    // if we fail to find it inside product's quicklook of properties, 
                    // we check it on product's pace
                    if (!containsText)
                    {
                        await Task.Delay(5000);
                        await page.Locator("[class*='prod-holder']").Nth(i).ClickAsync();

                        var productspecstable = page.Locator(".specs");
                        textContent = await productspecstable.InnerTextAsync();
                        containsText = textContent.Contains(propertyname, StringComparison.OrdinalIgnoreCase);

                        await page.GoBackAsync();
                    }

                    Assert.IsTrue(containsText, $"Product number {i} does not contain specific filter '{propertyname}'");

                    
                }
            }
        }
        #region Multiple filter skeleton
        //public async Task VerifyItemsFilter(string[] propertyname)
        //{
        //    Assert.That(propertyname.Length > 0, "Filter array is empty");
        //    foreach (string name in propertyname)
        //    {
        //        //var filterCheckbox = page.Locator(".card-content").Locator($"span:text-is(\"{name}\")");
        //        var filterCheckbox = page.Locator(".checkbox").Filter(new() { HasText = name });
        //        await filterCheckbox.ClickAsync();
        //        //await Assertions.Expect(filterCheckbox).ToBeCheckedAsync();

        //        await Assertions.Expect(filterCheckbox).ToBeCheckedAsync();

        //        var productLocator = page.Locator("[class*='prod-holder']").First;
        //        bool anyproducts = await productLocator.IsVisibleAsync();


        //        if (anyproducts)
        //        {
        //            int count = await productLocator.CountAsync();
        //            bool elementFound = false;
        //            for (int i = 0; i < count; i++)
        //            {
        //                var product = productLocator.Nth(i);
        //                bool isVisible = await product.Locator($"span:has-text(\"{name}\")").First.IsVisibleAsync();
        //                if (isVisible)
        //                {
        //                    elementFound = true;
        //                    break;
        //                }
        //            }
        //            Assert.That(elementFound, $"No product matches the filter '{name}'");
        //        }
        //    }
        //}
        #endregion

        public async Task AddItemToShopCart()
        {
            await page.Locator(".add-product-to-cart").First.ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Оформити замовлення" }).ClickAsync();
            await page.WaitForURLAsync("https://solartechnology.com.ua/cart");
        }

        public async Task VerifyAnyItemsInCart()
        {
            await Assertions.Expect(page.Locator("[class*='cart-product']").First).ToBeVisibleAsync();
        }

        public async Task ClickDeleteItemFromShopCart()
        {
            await page.Locator("span[class*='remove-from-cart']:has-text('close')").ClickAsync();
            

        }
        public async Task VerrifyThatPageChangedToDefaultAndCartIsEmpty()
        {
            await Task.Delay(5000);

            //Verrify that after deleting item page changed to default
            string currentUrl = page.Url;
            Assert.That(currentUrl, Is.EqualTo("https://solartechnology.com.ua/shop"), "The URL supposed to change after" +
                " deleting item from shopping cart.");

            //Verify that if we click shopping cart button nothing happens. That means shopping cart is empty
            await page.Locator("li").Filter(new() { HasText = "shopping_cart" }).Locator("a").ClickAsync();
            Assert.That(currentUrl, Is.EqualTo("https://solartechnology.com.ua/shop"), "The URL changed after" +
                " clicking the button, indicating that something happened.");
        }

        public async Task VerifyAnyItemsOnPage()
        {
            await Assertions.Expect(page.Locator("[class*='list-product-title']").First).ToBeVisibleAsync();
        }

        public async Task VerrifyClickedProductsNamesAreCorrect()
        {
            
            string productPageGeneralUrl = "https://solartechnology.com.ua/shop/view/";
            int count = await page.Locator("[class*='list-product-title']").CountAsync();

            //Test fails on 20's product cause of incorrect product name
            for (int i = 0; i < count; i++)
            {
                string productTitle = await page.Locator("[class*='list-product-title']").Nth(i).InnerTextAsync();


                //here special check for rare product with wrong product name( includes words on сyrillic)
                bool containsCyrillic = Regex.IsMatch(productTitle, @"[\u0400-\u04FF]");
                if (containsCyrillic)
                {
                    productTitle = Regex.Replace(productTitle, @"[\u0400-\u04FF]", "");
                }

                //Here we make sure there are no extra spaces in product name string
                productTitle = productTitle.Trim();

                await page.Locator("[class*='list-product-title']").Nth(i).ClickAsync();

                string currentUrl = page.Url;
                Assert.That(currentUrl.Contains(productPageGeneralUrl, StringComparison.OrdinalIgnoreCase),
                    "URL of page after click differ from general URL for products ");

                var h1Element = await page.Locator("h1").InnerTextAsync();
                Assert.That(h1Element.Contains(productTitle, StringComparison.OrdinalIgnoreCase),
                      $"Product name '{productTitle}' didnt match '{h1Element}'");

                await page.GoBackAsync();
            }
        }
    }
}