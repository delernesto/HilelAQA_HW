﻿using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace PlaywrightSpecFlow.PageObjects {
    [Binding]
    internal class DemoQAWebTablesPage
    {
        private IPage Page;
        private string WebTablePageUrl = "https://demoqa.com/webtables";

        public DemoQAWebTablesPage(IPage page)
        {
            Page = page;
        }

        public async Task GoToDemoQaWebTablesPage()
        {
            await Page.GotoAsync(WebTablePageUrl);
        }

        public async Task VerifyTableVisible()
        {
            var table = Page.Locator(".ReactTable");
            await Assertions.Expect(table).ToBeVisibleAsync();
        }


        public async Task VerifyTableRowContent(string headerName = "First Name", string value = "Cierra")
        {
            var table = Page.Locator(".ReactTable");

            // Locate headers
            var headers = await table.Locator(".rt-th").AllInnerTextsAsync();
            var headersList = headers.ToList();

            // Find the index of the specified header
            int headerIndex = headersList.IndexOf(headerName);

            if (headerIndex == -1)
            {
                Assert.Fail($"Header '{headerName}' not found.");
            }

            // Locate all rows using EvaluateAllAsync
            var rows = await table.Locator(".rt-tr-group").EvaluateAllAsync<ILocator[]>("(elements) => elements");

            if (rows.Length == 0)
            {
                Assert.Fail("No rows found in the table.");
            }

            // Locate the cells in the specified column for each row
            var cells = new List<ILocator>();
            foreach (var row in rows)
            {
                var rowCells = await row.Locator(".rt-td").EvaluateAllAsync<ILocator[]>("(elements) => elements");
                if (rowCells.Length > headerIndex)
                {
                    cells.Add(rowCells[headerIndex]);
                }
                else
                {
                    Assert.Fail("Row does not contain enough cells.");
                }
            }

            // Check if the content of the first cell in the specified column matches the given value
            if (cells.Any())
            {
                var cellContent = await cells.First().InnerTextAsync();
                Assert.That(cellContent == value, $"The content of the first cell in the '{headerName}' column does not match '{value}'.");
            }
            else
            {
                Assert.Fail($"No cells found in the '{headerName}' column.");
            }
        }

        public async Task IClickAddButton()
        {
            await Page.GetByRole(AriaRole.Button, new() { NameString = "Add" }).ClickAsync();
        }

        public async Task IClickSubmitButton()
        {
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        }

        public async Task IFillFirstName(string firstName)
        {
            await Page.GetByPlaceholder("First Name").FillAsync(firstName);
            //await Page.GetByPlaceholder("First Name").PressAsync("Enter");
        }

        public async Task IFillLastName(string lastName)
        {
            await Page.GetByPlaceholder("Last Name").FillAsync(lastName);
            //await Page.GetByPlaceholder("Last Name").PressAsync("Enter");
        }
        public async Task IFillEmail(string email)
        {
            await Page.GetByPlaceholder("name@example.com").FillAsync(email);
        }
        public async Task IFillAge(string age)
        {
            await Page.GetByPlaceholder("Age").FillAsync(age);

        }
        public async Task IFillSalary(string salary)
        {
            await Page.GetByPlaceholder("Salary").FillAsync(salary);

        }
        public async Task IFillDepartment(string department)
        {
            await Page.GetByPlaceholder("Department").FillAsync(department);

        }
        public async Task VerifyPopupVisible()
        {
            var popup = Page.Locator(".modal-content");
            await Assertions.Expect(popup).ToBeVisibleAsync();
        }

        public async Task VerifyFirstNameVisible()
        {
            var popup = Page.Locator(".modal-content");
            var firstName = popup.GetByPlaceholder("First Name");
            await Assertions.Expect(firstName).ToBeVisibleAsync();
        }
        public async Task IClickEditButton(string editline)
        {
            await Page.Locator($"#edit-record-{editline}").GetByRole(AriaRole.Img).ClickAsync();
        }
        public async Task IClickDeleteButton(string deleteline)
        {
            await Page.Locator($"#delete-record-{deleteline} path").ClickAsync();
        }
            public async Task VerifyRowIsNotVisible(string id)
            {
                var row = Page.Locator($"#delete-record-{id}");
                await Assertions.Expect(row).Not.ToBeVisibleAsync();

        }
    }
}
