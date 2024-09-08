using Microsoft.Playwright;
using System;


namespace Course_Final_Hw.PageObjects
{
    internal class AutoExerciseCheckoutPage
    {
        private IPage page;
        private string AutoExerciseCheckoutURL = "https://automationexercise.com/contact_us";

        public AutoExerciseCheckoutPage(IPage pagenew)
        {
            page = pagenew;
        }
        public async Task GoToAutoExerciseCheckoutPage()
        {
            await page.GotoAsync(AutoExerciseCheckoutURL);
        }
        public async Task VerifyPageIsTransferedTo()
        {
            await page.WaitForURLAsync("**/checkout");
        }
    }
}
