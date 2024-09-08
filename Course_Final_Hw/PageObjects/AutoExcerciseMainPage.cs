﻿using Microsoft.Playwright;

namespace Course_Final_Hw.PageObjects
{
    internal class AutoExcerciseMainPage
    {
        private IPage page;
        private string AutoExcerciseMainPageURL = "https://automationexercise.com";

        public AutoExcerciseMainPage(IPage pagenew)
        {
            page = pagenew;
        }
        public async Task GoToAutoExcerciseMainPage()
        {
            await page.GotoAsync(AutoExcerciseMainPageURL);
        }
    }
}
