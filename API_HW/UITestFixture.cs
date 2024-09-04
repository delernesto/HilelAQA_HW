using Microsoft.Playwright;

namespace API_HW
{
    public class UITestFixture
    {
        public IPage Page { get; private set; }
        private IBrowser browser;
       // public IAPIRequestContext apiContext;

        [SetUp]
        public async Task Setup()
        {
            var playwrightDriver = await Playwright.CreateAsync();

            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });

            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,
                    Height = 1080
                }
            });            
            Page = await context.NewPageAsync();
            //apiContext = await playwrightDriver.APIRequest.NewContextAsync();
            //var headers = new Dictionary<string, string>();
            //// We set this header per GitHub guidelines.
            //headers.Add("Accept", "application/json");
            //apiContext = await playwrightDriver.APIRequest.NewContextAsync(new()
            //{
            //    // All requests we send go to this API endpoint.
            //    BaseURL = "https://demo.evershop.io",
            //    ExtraHTTPHeaders = headers,
            //});
        }

        [TearDown]
        public async Task Teardown()
        {
            await Page.CloseAsync();
            await browser.CloseAsync();
        }
    }
}
