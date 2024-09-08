using Microsoft.Playwright;
using System;
using System.Reflection.PortableExecutable;
using System.Text;

namespace UiTestFixture
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    internal class UITestFixture
    {
        public static IBrowserContext Context { get; private set; }
        public IPage Page { get; private set; }
        private IBrowser browser;
        private IAPIRequestContext apiContext;

        #region apisetup
        [OneTimeSetUp]
        public async Task ApiSetup()

        {

            var headers = new Dictionary<string, string>();
            headers.Add("Accept", "application/json");

            var playwrightDriver = await Playwright.CreateAsync();
            apiContext = await playwrightDriver.APIRequest.NewContextAsync(new()
            {
                BaseURL = "https://automationexercise.com/api/",
                ExtraHTTPHeaders = headers,
            });

            IFormData formDataTryLogin = apiContext.CreateFormData();
            formDataTryLogin.Append("email", "Astolfo@gmail.com");
            formDataTryLogin.Append("password", "qawsed");

            IFormData formDataCreate = apiContext.CreateFormData();
            formDataCreate.Append("name", "Astolfo");
            formDataCreate.Append("email", "Astolfo@gmail.com");
            formDataCreate.Append("password", "qawsed");
            formDataCreate.Append("firstname", "Astolfo");
            formDataCreate.Append("lastname", "Rider");
            formDataCreate.Append("address1", "Bazhana 83");
            formDataCreate.Append("country", "Ukraine");
            formDataCreate.Append("state", "Kyiv");
            formDataCreate.Append("city", "Kyiv");
            formDataCreate.Append("zipcode", "02083");
            formDataCreate.Append("mobile_number", "0631231212");


            var responseCreate = await apiContext.PostAsync("createAccount", options: new() { Form = formDataCreate });
           
            Assert.That(responseCreate.Status, Is.EqualTo(200));
                
            var bodyCreate = await responseCreate.JsonAsync();
            var bodyStatusCreate = bodyCreate.Value.GetProperty("responseCode").GetInt32();
            Assert.That(bodyStatusCreate, Is.EqualTo(201));

        }
        #endregion apisetup

        [SetUp]
        public async Task Setup()
        {
            var storagefile = "../../../playwright/.auth/Credentials_To_Login.json";
            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Set to false to run the browser in non-headless mode
            });

            var fileinfo = new FileInfo(storagefile);


            if (!fileinfo.Exists)
            {
                Directory.CreateDirectory(fileinfo.Directory.FullName);
                using (FileStream fs = File.Create(storagefile))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("");
                    fs.Write(info, 0, info.Length);
                }
            }

            Context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                StorageStatePath = storagefile,
                ViewportSize = new ViewportSize
                {
                    Width = 1920,  // Set the width to a common fullscreen width
                    Height = 1080 // Set the height to a common fullscreen height
                }
            });
            Page = await Context.NewPageAsync();

            // await Task.Delay(15000);
            await Page.GotoAsync("https://automationexercise.com");

            bool IsLoggedIn = await Page.GetByRole(AriaRole.Link, new() { Name = " Logout" }).IsVisibleAsync();
            if (!IsLoggedIn)
            {
                await Page.GotoAsync("https://automationexercise.com/login");
                await Page.Locator("form").Filter(new() { HasText = "Login" }).GetByPlaceholder("Email Address").ClickAsync();
                await Page.Locator("form").Filter(new() { HasText = "Login" }).GetByPlaceholder("Email Address").FillAsync("Astolfo@gmail.com");
                await Page.GetByPlaceholder("Password").ClickAsync();
                await Page.GetByPlaceholder("Password").FillAsync("qawsed");
                await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
                //await Page.PauseAsync();
                await Context.StorageStateAsync(new()
                {
                    Path = storagefile
                });
            }
        }

        [OneTimeTearDown]
        public async Task ApiUserDelete()
        {
            //await Page.PauseAsync();
            IFormData formDataDelete = apiContext.CreateFormData();
            formDataDelete.Append("email", "Astolfo@gmail.com");
            formDataDelete.Append("password", "qawsed");

            var responseDelete = await apiContext.DeleteAsync("deleteAccount", options: new() { Form = formDataDelete });

            var bodyDelete = await responseDelete.JsonAsync();

            var bodyStatusDelete = bodyDelete.Value.GetProperty("responseCode").GetInt32();

            Assert.That(bodyStatusDelete, Is.EqualTo(200));
        }
     
    }
}
