﻿using Microsoft.Playwright;
using NUnitTests.Features.Drive;
namespace PlaywrigthUITests.Tests
{
    [Description("Verify Buttons on buttons page")]
    class ButtonsTestsrun : UITestFixture
    {

        public byte newstring = DrivePresetup.Accelerate;
        public byte newstring1 = DrivePresetup.InternalClass.InternalAccelerate;

        [Test, Description("Verify Click Me button"), Retry(2)]
        public async Task ClickButtonTest()
        {
            // Given I go to DemoQa Elements page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            // And I see 'buttons page
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            // And I click the 'Click Me' button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Click Me", Exact = true }).ClickAsync();
            // Then  I see "You have done a dynamic click" text.
            var isVisible = await Page.GetByText("You have done a dynamic click").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
            // And I NOT see "You have done a double click" text.
            var isNotVisible = await Page.GetByText("You have done a double click").IsHiddenAsync();
            Assert.That(isNotVisible, "The element with text 'You have done a double click' should NOT be visible after clicking the button.");
        }


        [Test, Description("Verify Double Click Me button"), Retry(3)]
        public async Task DoubleClickButtonTest()
        {
            //Given I go to DemoQA Elements Page
            await Page.GotoAsync("https://demoqa.com/elements");
            //When I Click the Buttons button in menu
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            //And I see 'buttons Page
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            //And I double click the 'Double Click Me' button
            await Page.GetByRole(AriaRole.Button, new() { NameString = "Double Click Me" }).DblClickAsync();
            //Then I see "You have done a double click" text.
            var isVisible = await Page.GetByText("You have done a double click").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a double click' should be visible after clicking the button.");
            //And I NOT see "You have done a dynamic click" text.
            var isNotVisible = await Page.GetByText("You have done a dynamic click").IsHiddenAsync();
            Assert.That(isNotVisible, "The element with text 'You have done a dynamic click' should NOT be visible after a double click.");
        }

        [Test, Description("Verify Rigth Click Me button"), Retry(2)]
        public async Task RigthClickButtonTest()
        {
            //Given I go to DemoQA Elements Page
            await Page.GotoAsync("https://demoqa.com/elements");
            //When I Click the Buttons button in menu
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            //And I see 'buttons Page
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            //And I Rigth click the 'Right Click Me' button
            await Page.GetByRole(AriaRole.Button, new() { NameString = "Right Click Me" }).ClickAsync(new LocatorClickOptions
            {
                Button = MouseButton.Right,
            });
            //Then I see "You have done a right click" text.
            var isVisible = await Page.GetByText("You have done a right click").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a double click' should be visible after Rigth clicking the button.");
            //And I NOT see "You have done a dynamic click" text.
            var isNotVisible = await Page.GetByText("You have done a double click").IsHiddenAsync();
            Assert.That(isNotVisible, "The element with text 'You have done a dynamic click' should NOT be visible after Rigth clicking the button.");
        }

        //Homework Lesson_9
        //TODO : 
        //TC-4 : Verify Click Me button should be enabled
        [Test, Description("Verify Click Me button should be enabled"), Retry(2)]
        [Category("UI")]
        public async Task VerifyClickMeEnabled()
        {
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            // And I see 'buttons page
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            // And I click the 'Click Me' button
            var IsEnabled = await Page.GetByRole(AriaRole.Button, new() { Name = "Click Me", Exact = true }).IsEnabledAsync();
            Assert.That(IsEnabled, "Button 'Click Me' should be enabled");
        }

        //TC-5 : Verify Click Rigth Click Me button verify button focused
        [Test, Description("Verify Rigth Click Me button should be Focused"), Retry(2)]
        [Category("UI")]
        [Ignore("Find how to test FOCUS")]
        public async Task VerifyRigthClickMeFocused()
        {
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            // And I see 'buttons page
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            // And I click the 'Click Me' button
            await Page.GetByRole(AriaRole.Button, new() { NameString = "Right Click Me" }).ClickAsync(new LocatorClickOptions
            {
                Button = MouseButton.Right,
            });
            var isFocused = await Page.GetByRole(AriaRole.Button, new() { NameString = "Right Click Me" }).IsCheckedAsync();
            Assert.That(isFocused, "Button 'Right Click Me' should be focused after right click");
        }

        //TC-6 : Verify H1 Buttons is visible
        [Test, Description("Verify H1 Buttons is visible"), Retry(2)]
        [Category("UI")]
        public async Task VerifyLabelButtnsIsVisible()
        {

            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            // And I see 'buttons page
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            // And I click the 'Click Me' button
            var isVisible = await Page.GetByRole(AriaRole.Heading, new() { Name = "Buttons" }).IsVisibleAsync();
            Assert.That(isVisible, "Button 'Right Click Me' should be focused after right click");
        }
        //TC-7 : Verify text 'You hav`e done a dynamic click' is not visible after Page refresh
        [Test, Description("Verify text You have done a dynamic click is not" +
       " visible after page refresh"), Retry(2)]
        [Category("UI")]
        public async Task VerifyDynamicClickTextIsNotVisibleAfterRefresh()
        {
            //Given I go to DemoQA Elements Page
            await Page.GotoAsync("https://demoqa.com/elements");
            //When I Click the Buttons button in menu
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            //And I see 'buttons Page
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            //And I double click the 'Double Click Me' button
            await Page.GetByRole(AriaRole.Button, new() { NameString = "Double Click Me" }).DblClickAsync();
            //Then I see "You have done a double click" text.
            var isVisible = await Page.GetByText("You have done a double click").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a double click' should be visible after clicking the button.");
            //And I NOT see "You have done a dynamic click" text.
            var isNotVisible = await Page.GetByText("You have done a dynamic click").IsHiddenAsync();
            Assert.That(isNotVisible, "The element with text 'You have done a dynamic click' should NOT be visible after a double click.");
            await Page.ReloadAsync();
            var isHidden = await Page.GetByText("You have done a double click").IsHiddenAsync();
            Assert.That(isHidden, "The element with text 'You have done a dynamic click' should NOT be visible after a double click.");

        }
    }
}