using Microsoft.Playwright;
using System;
using System.Text.Json.Nodes;


namespace API_HW
{
    internal class FruitsAPI : UITestFixture
    {
        [Test]
        public async Task ReplaceResponse()
        {
            await Page.RouteAsync("*/**/api/v1/fruits", async route => {
                var response = await route.FetchAsync();
                var body = await response.BodyAsync();
                var jn = JsonNode.Parse(body);
                JsonArray ja = jn.AsArray();
                int indexofOrange = -1;
                for (int i = 0; i < ja.Count; i++)
                {
                    string name = ja[i]["name"].ToString();

                    if (name == "Orange")
                    {
                        ja[i]["name"] = "Last fruit";
                        indexofOrange = i;
                        break;
                    }
                }
                Assert.That(indexofOrange, Is.GreaterThanOrEqualTo(0));

                for (int i = ja.Count - 1; i > indexofOrange; i--)
                {
                    ja.RemoveAt(i);
                }
                await route.FulfillAsync(new() { Response = response, Json = ja });              
            });
            await Page.GotoAsync("https://demo.playwright.dev/api-mocking");
            await Assertions.Expect(Page.GetByText("Last fruit")).ToBeVisibleAsync();
        }
    }
}
