﻿using Microsoft.Playwright;
using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    internal class WebTableTests : UITestFixture
    {
        private DemoQAWebTablesPage DemoQAWebTablesPage;

        [SetUp]
        public void SetupDemoQAPage()
        {
            DemoQAWebTablesPage = new DemoQAWebTablesPage(Page);
        }

        [Test]
        public async Task VerifyTableVisible()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await DemoQAWebTablesPage.VerifyTableRowContent("Last Name", "Vega");
            await DemoQAWebTablesPage.ClickButtonAdd();
            await DemoQAWebTablesPage.VerifyPopupVisible();
            await DemoQAWebTablesPage.VerifyFirstNameVisible();
        }

        [Test]
        public async Task VerifyTableVisible2()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await DemoQAWebTablesPage.VerifyTableRowContent("Last Name", "Cantrell");
            await DemoQAWebTablesPage.ClickButtonAdd();
            await DemoQAWebTablesPage.VerifyPopupVisible();
            await DemoQAWebTablesPage.VerifyFirstNameVisible();
        }

        //TODO: automate test cases
        //Check any mandatory field
        [Test, Description("Check any mandatory field"), Retry(2)]
        public async Task CheckMandatoryField()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await DemoQAWebTablesPage.ClickButtonAdd();
            await DemoQAWebTablesPage.AddFistname("John");
            await DemoQAWebTablesPage.AddLastname("Doe");
            await DemoQAWebTablesPage.AddEmail("ABC@gmail.com");
            await DemoQAWebTablesPage.AddAge("qwe");
            await DemoQAWebTablesPage.AddSalary("2400");
            await DemoQAWebTablesPage.AddDepartment("Sales");
            await DemoQAWebTablesPage.ClickButtonSubmit();
            await DemoQAWebTablesPage.VerifyBorderColorIsRed("input[placeholder = 'Age']");

        }
        //Add new row and verify row added
        [Test, Description("Add new row and verify row added")]
        public async Task AddNewRowAndVerify()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await DemoQAWebTablesPage.ClickButtonAdd();
            await DemoQAWebTablesPage.AddFistname("John");
            await DemoQAWebTablesPage.AddLastname("Doe");
            await DemoQAWebTablesPage.AddEmail("ABC@gmail.com");
            await DemoQAWebTablesPage.AddAge("33");
            await DemoQAWebTablesPage.AddSalary("2400");
            await DemoQAWebTablesPage.AddDepartment("Sales");
            await DemoQAWebTablesPage.ClickButtonSubmit();
            await DemoQAWebTablesPage.VerifyTableRowContent("Last Name", "Doe");

        }
        //Edit row and verify row edited
        [Test, Description("Edit row and verify row edited")]
        public async Task EditRowAndVerify()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await DemoQAWebTablesPage.ClickEditButton("#edit-record-1");
            await DemoQAWebTablesPage.AddLastname("Doe");
            await DemoQAWebTablesPage.ClickButtonSubmit();
            await DemoQAWebTablesPage.VerifyTableRowContent("Last Name", "Doe");

        }
        //Delete row and verify row deleted
        [Test, Description("Edit row and verify row edited")]
        public async Task DeleteRowAndVerify()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            // number is an index for element we want to delete
            await DemoQAWebTablesPage.ClickDeleteButton("#delete-record-1 path");
            await DemoQAWebTablesPage.VerifyRowIsNotVisible(1);
        }

    }
}
