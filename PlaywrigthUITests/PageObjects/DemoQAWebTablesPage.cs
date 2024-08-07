﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

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

    public async Task VerifyTableRowVisible()
    {
        var table = Page.Locator(".ReactTable");
        var rows = await table.Locator(".rt-tr-group").AllAsync();

        if (rows.Any())
        {
            await Assertions.Expect(rows.First()).ToBeVisibleAsync();
        }
        else
        {
            Assert.Fail("No rows found in the table.");
        }
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

        // Locate all rows
        var rows = await table.Locator(".rt-tr-group").AllAsync();

        // Locate the cells in the specified column for each row
        var cells = new List<ILocator>();
        foreach (var row in rows)
        {
            var rowCells = await row.Locator(".rt-td").AllAsync();
            if (rowCells.Count > headerIndex)
            {
                cells.Add(rowCells[headerIndex]);
            }
            else
            {
                Assert.Fail("Row does not contain enough cells.");
            }
        }

        bool foundMatch = false;
        foreach (var cell in cells)
        {
            var cellContent = await cell.InnerTextAsync();
            if (cellContent.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                foundMatch = true;
                break; // Exit loop once a match is found
            }
        }

        Assert.That(foundMatch, $"No cell in the '{headerName}' column matches the value '{value}'.");

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
    public async Task AddFistname(string firstname)
    {
        await Page.GetByPlaceholder("First Name").FillAsync(firstname);
    }
    public async Task AddLastname(string lastname)
    {
        await Page.GetByPlaceholder("Last Name").FillAsync(lastname);
    }
    public async Task AddEmail(string email)
    {
        await Page.GetByPlaceholder("name@example.com").FillAsync(email);
    }
    public async Task AddAge(string age)
    {
        await Page.GetByPlaceholder("Age").FillAsync(age);

    }
    public async Task AddSalary(string salary)
    {
        await Page.GetByPlaceholder("Salary").FillAsync(salary);

    }
    public async Task AddDepartment(string department)
    {
        await Page.GetByPlaceholder("Department").FillAsync(department);

    }
    public async Task ClickButtonAdd()
    {
        await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
    }
    public async Task ClickButtonSubmit()
    {
        await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
    }

    public async Task VerifyBorderColorIsRed(string selector)
    {
        await Assertions.Expect(Page.Locator(selector)).ToHaveCSSAsync("border-color", "rgb(220, 53, 69)");
    }
    public async Task ClickEditButton(string editline)
    {
        await Page.Locator(editline).GetByRole(AriaRole.Img).ClickAsync();
    }
    public async Task ClickDeleteButton(string deleteline)
    {
        await Page.Locator(deleteline).ClickAsync();
    }
    public async Task VerifyRowIsNotVisible(int id)
    {
        var row = Page.Locator($"#delete-record-{id}");
        await Assertions.Expect(row).Not.ToBeVisibleAsync();

    }

}
