﻿using PlaywrigthSpecFlow.API.Models;

namespace PlaywrigthSpecFlow.API.Features.Account
{
    internal class AccountPresetup
    {
        internal static string UserName = "Astolfo";
        internal static string Password = "Pa$$word1";
        internal bool AccountCreated;
        internal string UserId;

        internal UserModel MainUser = new UserModel()
        {
            userName = UserName,
            password = Password
        };

        #region Setup
        internal async Task AccountApiPresetup()
        {
            AccountsApi account = new AccountsApi("https://demoqa.com/");


            UserId = await account.AddUserGetId(MainUser);
            var token = await account.GenerateToken(MainUser);
            var user = await account.GetUserById(UserId, token);
            var body = await user.Content.ReadAsStringAsync();
            Console.WriteLine("user info: " + body);
        }

        internal async Task AccountApiCleanup()
        {
            AccountsApi account = new AccountsApi("https://demoqa.com/");
            var token = await account.GenerateToken(MainUser);
            Assert.That(account.CheckIfUserExists, Is.EqualTo(200));
            await account.DeleteAccountByID(UserId, token);
            Assert.That(account.CheckIfUserExists, Is.EqualTo(404));
        }
        #endregion
        #region HelperMethods
        internal static string GetCurrentTimestamp()
        {
            DateTime currentTimestamp = DateTime.UtcNow;

            string timestamp = currentTimestamp.ToString("u");

            timestamp = Regex.Replace(timestamp, @"\D", "");

            return timestamp;
        }
        #endregion
    }
}