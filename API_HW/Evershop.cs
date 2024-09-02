using Microsoft.Playwright;
using System;
using System.Drawing;


namespace API_HW
{
    internal class Evershop : UITestFixture
    {
        //private IAPIRequestContext Request = null!;



        [Test]
        public async Task Name()
        {
            await Page.APIRequest.PostAsync("https://demo.evershop.io/customer/login", new()
            {
                DataObject = new Dictionary<string, object>() {
                  { "email", "Astolfo@gmail.com" },
                  { "password", "Qazwsx123!" }
                }
            });
            await Page.GotoAsync("https://demo.evershop.io/");


            //await Page.Locator("div:nth-child(3) > a").First.ClickAsync();
            //await Page.WaitForTimeoutAsync(1500);
            //await Page.GetByPlaceholder("Email").ClickAsync();
            //await Page.GetByPlaceholder("Email").FillAsync("Astolfo@gmail.com");
            //await Page.GetByPlaceholder("Password").ClickAsync();
            //await Page.GetByPlaceholder("Password").FillAsync("Qazwsx123!");
            //await Page.GetByRole(AriaRole.Button, new() { Name = "SIGN IN" }).ClickAsync();


            await Page.GetByRole(AriaRole.Link, new() { Name = "Nike air zoom pegasus" }).First.ClickAsync();
            await Page.WaitForTimeoutAsync(1500);
            await Page.GetByRole(AriaRole.Link, new() { Name = "Blue" }).ClickAsync();
            await Page.WaitForTimeoutAsync(1500);
            await Page.GetByRole(AriaRole.Link, new() { Name = "L", Exact = true }).ClickAsync();
            await Page.WaitForTimeoutAsync(1500);
            await Page.GetByRole(AriaRole.Button, new() { Name = "ADD TO CART" }).ClickAsync();
            await Page.WaitForTimeoutAsync(1500);
            await Page.GetByRole(AriaRole.Link, new() { Name = "VIEW CART" }).ClickAsync();
            await Page.WaitForTimeoutAsync(1500);
            await Page.GetByRole(AriaRole.Link, new() { Name = "CHECKOUT" }).ClickAsync();
           
        }

    }
}
