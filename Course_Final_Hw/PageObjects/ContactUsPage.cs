using Course_Final_Hw.Infrastucture;
using Microsoft.Playwright;


namespace Course_Final_Hw.PageObjects
{
    internal class ContactUsPage
    {
        private IPage page;
        private string AutoExcerciseContactUsURL = "https://automationexercise.com/contact_us";

        public ContactUsPage(IPage pagenew)
        {
            page = pagenew;
        }
        public async Task GoToAutoExcerciseContactUsPage()
        {
            await page.GotoAsync(AutoExcerciseContactUsURL);
        }
        public async Task FillNameInput(string nameInput)
        {
            await page.GetByPlaceholder("Name").ClickAsync();
            await page.GetByPlaceholder("Name").FillAsync(nameInput);
        }
        public async Task FillEmailInput(string emailInput)
        {
            await page.Locator("#contact-us-form").GetByPlaceholder("Email").ClickAsync();
            await page.Locator("#contact-us-form").GetByPlaceholder("Email").FillAsync(emailInput);
        }
        public async Task FillSubjectInput(string subjectInput)
        {
            await page.GetByPlaceholder("Subject").ClickAsync();
            await page.GetByPlaceholder("Subject").FillAsync(subjectInput);
        }
        public async Task FillMessageInput(string messageInput)
        {
            await page.GetByPlaceholder("Your Message Here").ClickAsync();
            await page.GetByPlaceholder("Your Message Here").FillAsync(messageInput);
        }
        public async Task AddFileInput(string fileName)
        {
            string inputFile = Path.Combine(HelperMethod.GetProjectFilePath(), fileName);
            await page.Locator("input[name=\"upload_file\"]").SetInputFilesAsync(new[] { inputFile });  
        }
        public async Task ClickSubmitAndOK()
        {
            //Here we accept Popup after we click submit
            page.Dialog += async (_, dialog) => await dialog.AcceptAsync();

            await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        }

    }
}
