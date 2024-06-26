﻿using AtataUITests.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtataUITests.Tests
{
    internal class TextBoxTests : UITestFixture
    {
        //Preconditions: Go to https://demoqa.com/text-box

        #region [Full Name] field:

        //Test Case 1: Text Full Name should be visible
        //Test Case 2: Text Full Name Input should be visible
        //Test Case 3: Enter "John Doe" in Text Full Name Input, press submit, text Name should be "Name:John Doe"
        //Test Case 4: Clear Text Full Name Input, press submit, text Name should not be visible


        //Test Case 1
        [Test, Retry(2)]
        [Description("Label \"Full Name\" should be visible")]
        [Category("UI")]
        public void VerifyFullNameFieldLabelVisible()
        {
            Go.To<DemoQAElementsPage>().
               TextBox.ClickAndGo().
               FullNameLabel.Should.BeVisible();
             
        }

        //Test Case 2
        [Test, Retry(2)]
        [Description("Full Name input should be visible")]
        [Category("UI")]
        public void VerifyFullNameFieldVisible()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                FullNameInput.Should.BeVisible();
        }

        //Test Case 3
        [Test, Retry(2)]
        [Description("Enter \"John Doe\" in Text Full Name Input, " +
            "press submit, text Name should be \"Name:John Doe\"")]
        [Category("UI")]

        public void TestFullNameFieldInput()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                FullNameInput.Set("John Doe").
                Submit.Click().
                FullNameText.Should.Contain("John Doe");

        }

        //Test Case 4
        [Test, Retry(2)]
        [Description("Clear Text Full Name Input, press submit, text Name " +
            "should not be visible")]
        [Category("UI")]
        public void TestFullNameFieldInputClearence()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                FullNameInput.Set("John Doe").
                Submit.Click().
                FullNameText.Should.Contain("John Doe").
                FullNameInput.Clear().
                Submit.Click().
                FullNameText.Should.Not.BeVisible();
        }
        #endregion

        #region  [Email] field:

        //Test Case 1: Text Email Name should be visible FullNameText
        //Test Case 2: Text name@example.com should be visible
        //Test Case 3: Enter invalid email data like "John Doe" in name@example.com Input, press submit, bar should become red
        //Test Case 4: Enter valid email data like "ABC@gmail.com" in name@example.com Input, press submit, text Name should be
        //"ABC@gmail.com
        //Test Case 5 Clear name@example.com Input, press submit, text email should not be visible

        //Test Case 1  
        [Test, Retry(2)]
        [Description("Text Email Name should be visible")]
        [Category("UI")]

        public void VerifyEmailLabelVisible()
        {
            Go.To<DemoQAElementsPage>().
               TextBox.ClickAndGo().
               EmailLabel.Should.BeVisible();

        }

        //Test Case 2:
        [Test, Retry(2)]
        [Description("Text name@example.com should be visible")]
        [Category("UI")]

        public void VerifyEmailFieldVisible()
        {
            Go.To<DemoQAElementsPage>().
               TextBox.ClickAndGo().
               EmailInput.Should.BeVisible();

        }

        //Test Case 3:
        [Test, Retry(2)]
        [Description("Enter invalid email data like \"John Doe\" in name@example.com Input, press submit, bar should become red")]
        [Category("UI")]
        public void TestIncorrectInputInEmailField()
        {
            Go.To<DemoQAElementsPage>().
               TextBox.ClickAndGo().
                EmailInput.Set("John Doe").
                Submit.Click().
                EmailText.Should.Not.BeVisible();
        }

        //Test Case 4:   
        [Test, Retry(2)]
        [Description(" Enter valid email data like \"ABC@gmail.com\" in " +
            "name@example.com Input, press submit, text Name should be ABC@gmail.com")]
        [Category("UI")]
        public void TestEmailFieldInput()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                EmailInput.Set("ABC@gmail.com").
                Submit.Click().
                EmailText.Should.Contain("ABC@gmail.com");

        }

        //Test Case 5:   
        [Test, Retry(2)]
        [Description("Clear name@example.com Input, press submit, text email " +
            "should not be visible")]
        [Category("UI")]
        public void TestEmailFieldClearence()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                EmailInput.Set("ABC@gmail.com").
                Submit.Click().
                EmailInput.Clear().
                Submit.Click().
                EmailText.Should.Not.BeVisible();

        }
        #endregion

        #region [Current Address] field:



        //Test Case 1:Label Current Address should be visible
        //Test Case 2: Text Current Address Input should be visible
        //Test Case 3: Enter "Bajana 10" in Current Address Input, press submit, text Current Address should be "Name:Bajana 10"
        //Test Case 4: Clear Text Current Address Input, press submit, text Current Address should not be visible

        //Test Case 1  
        [Test, Retry(2)]
        [Description("Label Current Address should be visible")]
        [Category("UI")]
        public void VerifyCurrentAddressLabelVisible()
        {
            Go.To<DemoQAElementsPage>().
               TextBox.ClickAndGo().
               CurrentAddressLabel.Should.BeVisible();

        }

        //Test Case 2
        [Test, Retry(2)]
        [Description("Current Address Input should be visible")]
        [Category("UI")]
        public void VerifyCurrentAddressFieldVisible()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                CurrentAddressInput.Should.BeVisible();
        }
        //Test Case 3
        [Test, Retry(2)]
        [Description("Enter 'Bajana 10' in Permanent Address Input, press submit," +
            " text Permanent Address should be 'Name: Bajana 10'")]
        [Category("UI")]
        public void TestCurrentAddressFieldInput()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                CurrentAddressInput.Set("Bajana 10").
                Submit.Click().
                CurrentAddressText.Should.Contain("Bajana 10");
        }

        //Test Case 4
        [Test, Retry(2)]
        [Description("Clear Text Current Address Input, press submit," +
            " text Current Address should not be visible")]
        [Category("UI")]
        public void TestCurrentAddressInputClearence()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                CurrentAddressInput.Set("Bajana 10").
                Submit.Click().
                CurrentAddressText.Should.Contain("Bajana 10").
                CurrentAddressInput.Clear().
                Submit.Click().
                CurrentAddressText.Should.Not.BeVisible();
        }

        #endregion

        #region [Permanent Address] field:

        //Test Case 1: Text Permanent Address should be visible
        //Test Case 2: Permanent Address Input should be visible
        //Test Case 3: Enter "Bajana 14" in Permanent Address Input, press submit, text Permanent Address should be "Name:Bajana 14"
        //Test Case 4: Clear Text Permanent Address Input, press submit, text Permanent Address should not be visible

        //Test Case 1  
        [Test, Retry(2)]
        [Description("Text Permanent Address should be visible")]
        [Category("UI")]
        public void VerifyPermanentAddressLabelVisible()
        {
            Go.To<DemoQAElementsPage>().
               TextBox.ClickAndGo().
               PermanentAddressLabel.Should.BeVisible();

        }

        //Test Case 2
        [Test, Retry(2)]
        [Description("Permanent Address Input should be visible")]
        [Category("UI")]
        public void VerifyPermanentAddressFieldVisible()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                PermanentAddressInput.Should.BeVisible();
        }
        //Test Case 3
        [Test, Retry(2)]
        [Description("Enter 'Bajana 14' in Permanent Address Input, press submit," +
            " text Permanent Address should be 'Name: Bajana 14'")]
        [Category("UI")]

        public void TestPermanentAddressFieldInput()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                PermanentAddressInput.Set("Bajana 14").
                Submit.Click().
                PermanentAddressText.Should.Contain("Bajana 14");
        }

        //Test Case 4
        [Test, Retry(2)]
        [Description("Clear Text Permanent Address Input, press submit, text " +
        "Permanent Address should not be visible")]
        [Category("UI")] 
        public void TestPermanentAddressInputClearence()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                PermanentAddressInput.Set("Bajana 14").
                Submit.Click().
                PermanentAddressText.Should.Contain("Bajana 14").
                PermanentAddressInput.Clear().
                Submit.Click().
                PermanentAddressText.Should.Not.BeVisible();
        }
            #endregion
    }
}

