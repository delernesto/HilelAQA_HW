﻿using Course_Final_Hw.PageObjects;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using UiTestFixture;


namespace Course_Final_Hw.Tests
{
    internal class AutoExcerciseTest : UITestFixture
    {
        private AutoExcerciseContactUsPage AutoExcerciseContactUsPage;
        private AutoExcerciseMainPage AutoExcerciseMainPage;
        private AutoExcerciseProductsPage AutoExcerciseProductsPage;
        private AutoExcerciseCartPage AutoExcerciseCartPage;
        private AutoExerciseCheckoutPage AutoExerciseCheckoutPage;


        [SetUp]
        public async Task SetupSolarTehchnologyShopPage()
        {
            AutoExcerciseMainPage = new AutoExcerciseMainPage(Page);
            AutoExcerciseContactUsPage = new AutoExcerciseContactUsPage(Page);
            AutoExcerciseProductsPage = new AutoExcerciseProductsPage(Page);
            AutoExcerciseCartPage = new AutoExcerciseCartPage(Page);
            AutoExerciseCheckoutPage = new AutoExerciseCheckoutPage(Page);

            await AutoExcerciseMainPage.GoToAutoExcerciseMainPage();
        }
        [Test]
        [Description("Verify Contact Us Form works Correctly")]
        public async Task VerifySendingContactUsForm()
        {
            await Page.PauseAsync();

            await AutoExcerciseContactUsPage.GoToAutoExcerciseContactUsPage();

            await AutoExcerciseContactUsPage.FillNameInput("Astolfo");
            await AutoExcerciseContactUsPage.FillEmailInput("qazwsx123@gmail.com");
            await AutoExcerciseContactUsPage.FillSubjectInput("Subject");
            await AutoExcerciseContactUsPage.FillMessageInput("Message");
            await AutoExcerciseContactUsPage.AddFileInput("AstolfoSample.jpg");
            await AutoExcerciseContactUsPage.ClickSubmitAndOK();

            await Assertions.Expect(Page.Locator("#contact-page").GetByText("Success! Your details have been submitted successfully.")).ToBeVisibleAsync();
        }

        [Test]
        [Description("Search Product")]
        [TestCase("Pure Cotton Neon Green Tshirt")]
        [TestCase("Winter Top")]
        [TestCase("Stylish Dress")]
        public async Task VerifyProductSearch(string productName)
        {
            await AutoExcerciseProductsPage.GoToAutoExcerciseProductsPage();
            await AutoExcerciseProductsPage.SearchProduct(productName);
            await AutoExcerciseProductsPage.VerifyAnyProductsOnPage();

            await Assertions.Expect(Page.Locator("[class*='productinfo']")).ToContainTextAsync(productName);
        }
        [Test]
        [Description("Remove Products From Cart")]
        [TestCase(1)]
        [TestCase(10)]
        public async Task VerifyRemoveItemFromCart(int productsAmount)
        {
            await AutoExcerciseProductsPage.GoToAutoExcerciseProductsPage();
            await AutoExcerciseProductsPage.VerifyAnyProductsOnPage();
            await AutoExcerciseProductsPage.AddingProductsToCart(productsAmount);

            await AutoExcerciseCartPage.GoToAutoExcerciseCartPage();
            await AutoExcerciseCartPage.VerifyAnyPrductsInCart();
            await AutoExcerciseCartPage.RemoveProduct();

            string EmptyCartText = "Cart is empty!";
            await Assertions.Expect(Page.Locator("#empty_cart p")).ToContainTextAsync(EmptyCartText);

        }

        [Test]
        [Description("Verify Product quantity in Cart")]
        [TestCase(4)]
        [TestCase(10)]
        public async Task VerifyProductQuantityInCart(int productsAmount)
        {
            //aknowledged that cause of saving user session we may have 
            //products at cart already, gonna fix it later
            await AutoExcerciseCartPage.GoToAutoExcerciseCartPage();
            await AutoExcerciseCartPage.RemoveProduct();

            await AutoExcerciseProductsPage.GoToAutoExcerciseProductsPage();
            await AutoExcerciseProductsPage.VerifyAnyProductsOnPage();
            await AutoExcerciseProductsPage.AddingProductsToCart(productsAmount);

            await AutoExcerciseCartPage.GoToAutoExcerciseCartPage();
            await AutoExcerciseCartPage.VerifyAnyPrductsInCart();
            int result = await AutoExcerciseCartPage.CountAmountOfProducts();

            Assert.That(result, Is.EqualTo(productsAmount));
        }
       
        [Test]
        [Description("Place Order: Login before Checkout (without  'Delete Account')")]
       
        public async Task PlaceOrderBeforeCheckout()
        
        {

            await Page.GotoAsync("https://automationexercise.com/login");
            await Page.Locator("form").Filter(new() { HasText = "Login" }).GetByPlaceholder("Email Address").ClickAsync();
            await Page.Locator("form").Filter(new() { HasText = "Login" }).GetByPlaceholder("Email Address").FillAsync("Astolfo@gmail.com");
            await Page.GetByPlaceholder("Password").ClickAsync();
            await Page.GetByPlaceholder("Password").FillAsync("qawsed");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

            await AutoExcerciseProductsPage.GoToAutoExcerciseProductsPage();
            await AutoExcerciseProductsPage.VerifyAnyProductsOnPage();
            await AutoExcerciseProductsPage.AddingProductsToCart(3);

            await AutoExcerciseCartPage.GoToAutoExcerciseCartPage();
            await AutoExcerciseCartPage.VerifyAnyPrductsInCart();
            await AutoExcerciseCartPage.ClickCheckoutButton();

            await AutoExerciseCheckoutPage.VerifyPageIsTransferedTo();

            await Assertions.Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Place Order" })).ToBeVisibleAsync();
        }
    }
}
